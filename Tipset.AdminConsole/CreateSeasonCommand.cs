using Tipset.Common;

namespace Tipset.AdminConsole
{
    class CreateSeasonCommand : ICommand
    {
        public void Execute(CommandLineOptions options)
        {
            Guard.ArgumentIsNotNull(options, "options");
            Guard.ArgumentIsNotNull(options.CreateSeasonSubVerb, "options.CreateSeasonSubVerb");

            var commandOptions = options.CreateSeasonSubVerb;
        }
    }
}