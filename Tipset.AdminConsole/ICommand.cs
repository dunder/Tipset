namespace Tipset.AdminConsole
{
    interface ICommand
    {
        void Execute(CommandLineOptions options);
    }
}
