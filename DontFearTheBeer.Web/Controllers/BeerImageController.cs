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
    public class BeerImageController : ApiBaseController
    {
        #region constructors

        public BeerImageController(IDontFearTheBeerUow uow)
        {
            Uow = uow;
        }

        #endregion


        #region public methods
        // GET: api/beerimage
        public IEnumerable<BeerImage> Get()
        {
            return Uow.BeerImages.GetAll();
        }

        // GET /api/beerimage/5
        public BeerImage Get(int id)
        {
            BeerImage beerImage = Uow.BeerImages.GetById(id);
            if (beerImage != null) return beerImage;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Create a new BeerImage
        // POST /api/beerimage
        public HttpResponseMessage Post(BeerImage beerImage)
        {
            Uow.BeerImages.Add(beerImage);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, beerImage);

            // Compose location header that tells how to get this session
            // e.g. ~/api/beerimage/5
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = beerImage.Id }));

            return response;
        }

        // Update an existing BeerImage
        // PUT /api/beerimage/
        public HttpResponseMessage Put(BeerImage beerImage)
        {
            Uow.BeerImages.Update(beerImage);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/beerimage/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.BeerImages.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
