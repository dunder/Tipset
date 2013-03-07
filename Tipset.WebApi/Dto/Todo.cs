using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace Tipset.WebApi.Dto
{

    [Route("/todos", "POST")]
    [Route("/todos/{Id}", "PUT")]
    public class Todo : IReturn<Todo>
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public bool Done { get; set; }
    }
}