using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceInterface;
using Tipset.WebApi.Dto;

namespace RavenDb.Services
{
    //Can be called via any endpoint or format, see: http://servicestack.net/ServiceStack.Hello/
    public class HelloService : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = "Hello, " + request.Name };
        }
    }
}