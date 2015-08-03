namespace Fanex.Alpha.MicroServices.Logs.Repositories
{
    using Fanex.Alpha.MicroServices.Logs.Criteria;
    using Fanex.Data;

    public class LogRepository : ILogRepository
    {
        public void CheckBelongingByUsername(CheckBelongingByUsernameCriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(criteria.GetSpParams());
                
                var outputParams = db.GetOuputParams();
                criteria.CustId = (int)outputParams["custid"];
                criteria.IsSubAcc = (bool)outputParams["issubacc"];
            }
        }
    }
}