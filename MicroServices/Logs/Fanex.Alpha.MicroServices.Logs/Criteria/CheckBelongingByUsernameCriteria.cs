namespace Fanex.Alpha.MicroServices.Logs.Criteria
{
    using Fanex.NAP.Framework.Data;

    public class CheckBelongingByUsernameCriteria : CriteriaBase
    {
        public CheckBelongingByUsernameCriteria(int uplineId, string username)
        {
            UplineId = uplineId;
            Username = username;
        }

        public int UplineId { get; set; }

        public int CustId { get; set; }

        public string Username { get; set; }

        public bool IsSubAcc { get; set; }

        public override string GetSettingKey()
        {
            return "Age_CustomerSelCheckBelonging_ByUsername";
        }
    }
}