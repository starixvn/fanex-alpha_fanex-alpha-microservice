namespace Fanex.Razorbill.Module.Report.Repositories.Impl.Result
{
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Data;
    using Fanex.Razorbill.Module.Report.Criteria.Result;
    using Fanex.Razorbill.Module.Report.Repositories.Interface.Result;
    using Fanex.Result.Core.DTO;

    public class GoldDeluxePopupResultDataAccess : IGoldDeluxePopupResultDataAccess
    {
        public IList<GoldDeluxe> GetGoldDeluxePopupResult(GetGoldDeluxePopupResultCriteria criteria)
        {
            int betType = criteria.BetType;
            var goldDeluxes = new List<GoldDeluxe>();

            using (ObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        goldDeluxes.Add(BindGoldDeluxe(reader, betType));
                    }
                }
            }

            return goldDeluxes;
        }

        private GoldDeluxe BindGoldDeluxe(IDataReader reader, int betType)
        {
            return new GoldDeluxe 
            { 
                Bettype = betType,
                Result = reader["TransDesc"].ToString() 
            };
        }
    }
}