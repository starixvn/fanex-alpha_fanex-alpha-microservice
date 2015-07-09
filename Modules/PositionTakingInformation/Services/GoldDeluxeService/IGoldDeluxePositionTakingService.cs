namespace Fanex.Razorbill.Module.PositionTaking.Services.GoldDeluxeService
{
    using System.Collections.Generic;
    using Fanex.Razorbill.Module.PositionTaking.Criteria.GoldDeluxeCriteria;
    using Fanex.Razorbill.Module.PositionTaking.Entities.GoldDeluxeEntities;

    public interface IGoldDeluxePositionTakingService
    {
        IList<GoldDeluxeEntity> GetGoldDeluxePositionTaking(GetGoldDeluxePositionTakingCriteria criteria);
    }
}