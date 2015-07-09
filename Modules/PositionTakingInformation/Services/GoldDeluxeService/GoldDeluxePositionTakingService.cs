namespace Fanex.Razorbill.Module.PositionTaking.Services.GoldDeluxeService
{
    using System.Collections.Generic;
    using Fanex.Razorbill.Module.PositionTaking.Criteria.GoldDeluxeCriteria;
    using Fanex.Razorbill.Module.PositionTaking.Entities.GoldDeluxeEntities;
    using Fanex.Razorbill.Module.PositionTaking.Repositories.GoldDeluxeRepository;

    public class GoldDeluxePositionTakingService : IGoldDeluxePositionTakingService
    {
        private readonly IGoldDeluxePositionTakingRepository _goldDeluxeRepository;

        public GoldDeluxePositionTakingService(IGoldDeluxePositionTakingRepository goldDeluxeRepository = null)
        {
            _goldDeluxeRepository = goldDeluxeRepository ?? new GoldDeluxePositionTakingRepository();
        }

        public IList<GoldDeluxeEntity> GetGoldDeluxePositionTaking(GetGoldDeluxePositionTakingCriteria criteria)
        {
            return _goldDeluxeRepository.GetGoldDeluxePositionTaking(criteria);
        }
    }
}