using DontFearTheBeer.Model;
using System.Data.Entity.ModelConfiguration;

namespace DontFearTheBeer.Data.Configuration
{
    public class BeerImageConfiguration : EntityTypeConfiguration<BeerImage>
    {
        #region constructors

        public BeerImageConfiguration()
        {
            // Image has 1 Beer, Beer can have many Images
            HasRequired(bi => bi.Beer)
                .WithMany(b => b.Images)
                .HasForeignKey(bi => bi.BeerId);
        }

        #endregion
    }
}
