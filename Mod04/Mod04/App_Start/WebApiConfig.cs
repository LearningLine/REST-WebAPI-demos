using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RESTfulBrowser.Formatters;

namespace Mod04
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Add(new BufferedJpegMediaTypeFormatter(HttpContext.Current.Server.MapPath("~/Images")));

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
