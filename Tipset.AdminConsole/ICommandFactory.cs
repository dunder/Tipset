namespace Tipset.AdminConsole
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string type);
    }
}
