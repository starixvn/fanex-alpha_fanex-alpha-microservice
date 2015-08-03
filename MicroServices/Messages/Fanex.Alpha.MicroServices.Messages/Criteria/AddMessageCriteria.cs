using Fanex.NAP.Framework.Data;

namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class AddMessageCriteria : CriteriaBase
    {
        public int MessageId { get; set; }

        public string Content_EN { get; set; }

        public string Content_CH { get; set; }

        public string Content_CS { get; set; }

        public string Content_JP { get; set; }

        public string Content_IT { get; set; }

        public string Content_TH { get; set; }

        public string Content_KO { get; set; }

        public string Content_ES { get; set; }

        public int MsgType { get; set; }

        public bool IsSticky { get; set; }

        public int Creator { get; set; }

        public string CreatorName { get; set; }

        public bool IsTest { get; set; }

        public int MatchId { get; set; }

        public bool IsBatch { get; set; }

        public int MsgContentsType { get; set; }

        public override string GetSettingKey()
        {
            return "Dot_Msg_SetMessage";
        }
    }
}