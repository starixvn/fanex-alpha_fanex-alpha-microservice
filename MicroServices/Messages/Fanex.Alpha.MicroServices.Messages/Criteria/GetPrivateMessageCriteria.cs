namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class GetPrivateMessageCriteria : GetPublicMessageCriteria
    {
        public bool IsTest { get; set; }

        public override string GetSettingKey()
        {
            return "Dot_Msg_GetPrivateMessage";
        }
    }
}