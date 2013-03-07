using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Embedded;
using Raven.Client;
using Raven.Client.Document;
using Raven.Database.Server;

namespace RavenDb.Controllers
{
    public class HomeController : BaseDocumentStoreController
    {
        
        
        public ActionResult Index()
        {
            return View();
        }

    }
}
