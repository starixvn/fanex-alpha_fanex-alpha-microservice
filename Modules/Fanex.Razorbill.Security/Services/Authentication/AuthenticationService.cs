// -----------------------------------------------------------------------
// <copyright file="AuthenticationService.cs" company="Nexcel Solutions Vietnam">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Security.Services.Authentication
{
    using System;
    using System.Configuration;
    using System.Text.RegularExpressions;
    using System.Web;
    using Fanex.Common;
    using Fanex.Common.Extensions;
    using Fanex.Razorbill.Security.Repositories.Authentication;
    using Sunplus.Agent.Model.BL;
    using Sunplus.Agent.Model.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private string _customerClosedStatusSessionKey = "Fanex.Razorbill.Security.Services.Authentication.CheckingClosedStatus";
        private IUserSession _currentUserSession;
        private IAuthenticationRepository _authenticationRepsitory;
        private string _urlRequest;
        private object _blockStatus = new object();

        public AuthenticationService(string urlRequest)
        {
            _currentUserSession = UserSessionService.GetUserSessionInstance(HttpContext.Current.Session.SessionID);
            _authenticationRepsitory = new AuthenticationRepository();
            _urlRequest = urlRequest;
        }

        /// <summary>
        /// Checking customer status.
        /// </summary>
        /// <returns>Return result.</returns>
        public bool CheckingClosedStatus()
        {
            lock (_blockStatus)
            {
                if (null == HttpContext.Current.Session)
                {
                    return true;
                }

                if (IsIgnoreUrl())
                {
                    return false;
                }

                var customerStatusSession = (string)SessionExtensions.GetSession(HttpContext.Current.Session, _customerClosedStatusSessionKey);
                if (!string.IsNullOrEmpty(customerStatusSession))
                {
                    var sessionInfo = customerStatusSession.Split('_');
                    if (sessionInfo.Length > 1 &&
                        Converter.ToDateTime(sessionInfo[1]) >= DateTime.Now)
                    {
                        return false;
                    }
                }

                var isActive = _authenticationRepsitory.CheckingCustomerStatus(_currentUserSession.CustId, _currentUserSession.SubAccId);
                if (!isActive)
                {
                    return true;
                }

                SessionExtensions.AddSession(
                    HttpContext.Current.Session,
                    _customerClosedStatusSessionKey,
                    string.Format("{0}_{1}", isActive, DateTime.Now.AddSeconds(Converter.ToInt(ConfigurationManager.AppSettings["CustomerStatusExpireTime"]))));

                return false;
            }            
        }

        public bool IsIgnoreUrl()
        {
            var pattern = "([^\\s]+(\\.(?i)(jpg|png|gif|bmp|css|js))$)";

            Regex urlRegex = new Regex(pattern);

            return urlRegex.IsMatch(_urlRequest, (int)RegexOptions.IgnoreCase);
        }
    }
}
