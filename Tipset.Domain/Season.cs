using System.Collections.Generic;

namespace Tipset.Domain
{
    public class Season
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<Round> Rounds { get; set; }
    }
}
