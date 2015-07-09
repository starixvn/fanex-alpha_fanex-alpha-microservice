namespace Fanex.Razorbill.Module.MemberInformation.Criteria.Commission
{
    using Fanex.NAP.Framework.Data;

    /// <summary>
    /// Get Commission by Bet type criteria.
    /// </summary>
    public class GetCommissionHintCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "Age_MemCommission_SelBettype";
        }
    }
}
