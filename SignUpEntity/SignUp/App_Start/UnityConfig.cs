using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SignUp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // Register types
            container.RegisterType<SignUpDAL>();
            container.RegisterType<SignUpService>();

            // Register controllers for DI resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }