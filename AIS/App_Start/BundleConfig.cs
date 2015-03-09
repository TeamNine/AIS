using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AIS.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // TODO add CDN
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.numberMask.min.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery-ui*",
                        "~/Scripts/expressive*"));
            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
            "~/Scripts/bootstrap-datetimepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/jquery-ui-1.10.0.custom.css",
                "~/Content/bootstrap-datetimepicker.min.css"));
            bundles.Add(new StyleBundle("~/Content/site").Include("~/Content/site.css"));
        }
    }
}