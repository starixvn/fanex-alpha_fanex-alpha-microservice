using Fanex.NAP.Framework.Data;

namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class UpdateMessageStatusCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public bool IsViewed { get; set; }

        public override string GetSettingKey()
        {
            return "Age_MessageNoticeUpdStatus";
        }
    }
}