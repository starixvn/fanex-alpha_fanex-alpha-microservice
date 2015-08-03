namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class GetSpecialMessageCriteria : GetPrivateMessageCriteria
    {
        public override string GetSettingKey()
        {
            return "Dot_Msg_GetSpecialMessage";
        }
    }
}