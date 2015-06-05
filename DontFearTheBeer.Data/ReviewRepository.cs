using DontFearTheBeer.Data.Contracts;
using DontFearTheBeer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Data
{
    public class ReviewRepository : EFRepository<Review>, IReviewRepository
    {
        #region constructors

        public ReviewRepository(DbContext context) : base(context)
        {

        }

        #endregion


        #region public methods

        public IQueryable<Review> GetByBeerId(int id)
        {
            return DbSet.Where(b => b.BeerId == id);
        }

        public IQueryable<Review> GetByTasterId(int id)
        {
            return DbSet.Where(t => t.TasterId == id);
        }

        public Review GetByIds(int beerId, int tasterId)
        {
            return DbSet.FirstOrDefault(bt => bt.BeerId == beerId && bt.TasterId == tasterId);
        }

        public void Delete(int beerId, int tasterId)
        {
            var review = new Review
            {
                BeerId = beerId,
                TasterId = tasterId
            };

            Delete(review);
        }
        
        public override Review GetById(int id)
        {
            throw new InvalidOperationException("Cannot return a single Review object by single id value.");
        }

        public override void Delete(int id)
        {
            throw new InvalidOperationException("Cannot delete a Review object by a single id value.");
        }
        
        #endregion
    }
}
