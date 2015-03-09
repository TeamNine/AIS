using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AIS.App_Start;
using ExpressiveAnnotations.Attributes;
using ExpressiveAnnotations.MvcUnobtrusiveValidatorProvider.Validators;

namespace AIS
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DataAnnotationsModelValidatorProvider.RegisterAdapter(
        typeof(RequiredIfAttribute), typeof(RequiredIfValidator));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(
                typeof(AssertThatAttribute), typeof(AssertThatValidator));
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}