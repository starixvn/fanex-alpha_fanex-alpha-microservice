using Fanex.NAP.Framework.Data;

namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class UpdateCustomerMessageCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public string MessageIds { get; set; }

        public override string GetSettingKey()
        {
            return "Age_CustomerUpdMessagesRead";
        }
    }
}