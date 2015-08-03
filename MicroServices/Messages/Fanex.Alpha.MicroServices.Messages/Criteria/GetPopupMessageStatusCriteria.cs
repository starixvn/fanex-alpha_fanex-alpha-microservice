using Fanex.NAP.Framework.Data;

namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class GetPopupMessageStatusCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public override string GetSettingKey()
        {
            return "Age_MessageNoticeSelByCustID";
        }
    }
}