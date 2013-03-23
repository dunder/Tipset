using System;
using System.Collections.Generic;
using CommandLine;
using NLog;
using ServiceStack.ServiceClient.Web;
using Tipset.Api.Dto;

namespace Tipset.AdminConsole
{
    class Program
    {
        private const string BaseUri = "http://127.0.0.1.:62280/api";
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static IDictionary<string, Func<CommandLineOptions, int>> commands;

        internal static int Main(string[] args)
        {
            RegisterCommands();

            var options = new CommandLineOptions();
            var command = "";

            if (Parser.Default.ParseArguments(args, options,
                  (verb, subOptions) =>
                    {
                      command = verb;
                    }))
            {
                RunCommand(command, options);
                return 0;
            }
            
            Console.WriteLine(options.GetUsage());
            return Parser.DefaultExitCodeFail;
        }

        private static void RunCommand(string command, CommandLineOptions commandOptions)
        {
            commands[command](commandOptions);
        }

        private static void RegisterCommands()
        {
            commands = new Dictionary<string, Func<CommandLineOptions, int>>
                       {
                           {"create-season", options => CreateSeason(options)}
                       };
        }



        private static JsonServiceClient CreateServiceClient()
        {
            Log.Info("Connecting to {0}", BaseUri);
            var jsonServiceClient = new JsonServiceClient(BaseUri);
            Log.Info("Connected");
            return jsonServiceClient;
        }

        private static int CreateSeason(CommandLineOptions options)
        {
            var createSeasonOptions = options.CreateSeasonSubVerb;

            var jsonServiceClient = CreateServiceClient();
            Log.Info("Creating a new season");

            var startDate = DateTime.Parse(createSeasonOptions.Start);
            var endDate = DateTime.Parse(createSeasonOptions.End);

            var response = jsonServiceClient.Post(new NewSeasonRequest
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
            return 0;
        }

        private static void CreatePlayer()
        {
            var jsonServiceClient = CreateServiceClient();

            Log.Info("Creating players");
            var presponse = jsonServiceClient.Put(new NewPlayerRequest
            {
                Id = 1,
                Name = "Jimmy",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = jsonServiceClient.Put(new NewPlayerRequest
            {
                Id = 2,
                Name = "Matias",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = jsonServiceClient.Put(new NewPlayerRequest
            {
                Id = 3,
                Name = "Peter",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = jsonServiceClient.Put(new NewPlayerRequest
            {
                Id = 4,
                Name = "Tomas",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
        }
    }
}
