namespace Fanex.Razorbill.Module.MemberInformation.Services.Commission
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.MemberInformation.Criteria.Commission;
    using Fanex.Razorbill.Module.MemberInformation.Models.Commission;
    using Fanex.Razorbill.Module.MemberInformation.Repositories.Commission;
    using Fanex.Razorbill.Module.MemberInformation.Resources;

    public class CommissionService : ICommissionService
    {
        private readonly ICommissionRepository _commissionRepository;

        public CommissionService(ICommissionRepository commissionRepository = null)
        {
            _commissionRepository = commissionRepository ?? new CommissionRepository();
        }

        public IEnumerable<CommissionHint> GetCommissionHint()
        {
            ICriteria criteria = new GetCommissionHintCriteria();
            return _commissionRepository.GetCommissionHint(criteria);
        }

        public IList<CustomerModel> GetMasterList(int superId)
        {
            ICriteria criteria = new GetMasterListCriteria { SRecommend = superId };
            return _commissionRepository.GetDownlineList(criteria);
        }

        public IList<CustomerModel> GetAgentList(int masterId)
        {
            ICriteria criteria = new GetAgentListByMasterIdCriteria { MRecommend = masterId };
            return _commissionRepository.GetDownlineList(criteria);
        }

        public CommissionReport GetMemberGoldDeluxeCommission(int agentId)
        {
            ICriteria criteria = new GetAgentCommissionCriteria { Recommend = agentId };
            var memberCommission = _commissionRepository.GetGoldDeluxeCommission(criteria);

            return new CommissionReport 
            {
                Commissions = memberCommission
            };
        }

        public CommissionReport GetMasterMemberGoldDeluxeCommission(int masterId)
        {
            CommissionReport commissionReport = new CommissionReport();

            var agentList = GetAgentList(masterId);
            if (agentList.Count == 0)
            {
                agentList.Add(new CustomerModel { Id = 0, Name = MemberInformationLang.No_Data_Found });
            }
            else
            {
                int firstAgentId = agentList[0].Id;
                commissionReport = GetMemberGoldDeluxeCommission(firstAgentId);
            }

            commissionReport.AgentList = agentList;
            return commissionReport;
        }

        public CommissionReport GetSuperMemberGoldDeluxeCommission(int superId)
        {
            CommissionReport commissionReport = new CommissionReport();

            var masterList = GetMasterList(superId);
            if (masterList.Count == 0)
            {
                masterList.Add(new CustomerModel { Id = 0, Name = MemberInformationLang.No_Data_Found });
                commissionReport.AgentList = commissionReport.MasterList = masterList;
                return commissionReport;
            }

            int firstMasterId = masterList[0].Id;
            var agentList = GetAgentList(firstMasterId);
            if (agentList.Count == 0)
            {
                agentList.Add(new CustomerModel { Id = 0, Name = MemberInformationLang.No_Data_Found });
            }
            else
            {
                agentList.Insert(0, new CustomerModel { Id = 0, Name = MemberInformationLang.AllAgent });
            }

            ICriteria criteria = new GetMasterCommissionCriteria { MRecommend = firstMasterId };
            commissionReport.Commissions = _commissionRepository.GetGoldDeluxeCommission(criteria);

            commissionReport.MasterList = masterList;
            commissionReport.AgentList = agentList;
            return commissionReport;
        }

        public CommissionReport GetSelectedMasterMemberGoldDeluxeCommission(int masterId)
        {
            CommissionReport commissionReport = GetMasterMemberGoldDeluxeCommissionWithAllAgents(masterId);
            var agentList = GetAgentList(masterId);
            if (agentList.Count == 0)
            {
                agentList.Add(new CustomerModel { Id = 0, Name = MemberInformationLang.No_Data_Found });
            }
            else
            {
                agentList.Insert(0, new CustomerModel { Id = 0, Name = MemberInformationLang.AllAgent });
            }

            commissionReport.AgentList = agentList;
            return commissionReport;
        }

        public CommissionReport GetMasterMemberGoldDeluxeCommissionWithAllAgents(int masterId)
        {
            CommissionReport commissionReport = new CommissionReport();

            ICriteria criteria = new GetMasterCommissionCriteria { MRecommend = masterId };
            commissionReport.Commissions = _commissionRepository.GetGoldDeluxeCommission(criteria);

            return commissionReport;
        }
    }
}
