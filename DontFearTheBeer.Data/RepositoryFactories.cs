using DontFearTheBeer.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DontFearTheBeer.Data
{
    public class RepositoryFactories
    {
        #region variables

        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        #endregion


        #region constructors

        public RepositoryFactories()
        {
            _repositoryFactories = GetFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        #endregion


        #region public methods

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        #endregion


        #region private functions

        private IDictionary<Type, Func<DbContext, object>> GetFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {
                {typeof(IReviewRepository), dbContext => new ReviewRepository(dbContext)}
            };
        }
        
        private Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EFRepository<T>(dbContext);
        }

        #endregion
    }
}
