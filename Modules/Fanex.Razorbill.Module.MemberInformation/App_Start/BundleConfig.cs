namespace Fanex.Razorbill.Module.MemberInformation
{
    using System.Web.Optimization;

    internal static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/MemberInformation/Commission/CommissionHintStyles").Include(
                "~/Areas/MemberInformation/Views/Commission/CommissionHint/Styles/style.css"));

            RegisterCommissionBundles(bundles);
        }

        private static void RegisterCommissionBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/_GlobalResources/Css/MemberInformationAgent").Include(
                "~/_GlobalResources/Css/Agent.css"));

            bundles.Add(new StyleBundle("~/_Reports/Resources/MemberInformationReports").Include(
                "~/_Reports/Resources/Reports.css"));

            bundles.Add(new StyleBundle("~/Areas/MemberInformation/Views/Commission/Styles/Css").Include(
                "~/Areas/MemberInformation/Views/Commission/Styles/commission.css"));
 
            bundles.Add(new ScriptBundle("~/bundles/MemberInformation/Commission/GoldDeluxeScripts").Include(
                "~/Areas/MemberInformation/Views/Commission/GoldDeluxe/Scripts/goldDeluxe.js"));
        }
    }
}
