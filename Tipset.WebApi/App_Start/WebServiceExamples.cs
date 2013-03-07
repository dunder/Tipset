using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.Common;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;

namespace RavenDb
{
/*  Example calling above Service with ServiceStack's C# clients:

	var client = new JsonServiceClient(BaseUri);
	List<Todo> all = client.Get(new Todos());           // Count = 0

	var todo = client.Post(
	    new Todo { Content = "New TODO", Order = 1 });      // todo.Id = 1
	all = client.Get(new Todos());                      // Count = 1

	todo.Content = "Updated TODO";
	todo = client.Put(todo);                            // todo.Content = Updated TODO

	client.Delete(new Todos(todo.Id));
	all = client.Get(new Todos());                      // Count = 0

*/

}
