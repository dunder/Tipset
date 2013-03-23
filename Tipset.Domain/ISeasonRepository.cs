namespace Tipset.Domain
{
    public interface ISeasonRepository : IRepository
    {
        void Add(Season season);
    }
}
