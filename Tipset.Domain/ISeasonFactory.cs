using System;
using System.Collections.Generic;

namespace Tipset.Domain
{
    public interface ISeasonFactory
    {
        Season Create(string name, DateTime start, DateTime end, IList<Player> players);
    }
}
