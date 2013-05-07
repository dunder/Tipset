using System.Linq;
using Raven.Client;
using ServiceStack.ServiceInterface;
using Tipset.Domain;
using Tipset.Api.Dto;

namespace RavenDb.Services
{
    public class SeasonService : Service
    {
        public IDocumentStore DocumentStore { get; set; }
        public ISeasonFactory SeasonFactory { get; set; }

        public object Post(NewSeasonRequest season) 
        {
            using (var session = DocumentStore.OpenSession())
            {
                // ladda alla     
                var players = from player in session.Query<Player>()
                              orderby player.Name
                              select player;    

                var entity = SeasonFactory.Create(season.Name,
                    season.Start, 
                    season.End,
                    players.ToList());

                session.Store(entity);
                session.SaveChanges();
                
                return new NewSeasonResponse
                {
                    Id = entity.Id
                };
            }
        }
    }
}