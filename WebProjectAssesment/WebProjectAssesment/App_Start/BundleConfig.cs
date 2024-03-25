﻿using System.Web;
using System.Web.Optimization;

namespace WebProjectAssesment
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
          

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Assets/CSS/bootstrap.min.css"
                      ));
        }
    }
}
