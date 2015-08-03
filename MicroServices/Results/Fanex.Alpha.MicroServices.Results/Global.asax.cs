namespace Fanex.Alpha.MicroServices.Results
{
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Fanex.Razorbill.Module.Report;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Fanex.Data.Configuration.DbSettingProviderManager.Current.Start();
            CheatApplicationName();
        }

        private void CheatApplicationName()
        {
            string applicationName = "AlphaSite";

            // Change the Application Name in runtime.
            var runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
            var theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
            var appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);

            appNameInfo.SetValue(theRuntime, applicationName);
        }
    }
}