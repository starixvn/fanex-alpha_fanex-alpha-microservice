namespace Fanex.Razorbill.Module.MemberInformation.Models.Commission
{
    using System.Globalization;

    public class GoldDeluxeCommission
    {
        public int CustomerId { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string UGroup { get; set; }

        public bool Enabled { get; set; }

        public bool Suspended { get; set; }

        public bool Closed { get; set; }

        public decimal Credit { get; set; }

        public string CreditWithFormat
        {
            get
            {
                return FormatNumber(Credit);
            }
        }

        public decimal AgentDiscount { get; set; }

        public string AgentDiscountWithFormat
        {
            get
            {
                return FormatNumber(AgentDiscount);
            }
        }

        public decimal Discount { get; set; }

        public string DiscountWithFormat
        {
            get
            {
                return FormatNumber(Discount);
            }
        }

        public decimal PlayerDiscount { get; set; }

        public string PlayerDiscountWithFormat
        {
            get
            {
                return FormatNumber(PlayerDiscount);
            }
        }

        private string FormatNumber(decimal number)
        {
            return number.ToString("N2", CultureInfo.InvariantCulture);
        }
    }
}
