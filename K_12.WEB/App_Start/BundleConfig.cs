﻿using System.Web;
using System.Web.Optimization;

namespace K_12.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"

                        ) );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
               
               "~/Scripts/kendo/2015.3.1111/kendo.all.min.js",
                "~/Scripts/kendo/2015.3.1111/kendo.aspnetmvc.min.js"


               ));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/fonts/font-awesome.min.css",
                     "~/Content/Site.css"));
        }
    }
}
