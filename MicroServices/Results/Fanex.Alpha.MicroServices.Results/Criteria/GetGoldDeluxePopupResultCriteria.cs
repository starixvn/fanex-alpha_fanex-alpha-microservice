namespace Fanex.Razorbill.Module.Report.Criteria.Result
{
    using Fanex.NAP.Framework.Data;

    public class GetGoldDeluxePopupResultCriteria : CriteriaBase
    {
        public long TransId { get; set; }

        [SpParam(Ignored = true)]
        public int BetType { get; set; }

        public override string GetSettingKey()
        {
            return "All_BetList_MatchResultGDSel";
        }
    }
}