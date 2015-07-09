// -----------------------------------------------------------------------
// <copyright file="AuthenticationRepository.cs" company="Nexcel Solutions Vietnam">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Security.Repositories.Authentication
{
    using System.Collections;
    using Fanex.Common;
    using Fanex.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AuthenticationRepository : IAuthenticationRepository
    {
        /// <summary>
        /// Checking customer status.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>        
        /// <param name="subAccountId">SUB ACC ID.</param>
        /// <returns>Return status: 1 - is active, 2 - is closed.</returns>
        public bool CheckingCustomerStatus(int customerId, int subAccountId)
        {
            using (var objectDb = new ObjectDb("Age_CustomerStatusSel"))
            {
                Hashtable inputParams = new Hashtable();
                inputParams.Add("custid", customerId);
                inputParams.Add("subaccid", subAccountId);
                inputParams.Add("isactive", false);

                objectDb.AssignParamValues(inputParams);
                objectDb.ExecuteNonQuery();

                return Converter.ToBool(objectDb.GetOuputParams()["isactive"]);
            }
        }
    }
}
