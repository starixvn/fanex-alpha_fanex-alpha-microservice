// -----------------------------------------------------------------------
// <copyright file="CustomerInfoController.cs" company="Nexcel Solution">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ContextualCustomer.Controllers
{
    using System.Web.Mvc;
    using Fanex.Razorbill.Module.ContextualCustomer.Services.CustomerInfo;

    /// <summary>
    /// Customer Information Controller.
    /// </summary>
    public class CustomerInfoController : ContextualCustomerBaseController
    {
        private ICustomerInfoService _customerService;

        public CustomerInfoController()
        {
            _customerService = new CustomerInfoService();
        }

        [HttpPost]
        public ActionResult CheckingUsernameExisted(string username)
        {            
            var usernameIsExisted = _customerService.CheckingUsernameIsExisted(username);
            return Json(usernameIsExisted, JsonRequestBehavior.AllowGet);
        }
    }
}