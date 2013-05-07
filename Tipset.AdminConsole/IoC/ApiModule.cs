using System.Configuration;
using Ninject.Modules;
using ServiceStack.ServiceClient.Web;

namespace Tipset.AdminConsole.IoC
{
    class ApiModule : NinjectModule
    {
        public override void Load()
        {
            var baseUri = ConfigurationManager.AppSettings["ServiceApi/Url"];
            Bind<JsonServiceClient>().ToSelf().WithConstructorArgument("baseUri", baseUri);
        }
    }
}
