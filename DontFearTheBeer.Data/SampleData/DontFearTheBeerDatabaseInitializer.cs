using System;
using System.Data.Entity;

namespace DontFearTheBeer.Data.SampleData
{
    public class DontFearTheBeerDatabaseInitializer :
        DropCreateDatabaseIfModelChanges<DontFearTheBeerDbContext>
    {
        #region variables

        protected Random rand = new Random();

        #endregion


        #region protected methods

        protected override void Seed(DontFearTheBeerDbContext context)
        {

        }

        #endregion
    }
}
