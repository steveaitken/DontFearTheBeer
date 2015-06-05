using DontFearTheBeer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Data.Contracts
{
    public interface IReviewRepository : IRepository<Review>
    {
        IQueryable<Review> GetByBeerId(int id);
        IQueryable<Review> GetByTasterId(int id);
        Review GetByIds(int beerId, int tasterId);
        void Delete(int beerId, int tasterId);
    }
}
