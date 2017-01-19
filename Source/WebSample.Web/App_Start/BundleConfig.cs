using System.Web.Optimization;

namespace WebSample
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Common/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Common/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Common/Scripts/Custom/date-plugin.js",
                "~/Common/Scripts/Custom/validation.extension.js",
                "~/Common/Scripts/Custom/date-selectors-plugin.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Common/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Common/Scripts/bootstrap.js",
                      "~/Common/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Common/Styles/bootstrap.css",
                      "~/Common/Styles/site.css"));
        }
    }
}
