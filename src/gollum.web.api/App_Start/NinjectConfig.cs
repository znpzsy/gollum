
using Ninject;
using Ninject.Activation;
using gollum.web.api.Repositories;

namespace gollum.web.api.App_Start
{
    /// <summary>
    /// Set up the Ninject DI container
    /// -----------------------------------
    /// This is where interfaces are binded / related  to concrete implementations 
    /// so that the dependencies can be resolved at run time. 
    /// </summary>
    public class NinjectConfig
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        /// <summary>
        /// *IMPORTANT*
        /// Never configure a type as Singleton, if it depends upon ISession.
        /// ISession is disposed of at the end of every request. 
        /// Also make sure that types dependent upon such types aren't configured as singleton.
        /// </summary>
        /// <param name="container"></param>
        private void AddBindings(IKernel container)
        {
            container.Bind<ITaskRepository>().To<TaskRepository>().InSingletonScope();
            //container.Bind<ITaskRepository>().To<TaskRepository>().InRequestScope();
        }
    }
}