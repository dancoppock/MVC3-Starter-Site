using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Site.Infrastructure.Logging;
using Web.Infrastructure.Authentication;
using Web.Infrastructure.Reporting;
using Web.Infrastructure.Storage;
using Web.Models;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    //the Application is a Global class, started up with the server. You can
    //put things here and reference them throughout the app. One trick to 
    public enum AppEnvironment
    {
        Development,
        Test,
        Production
    }

    //public class MvcApplication : System.Web.HttpApplication
    //{
    public class MvcApplication : NinjectHttpApplication
    {

        /// <summary>
        /// This is here for you to use as needed. Application.Environment...
        /// </summary>
        public static AppEnvironment Environment
        {
            get
            {
#if DEBUG
                return AppEnvironment.Development;
#else

#endif
                return AppEnvironment.Production;
            }
        }
        public static ISession Session
        {
            get
            {
                return _container.Get<ISession>();
            }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }



        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.MapRoute(
                "Login", // Route name
                "login", // URL with parameters
                new { controller = "Session", action = "Create" } // Parameter defaults
            );
            routes.MapRoute(
                "Logout", // Route name
                "logout", // URL with parameters
                new { controller = "Session", action = "Delete" } // Parameter defaults
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }




        protected override void OnApplicationStarted()
        {
            Logger.Info("App is starting");

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RegisterAllControllersIn(Assembly.GetExecutingAssembly());
            SetEngines();
        }

        /// <summary>
        /// Set the alternate view engines here
        /// </summary>
        void SetEngines()
        {
            //Spark is lovely
            //and so is nHAML
            //you can enable either Below

            //to disable WebForms view engine...
            //ViewEngines.Engines.Clear();

            /*
            var settings = new SparkSettings()
             .SetDebug(true)
             .SetAutomaticEncoding(true)
             .AddAssembly("Web")
             .AddNamespace("Web.Model")
             .AddNamespace("System.Collections.Generic")
             .AddNamespace("System.Linq")
             .AddNamespace("System.Web.Mvc")
             .AddNamespace("System.Web.Mvc.Html");

            ViewEngines.Engines.Add(new SparkViewFactory(settings));
            */

            //config is in the web.config
            //ViewEngines.Engines.Add(new NHaml.Web.Mvc.NHamlMvcViewEngine());


        }

        /// <summary>
        /// IoC stuff below
        /// </summary>
        /// <returns></returns>
        protected override IKernel CreateKernel()
        {
            return Container;
        }

        internal class SiteModule : NinjectModule
        {
            public override void Load()
            {
                //a typical binding
                Bind<ILogger>().To<NLogLogger>();
                //Bind<INoSqlServer>().To<DB4OServer>().InSingletonScope();
                //Bind<ISession>().To<Db4oSession>().InRequestScope();

                //You can use the SimpleRepository to build out your database
                //it runs "Auto Migrations" - changing your schema on the fly for you
                //should you change your model. You can switch it out as you need.
                //http://subsonicproject.com/docs/Using_SimpleRepository

                Bind<ISession>().To<SiteEFSession>();
                Bind<IReporting>().To<ReportingSession>();
                Bind<IAuthenticationService>().To<AspNetAuthenticationService>();
            }
        }

        protected void Application_End()
        {
            Logger.Info("App is shutting down");
        }

        protected void Application_Error()
        {
            Exception lastException = Server.GetLastError();
            Logger.Fatal(lastException);
        }
        public ILogger Logger
        {
            get
            {
                return Container.Get<ILogger>();
            }
        }
        static IKernel _container;
        public static IKernel Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new StandardKernel(new SiteModule());
                }
                return _container;
            }
        }


    }
}