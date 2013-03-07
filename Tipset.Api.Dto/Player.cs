using ServiceStack.ServiceHost;

namespace Tipset.Api.Dto
{
    [Route("/players/{Id}", "PUT")]
    public class NewPlayerRequest : IReturn<NewPlayerResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class NewPlayerResponse
    {
        public string Id { get; set; }
    }
}