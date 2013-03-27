using NLog;
using ServiceStack.ServiceClient.Web;
using Tipset.Api.Dto;

namespace Tipset.AdminConsole.Commands
{
    class CreatePlayersCommand : ICommand
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly JsonServiceClient serviceClient;

        public CreatePlayersCommand(JsonServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        public void Execute(CommandLineOptions options)
        {

            Log.Info("Creating players");
            var presponse = serviceClient.Put(new NewPlayerRequest
            {
                Id = 1,
                Name = "Jimmy",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = serviceClient.Put(new NewPlayerRequest
            {
                Id = 2,
                Name = "Matias",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = serviceClient.Put(new NewPlayerRequest
            {
                Id = 3,
                Name = "Peter",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = serviceClient.Put(new NewPlayerRequest
            {
                Id = 4,
                Name = "Tomas",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
        }
    }
}
