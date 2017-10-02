using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;

namespace LiveScore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            ConfigureFormatters();

            config.Routes.MapHttpRoute(
                name: "SetTimeLeft",
                routeTemplate: "api/SetTimeLeft/{id}/{timeLeft}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "Score",
                    action = "SetTimeLeft"
                }
            );
            config.Routes.MapHttpRoute(
                name: "GoalHome",
                routeTemplate: "api/GoalForHomeTeam/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "Score",
                    action = "GoalForHomeTeam"
                }
            );
            config.Routes.MapHttpRoute(
                name: "GoalAway",
                routeTemplate: "api/GoalForAwayTeam/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "Score",
                    action = "GoalForAwayTeam"
                }
            );
            config.Routes.MapHttpRoute(
                name: "RemoveHome",
                routeTemplate: "api/RemoveFromHomeTeam/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "Score",
                    action = "RemoveFromHomeTeam"
                }
            );
            config.Routes.MapHttpRoute(
                name: "RemoveAway",
                routeTemplate: "api/RemoveFromAwayTeam/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "Score",
                    action = "RemoveFromAwayTeam"
                }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ConfigureFormatters()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new RequestHeaderMapping("type", "json", StringComparison.InvariantCulture, false, new MediaTypeHeaderValue("application/json")));

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new RequestHeaderMapping("type", "xml", StringComparison.InvariantCulture, false, new MediaTypeHeaderValue("application/xml")));
        }
    }
}
