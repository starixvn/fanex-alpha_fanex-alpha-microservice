namespace Fanex.Razorbill.Module.MemberInformation.Criteria.Commission
{
    using Fanex.NAP.Framework.Data;

    public class GetMasterCommissionCriteria : CriteriaBase
    {
        public int MRecommend { get; set; }

        public override string GetSettingKey()
        {
            return "Age_CustomerSelGDComm_MAg";
        }
    }
}
