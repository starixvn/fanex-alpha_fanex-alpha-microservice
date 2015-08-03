namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    using Fanex.NAP.Framework.Data;

    public class SetReadPrivateMessageCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public override string GetSettingKey()
        {
            return "Dot_Msg_SetPriMsgRead";
        }
    }
}