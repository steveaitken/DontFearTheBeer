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
    public class BreweryController : ApiBaseController
    {
        #region constructors

        public BreweryController(IDontFearTheBeerUow uow)
        {
            Uow = uow;
        }

        #endregion


        #region public methods
        // GET: api/brewery
        public IEnumerable<Brewery> Get()
        {
            return Uow.Breweries.GetAll();
        }

        // GET /api/brewery/5
        public Brewery Get(int id)
        {
            Brewery brewery = Uow.Breweries.GetById(id);
            if (brewery != null) return brewery;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Create a new Brewery
        // POST /api/brewery
        public HttpResponseMessage Post(Brewery brewery)
        {
            Uow.Breweries.Add(brewery);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, brewery);

            // Compose location header that tells how to get this session
            // e.g. ~/api/brewery/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = brewery.Id }));

            return response;
        }

        // Update an existing brewery
        // PUT /api/brewery/
        public HttpResponseMessage Put(Brewery brewery)
        {
            Uow.Breweries.Update(brewery);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/brewery/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Breweries.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
