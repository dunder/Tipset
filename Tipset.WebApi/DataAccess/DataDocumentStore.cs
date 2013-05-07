using System;
using System.Configuration;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;

namespace RavenDb.DataAccess
{
    public class DataDocumentStore
    {
        private static IDocumentStore instance;

        public static IDocumentStore Instance
        {
            get
            {
                if (instance == null) {
                    throw new InvalidOperationException("IDocumentStore has not been initialized.");
                }
                
                return instance;
            }
        }

        public static IDocumentStore Initialize()
        {
            instance = new EmbeddableDocumentStore
            {
                ConnectionStringName = "RavenDB",
                UseEmbeddedHttpServer = true,
                // Configuration = { Port = 62281 }
            };
            instance.Conventions.IdentityPartsSeparator = "-";
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(Convert.ToInt32(ConfigurationManager.AppSettings["Raven/Port"]));
            
            instance.Initialize();
            return instance;
        }

        public static void Dispose() 
        {
            instance.Dispose();
        }
    }
}