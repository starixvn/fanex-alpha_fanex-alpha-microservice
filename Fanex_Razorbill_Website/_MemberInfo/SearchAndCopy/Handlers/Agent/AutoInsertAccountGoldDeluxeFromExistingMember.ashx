
<%@ WebHandler Language="C#" Class="Sunplus.Agent.UI._MemberInfo.SearchAndCopy.Handlers.Agent.AutoInsertAccountGoldDeluxeFromExistingMember_Handler" %>

/*
 * Created 20120409@Jeff - auto insert account from exist
 * Revision:
 * ?@? - ...
 *
 */

using System;
using System.Web;
using System.Collections;

using DAL;
using BLL;

using Fanex.Age.UI;
using Fanex.Age.UI.LiveCasino;
using Sunplus.Agent.Model.Entities.Permission;
using Sunplus.Agent.Model.BL.Authorization;
using Sunplus.Agent.Model.BL.AccountInfo;
using Fanex.GoldDeluxe.CoreSetting.Services;
using Sunplus.Agent.Model.Common;
using Fanex.GoldDeluxe.CoreSetting.Enumerations;
using Fanex.GoldDeluxe.CoreSetting.ParameterObjects;
using Fanex.GoldDeluxe.CoreSetting.CommandResult;

namespace Sunplus.Agent.UI._MemberInfo.SearchAndCopy.Handlers.Agent
{
    public class AutoInsertAccountGoldDeluxeFromExistingMember_Handler : TplHandler, System.Web.SessionState.IReadOnlySessionState
    {
        int custId;
        int custIdOld;
        int FromSystem = 2; // Agent
        string errMsg = string.Empty;
        int errCode = (int)ErrorType.Unknown;
        Sunplus.Agent.Model.Entities.CustomerInfo custInfo;

        public override void RenderResult(ref Fanex.Age.UI.JSONData data)
        {
            Result r = View as Result;
            data.AsResult(r);
        }

        public override object InvokeData(System.Collections.Hashtable p)
        {
            SettingService goldDeluxeService = new SettingService();
            
            try
            {
                var accBO = new AccountInfoBO(CurrentUserSession.NetSessionId);
                custInfo = accBO.GetCustInfo(custId);

                ICommandResults result = goldDeluxeService.UpdatePTAndComFromExistingMember(new UpdatePTAndComFromExistingMemberParameters
                    {
                        CustId = custId,
                        FromCustId = custIdOld,
                        UpLineId = CurrentUserSession.CustId,
                        ActorId = CurrentUserSession.CustId,
                        SubAccId = CurrentUserSession.SubAccId,
                        Ip = AgentIPFormat.GetClientIP(),
                        Language = CurrentUserSession.LangKey
                    });
                    
                errCode = result.IsSuccessful ? 0 : 101;
                errMsg = result.IsSuccessful ? "Updated successfully" : "Updated fail";
            }
            catch (Exception ex)
            {
                errCode = 102;
                errMsg = ex.Message;
            }

            return new Result(errCode, errMsg);
        }

        public override void ProcessRequest(ref System.Collections.Hashtable p)
        {
            int.TryParse(Request["custid"], out custId);
            int.TryParse(Request["custidOld"], out custIdOld);
        }

        public override object ValidateRequest(System.Collections.Hashtable p)
        {
            if (custId <= 0 || custIdOld <= 0 ||
                !CurrentUserSession.IsLiveCasinoSync)
            {
                return new Result(errCode, errMsg);
            }

            return null;
        }
    }
}