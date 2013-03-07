using System;
using System.Collections.Generic;
using NLog;
using ServiceStack.ServiceClient.Web;
using Tipset.Api.Dto;

namespace Tipset.Console
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {


            const string baseUri = "http://127.0.0.1.:62280/api";
            Log.Info("Connecting to {0}", baseUri);
            var client = new JsonServiceClient(baseUri);
            Log.Info("Connected");

            
            
            Log.Info("Creating a new season");
            var response = client.Post(new NewSeasonRequest
            {
                Name = "2012-2013",
                Start = new DateTime(2012,8,18),
                End = new DateTime(2013,5,18),
                PlayerIds= new List<string> 
                {
                    "players/1",
                    "players/2",
                    "players/3",
                    "players/4"
                }
            });
            Log.Info("Season created: " + response.Id);

            Log.Info("Creating players");
            var presponse = client.Put(new NewPlayerRequest
            {
                Id = 1,
                Name = "Jimmy",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = client.Put(new NewPlayerRequest
            {
                Id = 2,
                Name = "Matias",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = client.Put(new NewPlayerRequest
            {
                Id = 3,
                Name = "Peter",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
            presponse = client.Put(new NewPlayerRequest
            {
                Id = 4,
                Name = "Tomas",
                Email = ""
            });
            Log.Info("Player created: " + presponse.Id);
        }
    }
}
