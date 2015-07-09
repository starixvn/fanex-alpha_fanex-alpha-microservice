// --------------------------------------------------------------------------
// <copyright file="ScoreMapBetTypeInfo.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2015.04.23">Created</change>
// </history>

namespace Fanex.Razorbill.Module.Forecast.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Score Map bet type information.
    /// </summary>
    public class ScoreMapBetTypeInfo
    {
        public string BetType { get; set; }

        public IList<string> FollowedBetTypes { get; set; }
    }
}
