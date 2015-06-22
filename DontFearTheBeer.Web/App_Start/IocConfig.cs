using DontFearTheBeer.Data;
using DontFearTheBeer.Data.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DontFearTheBeer.Web
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IDontFearTheBeerUow>().To<DontFearTheBeerUow>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}