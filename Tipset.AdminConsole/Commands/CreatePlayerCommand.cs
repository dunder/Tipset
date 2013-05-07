using NLog;
using ServiceStack.ServiceClient.Web;
using Tipset.Api.Dto;

namespace Tipset.AdminConsole.Commands
{
    class CreatePlayerCommand : ICommand
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly JsonServiceClient serviceClient;

        public CreatePlayerCommand(JsonServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        public void Execute(CommandLineOptions options)
        {
            var createPlayerOptions = options.CreatePlayerSubVerb;

            Log.Info("Creating player");
            var response = serviceClient.Post(new NewPlayerRequest
            {
                Name = createPlayerOptions.Name,
                Email = createPlayerOptions.Email
            });
            Log.Info("Player created: " + response.Id);
        }
    }
}
