namespace Fanex.Razorbill.Module.PositionTaking.Repositories.GoldDeluxeRepository
{
    using System.Collections.Generic;
    using Fanex.Razorbill.Module.PositionTaking.Criteria.GoldDeluxeCriteria;
    using Fanex.Razorbill.Module.PositionTaking.Entities.GoldDeluxeEntities;

    public interface IGoldDeluxePositionTakingRepository
    {
        IList<GoldDeluxeEntity> GetGoldDeluxePositionTaking(GetGoldDeluxePositionTakingCriteria criteria);
    }
}
