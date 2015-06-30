﻿using DontFearTheBeer.Data.Contracts;
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
        // GET: api/beer
        public IEnumerable<Beer> Get()
        {
            return Uow.Beers.GetAll();
        }

        // GET /api/beer/5
        public Beer Get(int id)
        {
            var beer = Uow.Beers.GetById(id);
            if (beer != null) return beer;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Create a new Beer
        // POST /api/beer
        public HttpResponseMessage Post(Beer beer)
        {
            Uow.Beers.Add(beer);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, beer);

            // Compose location header that tells how to get this session
            // e.g. ~/api/beer/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = beer.Id }));

            return response;
        }

        // Update an existing Beer
        // PUT /api/beer/
        public HttpResponseMessage Put(Beer beer)
        {
            Uow.Beers.Update(beer);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/beer/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Beers.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
