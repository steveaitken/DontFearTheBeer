﻿using DontFearTheBeer.Data.Contracts;
using DontFearTheBeer.Model;
using System;

namespace DontFearTheBeer.Data
{
    public class DontFearTheBeerUow : IDontFearTheBeerUow, IDisposable
    {
        #region constructors

        public DontFearTheBeerUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        #endregion


        #region properties

        public IRepository<Beer> Beers
        {
            get { return GetStandardRepo<Beer>(); }
        }

        public IRepository<BeerImage> BeerImages
        {
            get { return GetStandardRepo<BeerImage>(); }
        }

        public IRepository<Brewery> Breweries
        {
            get { return GetStandardRepo<Brewery>(); }
        }

        public IReviewRepository Reviews
        {
            get { return GetRepo<IReviewRepository>(); }
        }

        public IRepository<Taster> Tasters
        {
            get { return GetStandardRepo<Taster>(); }
        }
                
        protected IRepositoryProvider RepositoryProvider { get; set; }

        private DontFearTheBeerDbContext DbContext { get; set; }

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
