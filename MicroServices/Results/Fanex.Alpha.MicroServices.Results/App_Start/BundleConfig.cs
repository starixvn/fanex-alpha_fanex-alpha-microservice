namespace Fanex.Razorbill.Module.Report
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterResultBundles(bundles);
        }

        private static void RegisterResultBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Report/Result/ResultScripts").Include(
                "~/Views/Result/Scripts/Result.js"));
        }
    }
}