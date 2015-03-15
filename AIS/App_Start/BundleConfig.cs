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
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.11.2.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-1.11.3.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include("~/Scripts/jquery.numberMask.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/select2").Include("~/Scripts/select2.js"));
            bundles.Add(new ScriptBundle("~/bundles/datepicker_ru").Include("~/Scripts/datepicker-ru.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/jquibootstrap").Include("~/Content/jquery-ui-1.10.0.custom.css"));
            bundles.Add(new StyleBundle("~/Content/datetimepicker").Include("~/Content/bootstrap-datetimepicker.min.css"));
            bundles.Add(new StyleBundle("~/Content/select2").Include("~/Content/select2.css"));
            bundles.Add(new StyleBundle("~/Content/site").Include("~/Content/site.css"));
        }
    }
}