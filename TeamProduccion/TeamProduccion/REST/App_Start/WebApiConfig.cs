using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace REST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;

            //Esto se puede encontrar en la documentación de Newtonsoft
            jsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter); //Quitamos Xml
            settings.Formatting = Formatting.Indented; //Darle formato al json (en produccion no debería ir)
            settings.NullValueHandling = NullValueHandling.Ignore; //Quita las propiedades que vengan null
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); //Hace que las propiedades vayan formateadas como camel case

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
