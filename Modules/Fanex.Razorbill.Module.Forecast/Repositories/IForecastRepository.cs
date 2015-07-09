// --------------------------------------------------------------------------
// <copyright file="IForecastRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2015.03.25">Created</change>
// </history>

namespace Fanex.Razorbill.Module.Forecast.Repositories
{
    using System.Collections.Generic;
    using Fanex.Razorbill.Module.Forecast.Criteria;
    using Fanex.Razorbill.Module.Forecast.Models;

    public interface IForecastRepository
    {
        IList<ScoreMapLeague> GetScoreMapRunningLeagues(GetScoreMapRunningLeagueCriteria criteria);

        IList<ScoreMapMatch> GetScoreMapMatches(GetScoreMapMatchByLeagueCriteria criteria);

        IList<RawScoreMapBetType> GetScoreMapBetTypes(GetScoreMapBetTypeCriteria criteria);

        IList<ForecastScoreMap> GetScoreMapResults(GetForecastScoreMapCriteria criteria);
    }
}
