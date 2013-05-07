using System;
using System.Collections.Generic;
using NLog;
using ServiceStack.ServiceClient.Web;
using Tipset.Api.Dto;
using Tipset.Common;

namespace Tipset.AdminConsole.Commands
{
    class CreateSeasonCommand : ICommand
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly JsonServiceClient serviceClient;

        public CreateSeasonCommand(JsonServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        public void Execute(CommandLineOptions options)
        {
            Guard.ArgumentIsNotNull(options, "options");
            Guard.ArgumentIsNotNull(options.CreateSeasonSubVerb, "options.CreateSeasonSubVerb");

            var createSeasonOptions = options.CreateSeasonSubVerb;

            Log.Info("Creating a new season");

            var startDate = DateTime.Parse(createSeasonOptions.Start);
            var endDate = DateTime.Parse(createSeasonOptions.End);

            var response = serviceClient.Post(new NewSeasonRequest
            {
                Name = string.Format("{0:yyyy}-{1:yyyy}", startDate, endDate),
                Start = startDate,
                End = endDate,
                PlayerIds = new List<string>
                    {
                        "players/1",
                        "players/2",
                        "players/3",
                        "players/4"
                    }
            });
            Log.Info("Season created: " + response.Id);
        }
    }
}