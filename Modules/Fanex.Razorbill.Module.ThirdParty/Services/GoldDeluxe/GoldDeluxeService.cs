// --------------------------------------------------------------------------
// <copyright file="GoldDeluxeService.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ThirdParty.Services.GoldDeluxe
{
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.Core.Models;
    using Fanex.Razorbill.Module.ThirdParty.Repositories.GoldDeluxe;

    /// <summary>
    /// Gold Deluxe service.
    /// </summary>
    public class GoldDeluxeService : IGoldDeluxeService
    {
        private readonly IGoldDeluxeRepository _goldDeluxeRepository;

        public GoldDeluxeService(IGoldDeluxeRepository goldDeluxeRepository = null)
        {
            _goldDeluxeRepository = goldDeluxeRepository ?? new GoldDeluxeRepository();
        }

        public Result UpdateStatus(ICriteria criteria)
        {
            return _goldDeluxeRepository.UpdateStatus(criteria);
        }
    }
}
