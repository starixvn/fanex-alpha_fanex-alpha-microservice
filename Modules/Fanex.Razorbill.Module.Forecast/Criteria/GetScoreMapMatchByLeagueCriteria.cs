// --------------------------------------------------------------------------
// <copyright file="GetScoreMapMatchByLeagueCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2015.03.30">Created</change>
// </history>

namespace Fanex.Razorbill.Module.Forecast.Criteria
{
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.Common.Services;

    /// <summary>
    /// Get Score Map Match by League criteria.
    /// </summary>
    public class GetScoreMapMatchByLeagueCriteria : CriteriaBase
    {
        public int LeagueId { get; set; }

        public int AgentId
        {
            get
            {
                return CookielessSession.CustomerId;
            }
        }

        public override string GetSettingKey()
        {
            return "Age_ScoreMap_SelMatch";
        }
    }
}
