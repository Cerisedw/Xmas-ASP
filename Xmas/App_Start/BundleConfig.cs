using System.Web;
using System.Web.Optimization;

namespace Xmas
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/css/bootstrap.css",
                      "~/css/style.css",
                      "~/css/dscountdown.css",
                      "~/css/animate.css",
                      "~/css/font-awesome.css",
                      "~/css/lightbox.css",
                      "~/css/cm-overlay.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/hideURLbar").Include(
                      "~/js/hideURLbar.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jsFooter").Include(
                      "~/js/jquery-2.2.3.min.js",
                      "~/js/scrolling-nav.js",
                      "~/js/jquery.vide.min.js",
                      "~/js/jquery.tools.min.js",
                      "~/js/jquery.mobile.custom.min.js",
                      "~/js/jquery.cm-overlay.js",
                      "~/js/cmOverlay.js",
                      "~/js/dscountdown.min.js",
                      "~/js/dsCountDown.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/jqueryUi").Include(
                      "~/css/jquery-ui.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jsFooter2").Include(
                      "~/js/jquery-ui.js",
                      "~/js/datePicker.js",
                      "~/js/move-top.js",
                      "~/js/easing.js",
                      "~/js/scrollAnimate.js",
                      "~/js/uiToTop.js",
                      "~/js/SmoothScroll.min.js",
                      "~/js/bootstrap.js"
                      ));

        }
    }
}
