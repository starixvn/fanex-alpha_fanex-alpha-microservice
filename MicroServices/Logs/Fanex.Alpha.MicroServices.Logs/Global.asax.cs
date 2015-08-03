namespace Fanex.Alpha.MicroServices.Logs
{
    using System;
    using System.Web;
    using System.Reflection;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Fanex.Data.Configuration.DbSettingProviderManager.Current.Start();

            CheatApplicationName();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

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