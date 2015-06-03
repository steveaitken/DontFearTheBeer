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

        #endregion


        #region properties

        public DbSet<Beer> Beers { get; set; }

        #endregion


        #region protected methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Configurations.Add(new SessionConfiguration());
        }

        #endregion

    }
}
