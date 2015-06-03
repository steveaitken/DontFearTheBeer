using DontFearTheBeer.Data.Contracts;
using DontFearTheBeer.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontFearTheBeer.Data
{
    public class DontFearTheBeerUow : IDontFearTheBeerUow, IDisposable
    {
        #region constructors

        public DontFearTheBeerUow(IRepositoryProvider respositoryProvider)
        {
            CreateDbContext();
        }

        #endregion

        #region properties

        private DontFearTheBeerDbContext DbContext { get; set; }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        #endregion


        #region public methods

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        #endregion

        #region protected methods

        protected void CreateDbContext()
        {
            DbContext = new DontFearTheBeerDbContext();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicityly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will preform validation we do not need EF to  do it
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        #endregion


        #region private methods

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T:class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
