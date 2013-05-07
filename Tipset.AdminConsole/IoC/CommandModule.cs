using Ninject.Extensions.Factory;
using Ninject.Modules;
using Tipset.AdminConsole.Commands;
using Tipset.Common.Ninject;

namespace Tipset.AdminConsole.IoC
{
    class CommandModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommandFactory>().ToFactory(() => new UseFirstArgumentAsNameInstanceProvider());

            Bind<ICommand>().To<CreateSeasonCommand>().Named("create-season");
            Bind<ICommand>().To<CreatePlayerCommand>().Named("create-player");
        }
    }
}
