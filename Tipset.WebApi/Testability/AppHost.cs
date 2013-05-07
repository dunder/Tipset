using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Funq;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;
using RavenDb.Config;
using RavenDb.Repository;
using ServiceStack.Mvc;
using ServiceStack.WebHost.Endpoints;
using Tipset.Domain;
using Tipset.WebApi.Dto;

namespace RavenDb.Testability
{
    public class AppHost : AppHostHttpListenerBase
    {
        public override void Configure(Container container)
        {
            //Set JSON web services to return idiomatic JSON camelCase properties
			ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
		
			Routes.Add<Hello>("/hello")
			      .Add<Hello>("/hello/{Name*}");

            container.Register<IConfiguration>(c => new ConfigurationManagerConfiguration());
            container.Register(CreateDocumentStore());
            container.Register(c => c.Resolve<IDocumentStore>().OpenSession()).ReusedWithin(ReuseScope.Request);
			container.Register(new TodoRepository());
		    container.Register<ISeasonFactory>(c => new SeasonFactory());

			//Set MVC to use the same Funq IOC as ServiceStack
			ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
		}

        private static IDocumentStore CreateDocumentStore()
        {
            var store = new EmbeddableDocumentStore
                        {
                            RunInMemory = true
                        };

            store.Conventions.IdentityPartsSeparator = "-";
            store.Initialize();

            return store;
        }
    }
}