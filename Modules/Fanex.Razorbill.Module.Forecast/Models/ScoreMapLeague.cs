// --------------------------------------------------------------------------
// <copyright file="ScoreMapLeague.cs" company="Nexcel Solutions Vietnam">
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
    /// Score Map League.
    /// </summary>
    public class ScoreMapLeague
    {
        public ScoreMapLeague(int id)
            : this(id, null)
        {
        }

        public ScoreMapLeague(int id, string name)
        {
            Id = id;
            Name = name ?? CacheRef.GetLeagueName(Id);
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public int SportId { get; set; }
    }
}
