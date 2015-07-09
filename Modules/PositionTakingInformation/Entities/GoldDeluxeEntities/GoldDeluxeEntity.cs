namespace Fanex.Razorbill.Module.PositionTaking.Entities.GoldDeluxeEntities
{
    public class GoldDeluxeEntity
    {
        public int RowNumber { get; set; }

        public int CustomerId { get; set; }

        public string Username { get; set; }

        public bool Enabled { get; set; }

        public bool Suspended { get; set; }

        public bool Closed { get; set; }

        public bool DisableGoldDeluxe { get; set; }

        public decimal[] PositionTakings { get; set; }
    }
}