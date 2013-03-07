using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace Tipset.Api.Dto
{

    [Route("/seasons", "POST")]
    public class NewSeasonRequest : IReturn<NewSeasonResponse>
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> PlayerIds { get; set; }
    }

    public class NewSeasonResponse
    {
        public string Id { get; set; }
    }
}