using System.Collections.Generic;

namespace Tipset.Domain
{
    public interface IPlayerAllocator
    {
        IList<Round> Allocate(IList<Player> players, IList<Round> rounds);
    }
}