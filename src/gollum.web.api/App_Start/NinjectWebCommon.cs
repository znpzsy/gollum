[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(gollum.web.api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(gollum.web.api.App_Start.NinjectWebCommon), "Stop")]

namespace gollum.web.api.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http.Dependencies;
    using System.Collections.Generic;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;

    /// <summary>
    /// A dependency injection container should be created during application startup
    /// and remain in memory until the app shutdown. 
    /// ------------------------------------------------------------------
    /// 
    /// An <see cref="IDependencyResolver" /> implemented using the Ninject DI container.
    /// </summary>
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            // znp: introduce the dependency resolver to the global configuration. otherwise dependencies won't be resolved by ninject. sucker.

            IKernel container = null;
            bootstrapper.Initialize(() =>
            {
                container = CreateKernel();
                return container;
            });


            var resolver = new NinjectDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var containerConfigurator = new NinjectConfig();
            containerConfigurator.Configure(kernel);
        }
    }

    /// <summary>
    /// This one is specific to Web API.
    /// Resolver class tells ASP.NET Web API to ask Ninject for all dependencies required at run time by the dependent objects.
    /// This is the key that allows you to push dependencies up to the constructor on the controllers.
    /// Without this resolver, ASP.NET won’t use your configured Ninject container for dependencies.
    /// </summary>
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _container;

        /// <summary>
        /// Initializes a new instance of the NinjectDependencyResolver class.
        /// IKernel, a super-factory that can create objects of all kinds, will be our IoC container.
        /// </summary>
        /// <param name="container"></param>
        public NinjectDependencyResolver(IKernel container)
        {
            _container = container;
        }

        /// <summary>
        /// The IoC Container that holds the services.
        /// </summary>
        public IKernel Container
        {
            get { return _container; }
        }

        /// <summary>
        /// Gets an instance of the specified service by using the first binding that matches the specified constraint.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns>An instance of the service</returns>
        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        /// <summary>
        /// Gets all services registered with the container.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns>A series of instances of the service</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }

        /// <summary>
        /// Represents the range of the dependencies.
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// Disposes the NinjectDependencyResolver
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
