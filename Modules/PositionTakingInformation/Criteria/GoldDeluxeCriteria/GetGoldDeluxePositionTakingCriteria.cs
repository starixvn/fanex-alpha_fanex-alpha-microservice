namespace Fanex.Razorbill.Module.PositionTaking.Criteria.GoldDeluxeCriteria
{
    using System.Collections;
    using Fanex.Razorbill.Module.PositionTaking.Constants;
    using Fanex.Razorbill.Module.PositionTakingInformation.Utils;

    public class GetGoldDeluxePositionTakingCriteria
    {
        private string _settingKey;
        private Hashtable _sqlParams;

        public int CustomerId { get; set; }

        public string Downline { get; set; }

        public string DownlineLink { get; set; }

        public string[] Wildcards { get; private set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public string GetSettingKey()
        {
            return _settingKey;
        }

        public Hashtable GetSpParams()
        {
            return _sqlParams;
        }

        public void Initialize()
        {
            _sqlParams = new Hashtable 
            {
                { "pageindex", PageIndex },
                { "pagesize", PageSize },
                { "totalpages", TotalPages }
            };

            int roleIdInSession = SessionExtension.RoleId;
            if (roleIdInSession == RoleIdConstants.Agent)
            {
                Wildcards = new string[] { "a" };
                _sqlParams.Add("recommend", CustomerId);
                _settingKey = "Age_CustomerSelGDPositionTakingByAg";    
            }
            else if (roleIdInSession == RoleIdConstants.Master)
            {
                Wildcards = new string[] { "m", "a" };
                if (string.IsNullOrEmpty(Downline))
                {
                    DownlineLink = "agent";
                    _sqlParams.Add("mrecommend", CustomerId);
                    _settingKey = "Age_CustomerSelGDPositionTakingByMAg";
                }
                else if (Downline == "agent")
                {
                    _sqlParams.Add("recommend", CustomerId);
                    _settingKey = "Age_CustomerSelGDPositionTakingByAg";
                }
            }
            else if (roleIdInSession == RoleIdConstants.Super)
            {
                if (string.IsNullOrEmpty(Downline))
                {
                    Wildcards = new string[] { "s" };
                    DownlineLink = "master";
                    _sqlParams.Add("srecommend", CustomerId);
                    _settingKey = "Age_CustomerSelGDPositionTakingBySAg";
                }
                else if (Downline == "master")
                {
                    Wildcards = new string[] { "m", "a" };
                    DownlineLink = "agent";
                    _sqlParams.Add("mrecommend", CustomerId);
                    _settingKey = "Age_CustomerSelGDPositionTakingByMAg";
                }
                else if (Downline == "agent")
                {
                    Wildcards = new string[] { "s", "m", "a" };
                    _sqlParams.Add("recommend", CustomerId);
                    _settingKey = "Age_CustomerSelGDPositionTakingByAg";
                }   
            }
        }
    }
}