using Raven.Client;
using ServiceStack.Common;
using ServiceStack.ServiceInterface;
using Tipset.Api.Dto;
using Tipset.Domain;

namespace RavenDb.Services
{
    public class PlayerService : Service
    {
        public IDocumentStore DocumentStore { get; set; }

        public object Put(NewPlayerRequest player)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var entity = player.TranslateTo<Player>();
                entity.Id = "players/" + player.Id;

                session.Store(entity);
                session.SaveChanges();

                return new NewPlayerResponse
                {
                    Id = entity.Id
                };
            }
        }
    }
}