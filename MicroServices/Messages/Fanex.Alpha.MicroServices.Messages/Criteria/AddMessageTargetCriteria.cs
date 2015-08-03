using Fanex.NAP.Framework.Data;

namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class AddMessageTargetCriteria : CriteriaBase
    {
        public decimal MessageId { get; set; }

        public int TargetId { get; set; }

        public string TargetName { get; set; }

        public bool IsRead { get; set; }

        public string BetTransId { get; set; }

        public override string GetSettingKey()
        {
            return "Dot_Msg_SetUsrMessage";
        }
    }
}