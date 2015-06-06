using DontFearTheBeer.Model;
using System.Data.Entity.ModelConfiguration;

namespace DontFearTheBeer.Data.Configuration
{
    public class BeerConfiguration : EntityTypeConfiguration<Beer>
    {
        #region constructors
        
        public BeerConfiguration()
        {
            // Beer has 1 brewery, Brewery has many Beers
            HasRequired(b => b.Brewery)
                .WithMany(br => br.Beers)
                .HasForeignKey(b => b.BreweryId);
        }

        #endregion
    }
}
