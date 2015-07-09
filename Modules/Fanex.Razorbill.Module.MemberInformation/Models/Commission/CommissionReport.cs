namespace Fanex.Razorbill.Module.MemberInformation.Models.Commission
{
    using System.Collections.Generic;

    public class CommissionReport
    {
        public IEnumerable<GoldDeluxeCommission> Commissions { get; set; }

        public IEnumerable<CustomerModel> MasterList { get; set; }

        public IEnumerable<CustomerModel> AgentList { get; set; }
    }
}
