// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="">
//   Copyright � 2014 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.FacturacionLaMejor.Presentation
{
    using System.Web.Routing;

    using App.FacturacionLaMejor.Presentation.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }
    }
}
