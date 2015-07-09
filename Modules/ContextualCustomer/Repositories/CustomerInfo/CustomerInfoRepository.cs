// -----------------------------------------------------------------------
// <copyright file="CustomerInfoRepository.cs" company="Nexcel Solution">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ContextualCustomer.Repositories.CustomerInfo
{
    using System.Collections;
    using Fanex.Common;
    using Fanex.Data;

    /// <summary>
    /// Customer Information Repository.
    /// </summary>
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        /// <summary>
        /// Function to check username is existed.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Return status.</returns>
        public bool CheckingUsernameIsExisted(string username)
        {
            using (var objectDb = new ObjectDb("Age_CustomerCheckExists"))
            {
                var paramsSps = new Hashtable() { { "username", username }, { "isexists", 0 } };
                objectDb.ExecuteNonQuery(paramsSps);

                return Converter.ToBool(objectDb.GetParameterValue("isexists"));
            }
        }
    }
}