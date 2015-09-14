﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebHost.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                defaults: new {id= RouteParameter.Optional});

        }
    }
}