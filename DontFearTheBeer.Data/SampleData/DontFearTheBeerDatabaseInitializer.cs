using DontFearTheBeer.Model;
using System;
using System.Data.Entity;

namespace DontFearTheBeer.Data.SampleData
{
    public class DontFearTheBeerDatabaseInitializer :
        DropCreateDatabaseAlways<DontFearTheBeerDbContext>
        //DropCreateDatabaseIfModelChanges<DontFearTheBeerDbContext>
    {
        #region variables

        protected Random rand = new Random();

        #endregion


        #region protected methods

        protected override void Seed(DontFearTheBeerDbContext context)
        {
            var brewery = AddBrewery(context);
            AddBeers(context, brewery);
        }

        #endregion


        #region private methods

        private Brewery AddBrewery(DontFearTheBeerDbContext context)
        {
            var brewery1 = new Brewery
            {
                Name = "Beer brewer",
                Address = "123 some street",
                ProvinceState = ProvinceState.QC,
                Country = Country.Canada
            };
            context.Breweries.Add(brewery1);
            context.SaveChanges();

            return brewery1;
        }

        private void AddBeers(DontFearTheBeerDbContext context, Brewery brewery)
        {
            var beer1 = new Beer
            {
                Name = "Bud",
                BreweryId = brewery.Id

            };
            context.Beers.Add(beer1);

            var beer2 = new Beer
            {
                Name = "Miller",
                BreweryId = brewery.Id
            };
            context.Beers.Add(beer2);
                      
            context.SaveChanges();

        }

        #endregion
    }
}
