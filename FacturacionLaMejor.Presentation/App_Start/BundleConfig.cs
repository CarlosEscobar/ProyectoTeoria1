// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   Copyright © 2014 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.FacturacionLaMejor.Presentation
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css/app").Include("~/content/app.css"));

            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/js/app").Include(
                "~/scripts/vendor/jquery-2.0.3.js",
                "~/scripts/vendor/angular.js",
                "~/scripts/vendor/angular-ui-router.js",
                "~/scripts/vendor/angular-cookies.js",
                "~/scripts/filters.js",
                "~/scripts/services.js",
                "~/scripts/directives.js",
                "~/scripts/controllers.js",
                "~/scripts/app.js",
                "~/scripts/Controllers/AboutController.js",
                "~/scripts/Controllers/AdminController.js",
                "~/scripts/Controllers/ConfigureLeagueController.js",
                "~/scripts/Controllers/ErrorController.js",
                "~/scripts/Controllers/ForgotPasswordController.js",
                "~/scripts/Controllers/HomeController.js",
                "~/scripts/Controllers/LeagueController.js",
                "~/scripts/Controllers/LoginController.js",
                "~/scripts/Controllers/ProfileController.js",
                "~/scripts/Controllers/RegisterController.js",
                "~/scripts/Controllers/ResetPasswordController.js",
                "~/scripts/Services/AccountService.js",
                "~/scripts/Services/AdminService.js"));
        }
    }
}
