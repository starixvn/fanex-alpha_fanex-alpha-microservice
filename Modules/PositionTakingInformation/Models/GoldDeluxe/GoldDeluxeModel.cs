namespace Fanex.Razorbill.Module.PositionTaking.Models.GoldDeluxe
{
    using System.Collections.Generic;
    using Fanex.Razorbill.Module.PositionTaking.Entities.GoldDeluxeEntities;

    public class GoldDeluxeModel
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public string[] Wildcards { get; set; }

        public string DownlineLink { get; set; }

        public IList<GoldDeluxeEntity> GoldDeluxes { get; set; }
    }
}