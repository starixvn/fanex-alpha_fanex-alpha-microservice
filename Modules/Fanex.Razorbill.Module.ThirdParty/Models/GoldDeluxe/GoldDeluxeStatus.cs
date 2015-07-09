// --------------------------------------------------------------------------
// <copyright file="GoldDeluxeStatus.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ThirdParty.Models.GoldDeluxe
{
    /// <summary>
    /// Gold Deluxe game entity.
    /// </summary>
    public class GoldDeluxeStatus
    {
        public int CustId { get; set; }

        public string Username { get; set; }

        public bool Enable { get; set; }

        public bool DownlineEnable { get; set; }
    }
}