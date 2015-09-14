﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start("http://localhost:8080"))
            {

                Console.WriteLine("Listing on port 8080");
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}");
            app.UseWebApi(configuration);
        }
    }
}
