using System;
using System.Collections.Generic;

namespace Tipset.Domain
{
    public class Round
    {
        public Round()
        {
            Results = new List<Result>();
        }

        public DateTime Date { get; set; }
        public IList<string> AssignedPlayerIds { get; set; }
        public IList<Result> Results { get; private set; }

        public override string ToString()
        {
            return string.Format("Date: {0:yyyy-MM-dd}, Assigned player ID:s: {1}",
                Date,
                string.Join(",", AssignedPlayerIds));
        }
    }
}
