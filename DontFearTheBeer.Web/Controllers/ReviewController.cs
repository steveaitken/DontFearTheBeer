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
    public class ReviewController : ApiBaseController
    {
        #region constructors

        public ReviewController(IDontFearTheBeerUow uow)
        {
            Uow = uow;
        }

        #endregion


        #region public methods
        // GET: api/review
        public IEnumerable<Review> Get()
        {
            return Uow.Reviews.GetAll();
        }

        // GET /api/review/5
        public Review Get(int id)
        {
            Review review = Uow.Reviews.GetById(id);
            if (review != null) return review;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Create a new Review
        // POST /api/review
        public HttpResponseMessage Post(Review review)
        {
            Uow.Reviews.Add(review);
            Uow.Commit();

            var response = Request.CreateResponse(HttpStatusCode.Created, review);

            // Compose location header that tells how to get this session
            // e.g. ~/api/review/5

            /****** NEED TO ADD THE OTHER ID HERE ******/
            response.Headers.Location =
                new Uri(Url.Link(WebApiConfig.ControllerAndId, new { id = review.BeerId }));

            return response;
        }

        // Update an existing review
        // PUT /api/review/
        public HttpResponseMessage Put(Review review)
        {
            Uow.Reviews.Update(review);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE /api/review/5
        public HttpResponseMessage Delete(int id)
        {
            Uow.Reviews.Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
