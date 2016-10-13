using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DVDRental
{
    public static class WebApiConfig
    {

        private static void ApplyTo<T>(this T source, params Action<T>[] targets)
        {
            foreach (var target in targets)
            {
                target(source);
            }
        }

        private static void ConfigureFilters(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
                = new CamelCasePropertyNamesContractResolver();
        }

        private static void ConfigureRoutes(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // WebAPI when dealing with JSON & JavaScript!
            // Setup json serialization to serialize classes to camel (std. Json format)
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.ApplyTo(
                ConfigureRoutes,
                ConfigureFilters,
                ConfigureFormatters
            );
        }

    }
}
