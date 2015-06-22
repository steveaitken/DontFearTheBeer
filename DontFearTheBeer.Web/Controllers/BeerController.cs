using DontFearTheBeer.Data.Contracts;
using DontFearTheBeer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DontFearTheBeer.Web.Controllers
{
    public class BeerController : ApiBaseController
    {
        #region constructors

        public BeerController(IDontFearTheBeerUow uow)
        {
            Uow = uow;
        }

        #endregion


        #region public methods
        // GET: api/Beer
        public IEnumerable<Beer> Get()
        {
            return Uow.Beers.GetAll();
        }

        #endregion
    }
}
