using DontFearTheBeer.Data.Configuration;
using DontFearTheBeer.Data.SampleData;
using DontFearTheBeer.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DontFearTheBeer.Data
{
    public class DontFearTheBeerDbContext : DbContext
    {
        #region constructors

        static DontFearTheBeerDbContext()
        {
            Database.SetInitializer(new DontFearTheBeerDatabaseInitializer());
        }

        public DontFearTheBeerDbContext()
            : base(nameOrConnectionString: "DontFearTheBeerDbContext") { }

        #endregion


        #region properties

        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerImage> BeerImages { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Taster> Tasters { get; set; }

        #endregion


        #region protected methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new BeerConfiguration());
            modelBuilder.Configurations.Add(new BeerImageConfiguration());
            modelBuilder.Configurations.Add(new ReviewConfiguration());
        }

        #endregion

    }
}
