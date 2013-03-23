using System.Collections.Generic;

namespace Tipset.AdminConsole
{
    class CommandExecutor
    {
        private static Dictionary<string, ICommand> commands;

        static CommandExecutor()
        {
            commands = new Dictionary<string, ICommand>
                       {
                           {"create-season", new CreateSeasonCommand()} 
                       };
        }

        public void ExecuteCommand(string command, object options)
        {
            if (commands.ContainsKey(command))
            {

            }
        }
    }
}
