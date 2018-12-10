using System.Web;
using System.Web.Optimization;

namespace MohatechMVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            // Styles
            bundles.Add(new StyleBundle("~/Content/Styles").Include(
                      "~/Content/Styles/bootstrap.css",
                      "~/Content/Styles/Site.css"));

            bundles.Add(new StyleBundle("~/Content/FontAwesome").Include(
                      "~/Content/Styles/all.min.css"));
        }
    }
}
