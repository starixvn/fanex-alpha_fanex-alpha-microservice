namespace Fanex.Razorbill.Module.MemberInformation.Repositories.Commission
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.MemberInformation.Models.Commission;

    public interface ICommissionRepository
    {
        IEnumerable<CommissionHint> GetCommissionHint(ICriteria criteria);
        
        IList<CustomerModel> GetDownlineList(ICriteria criteria);

        IEnumerable<GoldDeluxeCommission> GetGoldDeluxeCommission(ICriteria criteria);
    }
}
