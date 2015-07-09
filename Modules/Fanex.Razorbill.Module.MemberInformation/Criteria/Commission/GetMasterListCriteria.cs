namespace Fanex.Razorbill.Module.MemberInformation.Criteria.Commission
{
    using Fanex.NAP.Framework.Data;

    public class GetMasterListCriteria : CriteriaBase
    {
        public int SRecommend { get; set; }

        public override string GetSettingKey()
        {
            return "Age_CustomerSelMAgentList";
        }
    }
}
