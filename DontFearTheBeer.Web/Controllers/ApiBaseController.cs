using DontFearTheBeer.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DontFearTheBeer.Web.Controllers
{
    public class ApiBaseController : ApiController
    {
        // don't need to worry about disposing.  Because we are letting IOC
        // inject it we can also depend on it to dispose it
        protected IDontFearTheBeerUow Uow { get; set; }
    }
}
