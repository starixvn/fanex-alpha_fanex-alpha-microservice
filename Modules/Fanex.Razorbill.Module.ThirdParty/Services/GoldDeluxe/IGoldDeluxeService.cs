// --------------------------------------------------------------------------
// <copyright file="IGoldDeluxeService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ThirdParty.Services.GoldDeluxe
{
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.Core.Models;

    public interface IGoldDeluxeService
    {
        Result UpdateStatus(ICriteria criteria);
    }
}