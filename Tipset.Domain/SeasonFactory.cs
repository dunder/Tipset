using System;
using System.Collections.Generic;

namespace Tipset.Domain
{
    public class SeasonFactory : ISeasonFactory
    {
        public SeasonFactory()
        {
            
        }

        public SeasonFactory(IRoundDistribution roundDistribution, IPlayerAllocator playerAllocator)
        {
            RoundDistribution = roundDistribution;
            PlayerAllocator = playerAllocator;
        }

        public IRoundDistribution RoundDistribution { get; private set; }
        public IPlayerAllocator PlayerAllocator { get; private set; }

        public Season CreateWithDistribution(string name, DateTime start, DateTime end, IList<Player> players)
        {
            var season = new Season
                         {
                             Name = name,
                             Rounds = RoundDistribution.Distribute(start, end),
                         };

            PlayerAllocator.Allocate(players, season.Rounds);

            return season;
        }

        public Season Create(string name, DateTime start, DateTime end, IList<Player> players)
        {
            var currentRound = start;

            var rounds = new List<Round>();
            var playerTurn = 0;

            while (currentRound <= end)
            {
                var round = new Round();
                rounds.Add(round);

                if (playerTurn >= players.Count)
                {
                    playerTurn = 0;
                }
                var lastRoundAndPlayersDontEvenOut = currentRound == end && playerTurn != players.Count;
                if (lastRoundAndPlayersDontEvenOut)
                {
                    var playerIds = new List<string>();

                    for (var i = playerTurn; i < players.Count; i++)
                    {
                        playerIds.Add(players[i].Id);
                    }

                    round.AssignedPlayerIds = playerIds;
                }
                else
                {
                    var playerId = players[playerTurn].Id;
                    round.AssignedPlayerIds = new List<string> { playerId };
                }
                round.Date = currentRound;
                playerTurn += 1;
                currentRound = currentRound.AddDays(7);
            }

            return new Season
            {
                Name = name,
                Rounds = rounds
            };
        }
    }
}
