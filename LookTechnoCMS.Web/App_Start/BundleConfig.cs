using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LookTechnoCMS.Web.App_Start


{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/scripts/jquery").Include(
            "~/Scripts/vendors/jquery-1.10.2.js"));
            bundles.Add(new ScriptBundle("~/bundles/scripts/query-migrate").Include(
         "~/Scripts/plugins/jquery-migrate-1.2.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
            "~/Scripts/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
    "~/Scripts/plugins/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-hover-dropdown").Include(
    "~/Scripts/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-slimscroll").Include(
    "~/Scripts/plugins/jquery-slimscroll/jquery.slimscroll.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryblockui").Include(
"~/Scripts/plugins/jquery.blockui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerycookie").Include(
"~/Scripts/plugins/jquery.cookie.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/uniform").Include(
"~/Scripts/plugins/uniform/jquery.uniform.min.js"));

//            //BEGIN PAGE LEVEL PLUGINS
            bundles.Add(new ScriptBundle("~/bundles/jqueryflot").Include(
"~/Scripts/plugins/flot/jquery.flot.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryflotresize").Include(
"~/Scripts/plugins/flot/jquery.flot.resize.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerypulsate").Include(
"~/Scripts/plugins/jquery.pulsate.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
"~/Scripts/plugins/bootstrap-daterangepicker/moment.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/daterangepicker").Include(
"~/Scripts/plugins/bootstrap-daterangepicker/daterangepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery.gritter").Include(
"~/Scripts/plugins/gritter/js/jquery.gritter.js"));
            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
"~/Scripts/plugins/fullcalendar/fullcalendar/fullcalendar.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/sparkline").Include(
"~/Scripts/plugins/jquery.sparkline.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
"~/Scripts/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/index").Include(
"~/Scripts/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/tasks").Include(
"~/Scripts/tasks.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-validation").Include(
"~/Scripts/plugins/jquery-validation/dist/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/backstretch").Include(
"~/Scripts/plugins/backstretch/jquery.backstretch.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
"~/Scripts/plugins/select2/select2.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/login-soft").Include(
"~/Scripts/login-soft.js"));
            bundles.Add(new Bundle("~/bundles/kendo-web").Include(
"~/Scripts/Vendors/kendo.all.min.js", "~/Scripts/Vendors/kendo.aspnetmvc.min.js"));
            bundles.Add(new Bundle("~/bundles/KendoGridCustomFunctions").Include(
"~/Scripts/KendoGridCustomFunctions.js"));
            bundles.Add(new ScriptBundle("~/bundles/KendoPopupFunctions").Include(
"~/Scripts/KendoPopupFunctions.js"));
   
                       
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(

                //"~/Scripts/Vendors/bootstrap.js",
                 // "~/Scripts/Vendors/kendo.all.min.js",
                 //"~/Scripts/Vendors/kendo.aspnetmvc.min.js",
                "~/Scripts/Vendors/toastr.js",
                "~/Scripts/Vendors/respond.js",
                "~/Scripts/Vendors/angular.js",
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-cookies.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/angucomplete-alt.min.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/Vendors/underscore.js",
                "~/Scripts/Vendors/morris.js",
              
                "~/Scripts/Vendors/loading-bar.js",
                   "~/Scripts/Vendors/jquery.validate.min.js",
                "~/Scripts/Vendors/jquery.validate.unobtrusive.min.js"
                //"~/Scripts/Vendors/jquery.validate*"
                ));
           
       
            //bundles.Add(new ScriptBundle("~/bundles/spa").Include(
            //    "~/spa/modules/common.core.js",
            //    "~/spa/modules/common.ui.js",
            //    "~/spa/app.js",
            //    "~/spa/services/apiService.js",
            //    "~/spa/services/notificationService.js",
            //    "~/spa/services/membershipService.js",
            //    "~/spa/home/rootCtrl.js",
            //    "~/spa/home/indexCtrl.js",
            //    "~/spa/users/usersCtrl.js"
              
            //    ));

            // CSS  
            bundles.Add(new StyleBundle("~/Styles/css").Include(
                     "~/Scripts/plugins/font-awesome/css/font-awesome.min.css",
                    "~/Scripts/plugins/bootstrap/css/bootstrap.min.css",
                    "~/Scripts/plugins/uniform/css/uniform.default.css",
                    "~/Scripts/plugins/gritter/css/jquery.gritter.css",
                    "~/Scripts/plugins/bootstrap-daterangepicker/daterangepicker-bs3.cs",
                    "~/Scripts/plugins/fullcalendar/fullcalendar/fullcalendar.css",
                    "~/Scripts/plugins/jqvmap/jqvmap/jqvmap.css",
                    "~/Scripts/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css",
                    "~/Content/css/style-metronic.css",
                    "~/Content/css/style.css",
                    "~/Content/css/style-responsive.css",
                    "~/Content/css/plugins.css",
                    "~/Content/css/pages/tasks.css",
                    "~/Content/css/custom.css",
                    "~/Content/css/loading-bar.css",
                    "~/Content/css/toastr.css",
                    "~/plugins/select2/select2_metro.cs",
                    "~/Content/css/pages/login-soft.css",
                    "~/Content/css/kendo.common.min.css",
                    "~/Content/css/kendo.default.min.css"
                   
           )
        );
            //.Include("~/Scripts/plugins/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
            //.Include("~/Content/css/kendo.default.min.css", new CssRewriteUrlTransform())
            bundles.Add((new StyleBundle("~/css/themes").Include("~/Content/css/themes/default.css")));
            //front Scripts
            bundles.Add(new ScriptBundle("~/bundles/frontbootstrap").Include(
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/frontbootstrap-rtl").Include(
                      "~/Scripts/bootstrap-rtl.js",
                      "~/Scripts/respond.js"));

            //front css
            bundles.Add(new StyleBundle("~/Content/frontcss").Include(
                      "~/Content/frontcss/style/css/bootstrap.css",
                      "~/Content/frontcss/style/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/frontcss-rtl").Include(
                      "~/Content/frontcss/stylertl/css/bootstrap.css",
                      "~/Content/frontcss/stylertl/css/style-rtl.css"));
                  //"~/Content/kendo/2015.1.408/kendo.common-bootstrap.core.min.css"
            BundleTable.EnableOptimizations = false;
        }
    }
}