// --------------------------------------------------------------------------
// <copyright file="UpdateGoldDeluxeStatusCriteria.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ThirdParty.Criteria.GoldDeluxe
{
    using System.Collections;
    using Fanex.NAP.Framework.Data;
    using Fanex.Razorbill.Module.Common.Helpers;

    /// <summary>
    /// Update Gold Deluxe status criteria.
    /// </summary>
    public class UpdateGoldDeluxeStatusCriteria : CriteriaBase
    {
        public int CustId { get; set; }

        public bool IsEnable { get; set; }

        public bool ApplyToDownlines { get; set; }

        public int UserId { get; set; }

        public int SubAccId { get; set; }

        public string Language { get; set; }

        public string IP
        {
            get
            {
                return IPHelper.CustomerIp();
            }
        }

        public string ErrMsg { get; set; }

        public override string GetSettingKey()
        {
            return "Acc_CustomerUpdDisableGoldDeluxe";
        }

        public override Hashtable GetSpParams()
        {
            Hashtable param = new Hashtable();
            param.Add("userid", UserId);
            param.Add("custid", CustId);
            param.Add("subaccid", SubAccId);
            param.Add("disable", !IsEnable);
            param.Add("language", Language);
            param.Add("ip", IP);
            param.Add("enabledownlines", ApplyToDownlines);
            param.Add("errcode", 0);
            param.Add("errmsg", string.Empty);
            return param;
        }
    }
}
