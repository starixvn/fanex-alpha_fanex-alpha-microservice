namespace Fanex.Razorbill.Module.MemberInformation
{
    using System.Web.Mvc;
    using System.Web.Optimization;

    public class MemberInformationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "MemberInformation"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "MemberInformation_Default",
                url: "MemberInformation/{controller}/{action}/{id}",
                defaults: new { controller = "MemberCommission", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Fanex.Razorbill.Module.MemberInformation.Controllers" });

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
