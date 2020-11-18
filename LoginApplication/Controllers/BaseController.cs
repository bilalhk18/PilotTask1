using Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LoginApplication.Controllers
{
    public class BaseController : ApiController
    {
        protected DomainContext context;

        public BaseController()
        {
            context = new DomainContext();
        }

        public BaseController(String name)
        {
            context = new DomainContext(name);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}