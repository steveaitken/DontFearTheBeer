using System.Data.Entity.ModelConfiguration;
using DontFearTheBeer.Model;

namespace DontFearTheBeer.Data
{
    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        #region constructors

        public ReviewConfiguration()
        {
            // Review has 1 Beer, Beer has many Reviews
            HasRequired(r => r.Beer)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BeerId);

            // Review has 1 Taster, Taster has many Reviews        
            HasRequired(r => r.Taster)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.TasterId);
        }

        #endregion
    }
}
