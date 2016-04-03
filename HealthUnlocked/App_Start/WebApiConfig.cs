using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HealthUnlocked.Infrastrucure;

namespace HealthUnlocked
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            var dependencyResolver = new WindsorDependencyResolver(Global.Container);

            config.DependencyResolver = dependencyResolver;
        }
    }
}
