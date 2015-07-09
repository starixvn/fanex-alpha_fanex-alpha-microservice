// --------------------------------------------------------------------------
// <copyright file="GoldDeluxeRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ThirdParty.Repositories.GoldDeluxe
{
    using Fanex.Common;
    using Fanex.Data;
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.Core.Models;

    /// <summary>
    /// Gold Deluxe repository.
    /// </summary>
    public class GoldDeluxeRepository : IGoldDeluxeRepository
    {
        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The result object.</returns>
        public Result UpdateStatus(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(criteria.GetSpParams());
                var outputParams = db.GetOuputParams();
                string message = Converter.ToString2(outputParams["errmsg"]);

                var result = new Result()
                {
                    ErrorCode = string.IsNullOrEmpty(message) ? 0 : -1,
                    Message = message
                };
                
                return result;
            }
        }
    }
}
