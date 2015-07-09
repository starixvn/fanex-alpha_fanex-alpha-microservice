// -----------------------------------------------------------------------
// <copyright file="GoldDeluxeAuthorizationService.cs" company="Nexcel">
// David
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Security.Customer
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Fanex.GoldDeluxe.CoreSetting.Services;

    /// <summary>
    /// Gold Deluxe authentication.
    /// </summary>
    public class GoldDeluxeAuthorizationService : IGoldDeluxeAuthorizationService
    {
        private AuthenticateCustomer _authenticateCustomer = new AuthenticateCustomer();
        private SettingService _livecasinoService = new SettingService();

        public bool IsAuthorizedRead(AuthorizationContext authorizationContext, int custId)
        {
            return _authenticateCustomer.AllowReadDepenOnCustIdBelong(custId);
        }

        public bool IsAuthorizedHost(AuthorizationContext authorizationContext, int custId)
        {
            return _authenticateCustomer.AllowUpdateDepenOnCustIdBelong(custId);
        }

        /// <summary>
        /// Authentication multiple.
        /// </summary>
        /// <param name="authorizationContext">Authorization Context object.</param>
        /// <param name="usernames">User name list.</param>
        /// <returns>Boolean object.</returns>
        public bool IsAuthorizedReadMultiple(AuthorizationContext authorizationContext, IEnumerable<string> usernames)
        {
            foreach (var customer in usernames)
            {
                if (!_authenticateCustomer.AllowReadDepenOnUsernameBelong(customer))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Authentication multiple.
        /// </summary>
        /// <param name="authorizationContext">Authorization Context object.</param>
        /// <param name="usernames">User name list.</param>
        /// <returns>Boolean object.</returns>
        public bool IsAuthorizedHostMultiple(AuthorizationContext authorizationContext, IEnumerable<string> usernames)
        {
            foreach (var customer in usernames)
            {
                if (!_authenticateCustomer.AllowUpdateDepenOnUsernameBelong(string.Empty, customer))
                {
                    return false;
                }
            }

            return true;
        }
    }
}