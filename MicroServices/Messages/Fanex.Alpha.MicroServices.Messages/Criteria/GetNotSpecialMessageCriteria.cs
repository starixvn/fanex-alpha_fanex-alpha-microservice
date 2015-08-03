namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class GetNotSpecialMessageCriteria : GetPrivateMessageCriteria
    {
        public override string GetSettingKey()
        {
            return "Dot_Msg_GetNotSpecialMessage";
        }
    }
}