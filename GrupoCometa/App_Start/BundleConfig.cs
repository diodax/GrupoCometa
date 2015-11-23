using System.Web;
using System.Web.Optimization;

namespace GrupoCometa
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/bower_components/bootstrap/dist/js/bootstrap.js",  
                      /*"~/Scripts/bootstrap.js",*/
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                    /*Metis Menu Plugin JavaScript*/
                      "~/bower_components/metisMenu/dist/metisMenu.js",
                    /*Morris Charts JavaScript*/
                      "~/bower_components/raphael/raphael.js",
                      "~/bower_components/morrisjs/morris.js",
                    /*Custom Theme JavaScript*/
                      "~/bower_components/startbootstrap-sb-admin-2/dist/js/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    /*Bootstrap Core CSS*/
                      "~/bower_components/bootstrap/dist/css/bootstrap.css",
                    /*MetisMenu CSS*/
                      "~/bower_components/metisMenu/dist/metisMenu.css",
                    /*Timeline CSS*/
                      "~/bower_components/startbootstrap-sb-admin-2/dist/css/timeline.css",
                    /*Custom CSS*/
                      "~/bower_components/startbootstrap-sb-admin-2/dist/css/sb-admin-2.css",
                    /*Morris Charts CSS*/
                      "~/bower_components/morrisjs/morris.css",
                    /*Custom Fonts*/
                      "~/bower_components/font-awesome/css/font-awesome.css"
                      /*"~/Content/bootstrap.css",*/
                      /*"~/Content/site.css"*/));
        }
    }
}
