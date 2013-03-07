using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace Tipset.WebApi.Dto
{

    //REST Resource DTO
    [Route("/todos")]
    [Route("/todos/{Ids}")]
    public class Todos : IReturn<List<Todo>>
    {
        public long[] Ids { get; set; }
        public Todos(params long[] ids)
        {
            this.Ids = ids;
        }
    }
}