// --------------------------------------------------------------------------
// <copyright file="RawScoreMapBetType.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2015.04.23">Created</change>
// </history>

namespace Fanex.Razorbill.Module.Forecast.Models
{
    using System;

    /// <summary>
    /// Score Map raw data.
    /// </summary>
    [Serializable]
    public class RawScoreMapBetType
    {
        public int TypeId { get; set; }

        public int EventType { get; set; }

        public string FirstId { get; set; }

        public string InfoId { get; set; }
    }
}
