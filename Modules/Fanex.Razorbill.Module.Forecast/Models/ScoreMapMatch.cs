// --------------------------------------------------------------------------
// <copyright file="ScoreMapMatch.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2015.03.30">Created</change>
// </history>

namespace Fanex.Razorbill.Module.Forecast.Models
{
    using Fanex.Razorbill.Module.Core.Services.Impl;

    /// <summary>
    /// Score Map Match.
    /// </summary>
    public class ScoreMapMatch
    {
        public ScoreMapMatch(int matchId, int homeId, int awayId)
        {
            MatchId = matchId;
            MatchName = CacheRef.GetTeamName(MatchId);

            HomeId = homeId;
            HomeName = CacheRef.GetTeamName(HomeId);

            AwayId = awayId;
            AwayName = CacheRef.GetTeamName(AwayId);
        }

        public int MatchId { get; set; }

        public string MatchName { get; private set; }

        public int HomeId { get; set; }

        public string HomeName { get; private set; }

        public int AwayId { get; set; }

        public string AwayName { get; private set; }
    }
}
