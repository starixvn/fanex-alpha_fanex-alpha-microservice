namespace Fanex.Razorbill.Module.MemberInformation.Repositories.Commission
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Fanex.Common;
    using Fanex.Data;
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.Common.Helpers;
    using Fanex.Razorbill.Module.MemberInformation.Models.Commission;

    public class CommissionRepository : ICommissionRepository
    {
        public IEnumerable<CommissionHint> GetCommissionHint(ICriteria criteria)
        {
            IList<CommissionHint> hints = new List<CommissionHint>();
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hints.Add(new CommissionHint
                        {
                            CommissionId = Converter.ToInt(reader["CommId"]),
                            Bettypes = Converter.ToString2(reader["typeid"])
                                .Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(s => CacheRemotingRef.GetBettype(s))
                                .ToList()
                        });
                    }
                }
            }

            return hints;
        }
        
        public IList<CustomerModel> GetDownlineList(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    IList<CustomerModel> downlineList = new List<CustomerModel>();

                    while (reader.Read())
                    {
                        downlineList.Add(ParseCustomerModel(reader));
                    }

                    return downlineList;
                }
            }
        }

        public IEnumerable<GoldDeluxeCommission> GetGoldDeluxeCommission(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var reader = db.ExecuteReader(criteria.GetSpParams()))
                {
                    IList<GoldDeluxeCommission> commissions = new List<GoldDeluxeCommission>();
                    
                    while (reader.Read())
                    {
                        commissions.Add(ParseCommissionModel(reader));
                    }

                    return commissions;
                }
            }
        }

        private CustomerModel ParseCustomerModel(IDataReader reader)
        {
            return new CustomerModel
            {
                Id = Converter.ToInt(reader["custid"]),
                Name = Converter.ToString2(reader["username"])
            };
        }

        private GoldDeluxeCommission ParseCommissionModel(IDataReader reader)
        {
            return new GoldDeluxeCommission
            {
                CustomerId = Converter.ToInt(reader["custid"]),
                Username = Converter.ToString2(reader["username"]),
                Firstname = Converter.ToString2(reader["firstname"]),
                Lastname = Converter.ToString2(reader["lastname"]),
                UGroup = Converter.ToString2(reader["ugroup"]),
                Enabled = Converter.ToBool(reader["enabled"]),
                Suspended = Converter.ToBool(reader["suspended"]),
                Closed = Converter.ToBool(reader["closed"]),
                Credit = Converter.ToDecimal(reader["credit"]),
                AgentDiscount = Converter.ToDecimal(reader["adiscount"]),
                Discount = Converter.ToDecimal(reader["discount"]),
                PlayerDiscount = Converter.ToDecimal(reader["playerdiscount"])
            };
        }
    }
}
