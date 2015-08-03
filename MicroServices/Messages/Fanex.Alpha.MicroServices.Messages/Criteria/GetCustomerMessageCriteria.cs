using System;
using Fanex.NAP.Framework.Data;

namespace Fanex.Alpha.MicroServices.Messages.Criteria
{
    public class GetCustomerMessageCriteria : CriteriaBase
    {
        public int TargetId { get; set; }

        public string TargetId2 { get; set; }

        public DateTime LastPostTime { get; set; }

        public int TotalMessage { get; set; }

        public bool IsTest { get; set; }

        public override string GetSettingKey()
        {
            return "Age_CustomerSelMessages";
        }
    }
}