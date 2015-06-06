using DontFearTheBeer.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DontFearTheBeer.Data
{
    public class RepositoryProvider : IRepositoryProvider
    {
        #region variables

        private RepositoryFactories _repositoryFactories;

        #endregion


        #region constructors

        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        #endregion


        #region properties

        public DbContext DbContext { get; set; }

        private Dictionary<Type, object> Repositories { get; set; }

        #endregion


        #region public methods
        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            // look for T dictionary cache under typeof(T)
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);

            if (repoObj != null)
                return (T)repoObj;

            // not found or null then make and add to dictionary cache
            return MakeRepository<T>(factory, DbContext);
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }

        #endregion


        #region private functions

        private T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            Func<DbContext, object> f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
        
            if (f == null)
                throw new NotImplementedException("No factory for repository type,  " + typeof(T).FullName);

            var repo = (T)f(dbContext);
            SetRepository<T>(repo);
            //Repositories[typeof(T)] = repo;
            return repo;
        }

        #endregion

    }
}
