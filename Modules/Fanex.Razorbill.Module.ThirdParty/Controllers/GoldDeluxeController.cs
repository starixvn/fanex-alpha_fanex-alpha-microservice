// --------------------------------------------------------------------------
// <copyright file="GoldDeluxeController.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ThirdParty.Controllers
{
    using System.Web.Mvc;
    using Fanex.Razorbill.Module.Core.Web.Controllers;
    using Fanex.Razorbill.Module.ThirdParty.Criteria.GoldDeluxe;
    using Fanex.Razorbill.Module.ThirdParty.Services.GoldDeluxe;

    /// <summary>
    /// Gold Deluxe controller.
    /// </summary>
    public class GoldDeluxeController : BaseController
    {
        private readonly IGoldDeluxeService _goldDeluxeService;

        public GoldDeluxeController()
            : this(null)
        {
        }

        public GoldDeluxeController(IGoldDeluxeService goldDeluxeService)
        {
            _goldDeluxeService = goldDeluxeService ?? new GoldDeluxeService();
        }

        /// <summary>
        /// Updates the specified status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>The JSON result.</returns>
        [HttpPost]
        public ActionResult Update(UpdateGoldDeluxeStatusCriteria criteria)
        {
            var result = _goldDeluxeService.UpdateStatus(criteria);
            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}