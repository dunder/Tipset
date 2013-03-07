using System.Collections.Generic;
using Raven.Client;
using ServiceStack.Common;
using ServiceStack.ServiceInterface;
using Tipset.Domain;
using Tipset.Api.Dto;

namespace RavenDb.Services
{
    public class SeasonService : Service
    {
        public IDocumentStore DocumentStore { get; set; }

        public object Post(NewSeasonRequest season) 
        {
            using (var session = DocumentStore.OpenSession())
            {
                var entity = season.TranslateTo<Season>();

                entity.Rounds = CreateRoundsForSeason(season);

                session.Store(entity);
                session.SaveChanges();
                return new NewSeasonResponse
                {
                    Id = entity.Id
                };
            }
        }

        private static List<Round> CreateRoundsForSeason(NewSeasonRequest season)
        {
            var currentRound = season.Start;

            var rounds = new List<Round>();
            var playerTurn = 0;

            while (currentRound <= season.End)
            {
                var round = new Round();
                rounds.Add(round);

                if (playerTurn >= season.PlayerIds.Count)
                {
                    playerTurn = 0;
                }
                var lastRoundAndPlayersDontEvenOut = currentRound == season.End && playerTurn != season.PlayerIds.Count;
                if (lastRoundAndPlayersDontEvenOut)
                {
                    var playerIds = new List<string>();

                    for (int i = playerTurn; i < season.PlayerIds.Count; i++)
                    {
                        playerIds.Add(season.PlayerIds[i]);
                    }
                }
                else
                {
                    var playerId = season.PlayerIds[playerTurn];
                    round.AssignedPlayerIds = new List<string> { playerId };
                }
                round.Date = currentRound;
                playerTurn += 1;
                currentRound = currentRound.AddDays(7);
            }
            return rounds;
        }
    }
}