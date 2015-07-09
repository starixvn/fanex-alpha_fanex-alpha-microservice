namespace Fanex.Razorbill.Module.PositionTaking.Repositories.GoldDeluxeRepository
{
    using System.Collections.Generic;
    using System.Data;
    using Fanex.Common;
    using Fanex.Data;
    using Fanex.Razorbill.Module.PositionTaking.Criteria.GoldDeluxeCriteria;
    using Fanex.Razorbill.Module.PositionTaking.Entities.GoldDeluxeEntities;

    public class GoldDeluxePositionTakingRepository : IGoldDeluxePositionTakingRepository
    {
        public IList<GoldDeluxeEntity> GetGoldDeluxePositionTaking(GetGoldDeluxePositionTakingCriteria criteria)
        {
            IList<GoldDeluxeEntity> goldDeluxes = new List<GoldDeluxeEntity>();
            
            criteria.Initialize();
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    while (reader.Read())
                    {
                        goldDeluxes.Add(ParseGoldDeluxe(reader, criteria.Wildcards));
                    }
                }

                var outputParams = db.GetOuputParams();
                criteria.TotalPages = Converter.ToInt(outputParams["totalpages"]);
            }

            return goldDeluxes;
        }

        private GoldDeluxeEntity ParseGoldDeluxe(IDataReader reader, string[] wildcards)
        {
            GoldDeluxeEntity goldDeluxe = new GoldDeluxeEntity
            {
                RowNumber = Converter.ToInt(reader["RowNumber"]),
                CustomerId = Converter.ToInt(reader["custid"]),
                Username = Converter.ToString2(reader["username"]),
                Enabled = Converter.ToBool(reader["enabled"]),
                Suspended = Converter.ToBool(reader["suspended"]),
                Closed = Converter.ToBool(reader["closed"])
            };

            int wildcardsLength = wildcards.Length;
            goldDeluxe.PositionTakings = new decimal[wildcardsLength];
            for (int i = 0; i < wildcardsLength; i++)
            {
                goldDeluxe.PositionTakings[i] = Converter.ToDecimal(reader["v255" + wildcards[i] + "positiontaking"]);
            }

            return goldDeluxe;
        }
    }
}
