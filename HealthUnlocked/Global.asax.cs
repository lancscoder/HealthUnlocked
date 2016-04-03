using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Http.Controllers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using HealthUnlocked.Infrastrucure;

namespace HealthUnlocked
{
    public class Global : HttpApplication
    {
        public static IWindsorContainer Container;

        void Application_Start(object sender, EventArgs e)
        {

            var container = new WindsorContainer();

            container.Register(
                Component
                    .For<IWeatherProvider>()
                    .ImplementedBy<WeatherProvider>()
                    .LifestyleScoped(),
                Component
                    .For<IWeatherApiClient>()
                    .ImplementedBy<WeatherApiClient>()
                    .LifestyleScoped(),
                Component
                    .For<IWeatherDataParser>()
                    .ImplementedBy<WeatherDataParser>()
                    .LifestyleScoped(),
                Component
                    .For<IHistoricWeatherRepository>()
                    .ImplementedBy<HistoricWeatherRepository>()
                    .LifestyleScoped(),
                Classes
                    .FromThisAssembly()
                    .BasedOn<IHttpController>()
                    .LifestyleTransient()
                );

            Container = container;

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //var dependencyResolver = new WindsorDependencyResolver(container);
            //
            //GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;

        }
    }
}