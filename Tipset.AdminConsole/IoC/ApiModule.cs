using Ninject.Modules;
using ServiceStack.ServiceClient.Web;

namespace Tipset.AdminConsole.IoC
{
    class ApiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<JsonServiceClient>().ToSelf().WithConstructorArgument("baseUri", "http://127.0.0.1.:62280/api");
        }
    }
}
