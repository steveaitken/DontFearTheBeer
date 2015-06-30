using DontFearTheBeer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Data.Contracts
{
    public interface IDontFearTheBeerUow
    {
        void Commit();

        IRepository<Beer> Beers { get; }
        IRepository<BeerImage> BeerImages { get; }
        IRepository<Brewery> Breweries { get; }
        IReviewRepository Reviews { get; }
        IRepository<Taster> Tasters { get; }
    }
}
