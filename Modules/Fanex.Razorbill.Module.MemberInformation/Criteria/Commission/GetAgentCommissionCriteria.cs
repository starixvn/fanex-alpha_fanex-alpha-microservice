namespace Fanex.Razorbill.Module.MemberInformation.Criteria.Commission
{
    using Fanex.NAP.Framework.Data;

    public class GetAgentCommissionCriteria : CriteriaBase
    {
        public int Recommend { get; set; }

        public override string GetSettingKey()
        {
            return "Age_CustomerSelGDComm_Ag";
        }
    }
}
