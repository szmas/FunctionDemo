using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlogs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            StackExchange.Profiling.EntityFramework6.MiniProfilerEF6.Initialize();
        }

        protected void Application_BeginRequest()
        {

            if (Request.IsLocal)
            {

                MiniProfiler.Start();
            }
        }
        protected void Application_EndRequest()
        {
            if (Request.IsLocal)
            {

                MiniProfiler.Stop();
            }
        }

    }
}
