namespace Tipset.AdminConsole
{
    public interface ICommand
    {
        void Execute(CommandLineOptions options);
    }
}
