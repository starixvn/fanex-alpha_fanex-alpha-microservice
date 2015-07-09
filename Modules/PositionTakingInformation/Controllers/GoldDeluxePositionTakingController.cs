namespace Fanex.Razorbill.Module.PositionTaking.Controllers
{
    using System.Web.Mvc;
    using Fanex.Razorbill.Module.PositionTaking.Criteria.GoldDeluxeCriteria;
    using Fanex.Razorbill.Module.PositionTaking.Models.GoldDeluxe;
    using Fanex.Razorbill.Module.PositionTaking.Services.GoldDeluxeService;
    using Fanex.Razorbill.Module.PositionTakingInformation.Utils;

    public class GoldDeluxePositionTakingController : PositionTakingInforBaseController
    {
        private readonly IGoldDeluxePositionTakingService _goldDeluxeService;

        public GoldDeluxePositionTakingController()
            : this(null)
        {
        }

        public GoldDeluxePositionTakingController(IGoldDeluxePositionTakingService goldDeluxeService)
        {
            _goldDeluxeService = goldDeluxeService ?? new GoldDeluxePositionTakingService();
        }

        public ActionResult Index()
        {
            var criteria = new GetGoldDeluxePositionTakingCriteria
            {
                CustomerId = SessionExtension.CustId,
                PageIndex = 1,
                PageSize = 500
            };

            ViewBag.CustomerId = criteria.CustomerId;
            ViewBag.SubAccId = SessionExtension.SubAccId;
            ViewBag.RoleId = SessionExtension.RoleId;
            ViewBag.LangKey = SessionExtension.LangKey;

            var goldDeluxeModel = GetGoldDeluxePositionTaking(criteria);
            return View("~/Areas/PositionTakingInformation/Views/GoldDeluxe/Index.cshtml", goldDeluxeModel);
        }

        public ActionResult GetPositionTaking(GetGoldDeluxePositionTakingCriteria criteria)
        {
            var goldDeluxeModel = GetGoldDeluxePositionTaking(criteria);
            return PartialView("~/Areas/PositionTakingInformation/Views/GoldDeluxe/_PositionTaking.cshtml", goldDeluxeModel);
        }

        [NonAction]
        private GoldDeluxeModel GetGoldDeluxePositionTaking(GetGoldDeluxePositionTakingCriteria criteria)
        {
            var goldDeluxePTList = _goldDeluxeService.GetGoldDeluxePositionTaking(criteria);
            return new GoldDeluxeModel
            {
                PageIndex = criteria.PageIndex,
                PageSize = criteria.PageSize,
                TotalPages = criteria.TotalPages,
                Wildcards = criteria.Wildcards,
                DownlineLink = criteria.DownlineLink,
                GoldDeluxes = goldDeluxePTList
            };
        }
    }
}