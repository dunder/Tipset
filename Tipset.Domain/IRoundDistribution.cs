using System;
using System.Collections.Generic;

namespace Tipset.Domain
{
    public interface IRoundDistribution
    {
        IList<Round> Distribute(DateTime start, DateTime end);
    }
}