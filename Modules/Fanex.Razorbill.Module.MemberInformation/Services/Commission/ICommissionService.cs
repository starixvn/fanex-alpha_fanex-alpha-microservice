namespace Fanex.Razorbill.Module.MemberInformation.Services.Commission
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.MemberInformation.Models.Commission;

    public interface ICommissionService
    {
        IEnumerable<CommissionHint> GetCommissionHint();

        IList<CustomerModel> GetMasterList(int superId);

        IList<CustomerModel> GetAgentList(int masterId);

        CommissionReport GetMemberGoldDeluxeCommission(int agentId);

        CommissionReport GetMasterMemberGoldDeluxeCommission(int master);

        CommissionReport GetSuperMemberGoldDeluxeCommission(int superId);

        CommissionReport GetSelectedMasterMemberGoldDeluxeCommission(int masterId);

        CommissionReport GetMasterMemberGoldDeluxeCommissionWithAllAgents(int masterId);
    }
}
