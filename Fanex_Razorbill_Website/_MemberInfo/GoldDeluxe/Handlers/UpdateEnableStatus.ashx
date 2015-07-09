<%@ WebHandler Language="C#" Class="Fanex.Age.UI.LiveCasino.UpdateEnableStatus_Handler" %>
/*
    Created by: Andy
    Description: Handler for processing agent edits [Enable Live Casino] of member
*/
using System;
using System.Web;
using System.Collections.Generic;
using Sunplus.Agent.Model.Entities.Permission;
using System.ComponentModel;
using System.Collections;
using Fanex.Razorbill.Module.ThirdParty.Services.GoldDeluxe;
using Fanex.Razorbill.Module.ThirdParty.Criteria.GoldDeluxe;
using Fanex.Razorbill.Module.ThirdParty.Models.GoldDeluxe;

namespace Fanex.Age.UI.LiveCasino
{
    public class UpdateEnableStatus_Handler : TplHandler, System.Web.SessionState.IReadOnlySessionState
    {
        public override void RenderResult(ref JSONData data)
        {
            var res = View as Fanex.Razorbill.Module.Core.Models.Result;
            data.AsResult(new Result(string.IsNullOrWhiteSpace(res.Message) ? 0 : -1, res.Message), true);
        }

        public override object InvokeData(Hashtable p)
        {
            var controller = new GoldDeluxeService();

            var custId = Convert.ToInt32(Request["custid"]);
            var subAccId = Convert.ToInt32(Request["subAccId"]);
            var enableStatus = Convert.ToBoolean(Request["enable"]);
            var applyDownlines = Convert.ToBoolean(Request["applyDownlines"]);
            var updateCriteria = new UpdateGoldDeluxeStatusCriteria
            {
                CustId = custId,
                SubAccId = subAccId,
                IsEnable = enableStatus,
                ApplyToDownlines = applyDownlines,
                UserId = CurrentUserSession.UserId,
                Language = CurrentUserSession.Language
            };

            return controller.UpdateStatus(updateCriteria);
        }

        public override void ProcessRequest(ref Hashtable p)
        {

        }

        public override object ValidateRequest(Hashtable p)
        {
            var custRoleId = Convert.ToInt32(Request["CustRoleId"]);
            var editorRoleId = Convert.ToInt32(Request["editorRoleId"]);
            var memberRoleId = 1;
            if (!UserPermission.IsShowGoldDeluxeSettingForCredit ||
                (editorRoleId != custRoleId + 1 && custRoleId != memberRoleId))
            {
                return new Fanex.Age.UI.Components.ErrorPage_Page(Resources.Lang.strNotAccessPage);
            }

            if (!CurrentUserSession.SubPageAccess.UpdateAccount || CurrentUserSession.IsInternal)
            {
                return new Fanex.Age.UI.Result(Fanex.Age.UI.ErrorType.AccessDenied, Resources.Lang.lblNotAuthorized);
            }

            return null;
        }
    }
}