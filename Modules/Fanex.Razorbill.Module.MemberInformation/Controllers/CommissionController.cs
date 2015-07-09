namespace Fanex.Razorbill.Module.MemberInformation.Controllers
{
    using System.Web.Mvc;
    using Fanex.Razorbill.Module.Common.Enums;
    using Fanex.Razorbill.Module.Common.Services;
    using Fanex.Razorbill.Module.Core.Web.Controllers;
    using Fanex.Razorbill.Module.MemberInformation.Models.Commission;
    using Fanex.Razorbill.Module.MemberInformation.Services.Commission;

    public class CommissionController : BaseController
    {
        private readonly ICommissionService _commissionService;

        public CommissionController()
            : this(null)
        { 
        }

        public CommissionController(ICommissionService commissionService)
        {
            _commissionService = commissionService ?? new CommissionService();
        }

        public ActionResult CommissionHint()
        {
            var hints = _commissionService.GetCommissionHint();
            return View("~/Areas/MemberInformation/Views/Commission/CommissionHint/Index.cshtml", hints);
        }

        public ActionResult GoldDeluxe()
        {
            CommissionReport commissionReport = new CommissionReport();
            int customerIdInSession = CookielessSession.CustomerId;
            LoggedInUserRole userRoleInSession = CookielessSession.LoggedInRole;
           
            if (userRoleInSession == LoggedInUserRole.Agent)
            {
                commissionReport = _commissionService.GetMemberGoldDeluxeCommission(customerIdInSession);
            }
            else if (userRoleInSession == LoggedInUserRole.Master)
            {
                commissionReport = _commissionService.GetMasterMemberGoldDeluxeCommission(customerIdInSession);
            }
            else if (userRoleInSession == LoggedInUserRole.Super)
            {
                commissionReport = _commissionService.GetSuperMemberGoldDeluxeCommission(customerIdInSession);    
            }

            return View("~/Areas/MemberInformation/Views/Commission/GoldDeluxe/Index.cshtml", commissionReport);
        }

        public ActionResult GoldDeluxeCommission(int? masterId, int? agentId)
        {
            CommissionReport commissionReport = new CommissionReport();

            int masterIdValue = masterId ?? 0;
            if (masterIdValue != 0)
            {
                if (agentId.HasValue && agentId.Value == 0)
                {
                    commissionReport = _commissionService.GetMasterMemberGoldDeluxeCommissionWithAllAgents(masterIdValue);    
                }
                else
                {
                    commissionReport = _commissionService.GetSelectedMasterMemberGoldDeluxeCommission(masterIdValue);
                }
            }
            else if (agentId.HasValue && agentId.Value > 0)
            {
                commissionReport = _commissionService.GetMemberGoldDeluxeCommission(agentId.Value);
            }

            return Json(commissionReport, JsonRequestBehavior.AllowGet);
        }
    }
}
