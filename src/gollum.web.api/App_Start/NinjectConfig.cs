
using Ninject;
//using Ninject.Activation;
using gollum.web.api.Repositories.Task;
using gollum.web.api.Repositories.Application;
using gollum.web.api.Repositories.User;
using gollum.web.api.Repositories.Field;
using gollum.web.api.Repositories.Operation;
using gollum.web.api.Repositories.Role;
using gollum.web.api.Repositories.Organization;
using gollum.web.api.Repositories.Account;

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
        /// <summary>
        /// Relates the interfaces to their concrete implementations by adding bindings.
        /// </summary>
        /// <param name="container"></param>
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
            container.Bind<IApplicationRepository>().To<ApplicationRepository>().InSingletonScope();
            container.Bind<IOrganizationRepository>().To<OrganizationRepository>().InSingletonScope();
            container.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            container.Bind<IAccountRepository>().To<AccountRepository>().InSingletonScope();

            container.Bind<IFieldRepository>().To<FieldRepository>().InSingletonScope();
            container.Bind<IOperationRepository>().To<OperationRepository>().InSingletonScope();
            container.Bind<ITaskRepository>().To<TaskRepository>().InSingletonScope();
            //container.Bind<ITaskRepository>().To<TaskRepository>().InRequestScope();
            container.Bind<IRoleRepository>().To<RoleRepository>().InSingletonScope();
        }
    }
}