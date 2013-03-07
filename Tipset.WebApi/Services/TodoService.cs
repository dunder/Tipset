using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Common;
using ServiceStack.ServiceInterface;
using RavenDb.Repository;
using Tipset.WebApi.Dto;

namespace RavenDb.Services
{
    public class TodosService : Service
    {
        public TodoRepository Repository { get; set; }  //Injected by IOC

        public object Get(Todos request)
        {
            return request.Ids.IsEmpty()
                ? Repository.GetAll()
                : Repository.GetByIds(request.Ids);
        }

        public object Post(Todo todo)
        {
            return Repository.Store(todo);
        }

        public object Put(Todo todo)
        {
            return Repository.Store(todo);
        }

        public void Delete(Todos request)
        {
            Repository.DeleteByIds(request.Ids);
        }
    }
}