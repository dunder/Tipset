using System;
using CommandLine;
using Ninject;
using NLog;
using Tipset.AdminConsole.IoC;

namespace Tipset.AdminConsole
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        internal static IKernel Kernel { get; set; }

        internal static int Main(string[] args)
        {
            Log.Info("Arguments: ", args);

            Kernel = Kernel ?? new StandardKernel(new ApiModule(), new CommandModule());


            var options = new CommandLineOptions();
            var commandName = "";

            // Cannot use Parser.Default because it is singelton and keeps the same TextWriter instance
            // which interfere with the Console.Out redirection in unit tests
            var invalidArguments = !new Parser().ParseArguments(
                args,
                options,
                (verb, subOptions) =>
                    {
                        commandName = verb;
                    });

            if (invalidArguments)
            {
                Console.WriteLine(options.GetUsage());
                return (int) ExitCodes.InvalidArguments;
            }
            var commandFactory = Kernel.Get<ICommandFactory>();
            var command = commandFactory.CreateCommand(commandName);
            command.Execute(options);

            return (int)ExitCodes.Ok;
        }
    }
}
