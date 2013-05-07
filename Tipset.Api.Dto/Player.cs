using ServiceStack.ServiceHost;

namespace Tipset.Api.Dto
{
    [Route("/players", "POST")]
    public class NewPlayerRequest : IReturn<NewPlayerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class NewPlayerResponse
    {
        public string Id { get; set; }
    }
}