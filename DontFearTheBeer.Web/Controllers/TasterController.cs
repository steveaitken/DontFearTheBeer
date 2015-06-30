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
    public class TasterController : ApiBaseController
    {
        #region constructors

        public TasterController(IDontFearTheBeerUow uow)
        {
            Uow = uow;
        }

        #endregion


        #region public methods
        // GET: api/taster
        public IEnumerable<Taster> Get()
        {
            return Uow.Tasters.GetAll();
        }

        // GET /api/taster/5
        public Taster Get(int id)
        {
            Taster taster = Uow.Tasters.GetById(id);
            if (taster != null) return taster;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Create a new Taster
        // POST /api/taster
        public HttpResponseMessage Post(Taster taster)
        {
            Uow.Tasters.Add(taster);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, taster);

            // Compose location header that tells how to get this session
            // e.g. ~/api/taster/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = taster.Id }));

            return response;
        }

        // Update an existing Taster
        // PUT /api/taster/
        public HttpResponseMessage Put(Taster taster)
        {
            Uow.Tasters.Update(taster);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/taster/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Tasters.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
