// --------------------------------------------------------------------------
// <copyright file="IGoldDeluxeRepository.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ThirdParty.Repositories.GoldDeluxe
{
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.Core.Models;

    public interface IGoldDeluxeRepository
    {
        Result UpdateStatus(ICriteria criteria);
    }
}
