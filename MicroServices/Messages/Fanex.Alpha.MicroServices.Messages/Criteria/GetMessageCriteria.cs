namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class GetMessageCriteria : GetPrivateMessageCriteria
    {
        public override string GetSettingKey()
        {
            return "Dot_Msg_GetMessage";
        }
    }
}