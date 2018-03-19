using System.Web;
using System.Web.Optimization;

namespace WebProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/HelpfullCss.css"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts/Ghost_Two").Include(
                "~/Scripts/other/jquery.easypiechart.min.js",
                "~/Scripts/other/main.js",
                "~/Scripts/other/plugin.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Scripts/Ghost_one").Include(
                "~/Scripts/GhostScripts/boostrap.min.js",
                "~/Scripts/GhostScripts/jquery-1.11.2.min.js",
                "~/Scripts/GhostScripts/modernizr-2.8.3-respond-1.4.2.min"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Scripts/Portfolio").Include(
                "~/Scripts/PortfolioScripts/jquery.min.js",
                "~/Scripts/PortfolioScripts/plugin.js",
                "~/Scripts/PortfolioScripts/scripts.js"
                ));
        }
    }
}
