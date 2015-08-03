namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    using System;
    using Fanex.NAP.Framework.Data;

    public class GetPublicMessageCriteria : CriteriaBase
    {
        public int TargetId { get; set; }

        public string TargetId2 { get; set; }

        public int Special { get; set; }

        public int Record { get; set; }

        public string SDate { get; set; }

        public string EDate { get; set; }

        //public int MatchId { get; set; }

        public override string GetSettingKey()
        {
            return "Dot_Msg_GetPublicMessage";
        }
    }
}