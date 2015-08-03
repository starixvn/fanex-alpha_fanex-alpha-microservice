namespace Fanex.Alpha.MicroServices.Messages.Services
{
    using System;
    using System.Collections;
    using System.Data;
    using DNAide.Core;
    using Fanex.Alpha.MicroServices.Messages.Criteria;
    using Fanex.Alpha.MicroServices.Messages.Repositories;
    using Fanex.NAP.Framework.Data;
    using Sunplus.Agent.Model.Entities;
    using Sunplus.Agent.Model.BL.Definitions;

    public class MessageService : IMessageService
    {
        private static string[] colNameOfDataTable = new string[] 
        {
            "Content_ch", "System.String",
            "Content_cs", "System.String",
            "Content_en", "System.String",
            "Content_it", "System.String",
            "Content_jp", "System.String",
            "Content_ko", "System.String",
            "Content_th", "System.String",
            "CreateTime", "System.DateTime",
            "CreatorId", "System.Int32",
            "CreatorName", "System.String",
            "IsSticky", "System.Boolean",
            "LastUpdateName", "System.String",
            "LastUpdateTime", "System.DateTime",
            "LastUpdator", "System.Int32",
            "MessageId", "System.Int32",
            "MessageType", "System.Int32",
            "Poster", "System.String",
            "PostTime", "System.DateTime",
            "UserId", "System.Int32",
            "UserName", "System.String"
        };

        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository = null)
        {
            _messageRepository = messageRepository ?? new MessageRepository();
        }

        public bool SetReadPrivateMessage(ICriteria criteria)
        {
            return _messageRepository.SetReadPrivateMessage(criteria);
        }

        public DataTable GetMessages(int targetId, int siteid, int ispublic, int isspecial, int record, string startDate, string endDate, bool IsTest)
        {
            GetPublicMessageCriteria criteria = null;
            string str3 = GetParentSites1(siteid.ToString());
            switch (ispublic)
            {
                case 0:
                    criteria = new GetPrivateMessageCriteria { IsTest = IsTest };
                    break;

                case 1:
                    criteria = new GetPublicMessageCriteria();
                    break;

                default:
                    switch (isspecial)
                    {
                        case 0:
                            criteria = new GetNotSpecialMessageCriteria { IsTest = IsTest };
                            break;

                        case 1:
                            criteria = new GetSpecialMessageCriteria { IsTest = IsTest };
                            break;
                    }

                    if (criteria == null)
                    {
                        criteria = new GetMessageCriteria { IsTest = IsTest };
                    }

                    break;
            }

            criteria.TargetId = targetId;
            criteria.TargetId2 = str3;
            criteria.Special = isspecial;
            criteria.Record = record;
            criteria.SDate = startDate;
            criteria.EDate = endDate;

            DataTable returnTable = CreateDataTable();
            try
            {
                var result = _messageRepository.GetMessages(criteria);
                if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                {
                    CopyDataTable(result.Tables[0], returnTable);
                }
            }
            catch { }

            return returnTable;
        }

        private string GetParentSites1(string SiteId)
        {
            ArrayList list = new ArrayList();
            int num = 0;
            for (int i = SiteId.Length - 1; i >= 0; i--)
            {
                if (SiteId[i] != '0')
                {
                    num = i;
                    break;
                }
            }

            for (int j = 1; j <= num; j++)
            {
                string str = "";
                for (int m = j; m < SiteId.Length; m++)
                {
                    str = str + "0";
                }
                list.Add(SiteId.Remove(j) + str);
            }

            string str2 = "";
            for (int k = 0; k < list.Count; k++)
            {
                str2 = str2 + list[k] + ",";
            }

            return (str2 + SiteId);
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;

            for (int idxElement = 0; idxElement < colNameOfDataTable.Length; idxElement += 2)
            {
                dc = new DataColumn();
                dc.ColumnName = colNameOfDataTable[idxElement];
                dc.DataType = Type.GetType(colNameOfDataTable[idxElement + 1]);
                dt.Columns.Add(dc);
            }

            return dt;
        }

        private void CopyDataTable(DataTable srcTable, DataTable desTable)
        {
            foreach (DataRow row in srcTable.Rows)
            {
                AddDataRow(row, desTable);
            }
        }

        private void AddDataRow(DataRow row, DataTable dtMsg)
        {
            DataRow dr = dtMsg.NewRow();
            bool isBatch = CastAide.AsBoolean(GetValue(row, "IsBatch"), false);
            string bettransId = CastAide.AsString(GetValue(row, "BetTransID"), string.Empty);

            dr["Content_ch"] =
                (isBatch ? CastAide.AsString(GetValue(row, "Content_ch"), string.Empty).Replace("@@", bettransId) : CastAide.AsString(GetValue(row, "Content_ch"), string.Empty));
            dr["Content_cs"] =
                (isBatch ? CastAide.AsString(GetValue(row, "Content_cs"), string.Empty).Replace("@@", bettransId) : CastAide.AsString(GetValue(row, "Content_cs"), string.Empty));
            dr["Content_en"] =
                (isBatch ? CastAide.AsString(GetValue(row, "Content_en"), string.Empty).Replace("@@", bettransId) : CastAide.AsString(GetValue(row, "Content_en"), string.Empty));
            dr["Content_it"] =
                (isBatch ? CastAide.AsString(GetValue(row, "Content_it"), string.Empty).Replace("@@", bettransId) : CastAide.AsString(GetValue(row, "Content_it"), string.Empty));
            dr["Content_jp"] =
                (isBatch ? CastAide.AsString(GetValue(row, "Content_jp"), string.Empty).Replace("@@", bettransId) : CastAide.AsString(GetValue(row, "Content_jp"), string.Empty));
            dr["Content_ko"] =
                (isBatch ? CastAide.AsString(GetValue(row, "Content_ko"), string.Empty).Replace("@@", bettransId) : CastAide.AsString(GetValue(row, "Content_ko"), string.Empty));
            dr["Content_th"] =
                (isBatch ? CastAide.AsString(GetValue(row, "Content_th"), string.Empty).Replace("@@", bettransId) : CastAide.AsString(GetValue(row, "Content_th"), string.Empty));

            dr["CreateTime"] = CastAide.AsDateTime(GetValue(row, "CreateTime"));
            dr["CreatorId"] = CastAide.AsInt32(GetValue(row, "Creator"));
            dr["CreatorName"] = CastAide.AsString(GetValue(row, "CreatorName"));
            dr["IsSticky"] = CastAide.AsBoolean(GetValue(row, "IsSticky"));
            dr["LastUpdateName"] = CastAide.AsString(GetValue(row, "LastUpdateName"));
            dr["LastUpdateTime"] = CastAide.AsDateTime(GetValue(row, "LastUpdateTime"));
            dr["LastUpdator"] = CastAide.AsInt32(GetValue(row, "LastUpdator"));
            dr["MessageId"] = CastAide.AsInt32(GetValue(row, "MessageId"));
            dr["MessageType"] = CastAide.AsInt32(GetValue(row, "MsgType"));
            dr["PostTime"] = CastAide.AsDateTime(GetValue(row, "PostTime"));
            dr["UserId"] = CastAide.AsInt32(GetValue(row, "TargetId"));
            dr["UserName"] = CastAide.AsInt32(GetValue(row, "UserName"));

            dtMsg.Rows.Add(dr);
        }

        private static object GetValue(DataRow row, string fieldname)
        {
            object returnObj = null;
            if (row.Table.Columns.Contains(fieldname) && (!row.IsNull(fieldname)))
            {
                returnObj = row[fieldname];
            }

            return returnObj;
        }

        public DataTable GetPopupMessageStatus()
        {
            var userSession = UserSession.Current;
            int roleId = userSession.RoleId;
            if (roleId != (int)UserTypes.Agent || userSession.AdminId != 0)
            {
                return null;
            }

            var criteria = new GetPopupMessageStatusCriteria { CustId = userSession.CustId };
            var ds = _messageRepository.GetPopupMessageStatus(criteria);
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            return ds.Tables[0];
        }

        public DataTable AddPersonalMessage(string content_en, string content_ch, string content_cs, string content_jp, string content_it, string content_th, string content_ko, string content_es, int msgType, bool isSticky, int matchId, bool isBatch)
        {
            var userSession = UserSession.Current;
            int roleId = userSession.RoleId;
            if (roleId != (int)UserTypes.Agent || userSession.AdminId != 0)
            {
                return null;
            }

            var criteria = new AddMessageCriteria 
            {
                Content_EN = content_en,
                Content_CH = content_ch,
                Content_CS = content_cs,
                Content_JP = content_jp,
                Content_IT = content_it,
                Content_TH = content_th,
                Content_KO = content_ko,
                Content_ES = content_es,
                MsgType = msgType,
                IsSticky = isSticky,
                Creator = userSession.UserId,
                CreatorName = userSession.UserName,
                IsTest = AppSettings.LocalTest,
                MatchId = matchId,
                IsBatch = isBatch,
                MsgContentsType = 1
            };

            var ds = _messageRepository.AddMessage(criteria);
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            return ds.Tables[0];
        }

        public void AddPersonalMessageTarget(decimal messageId, int targetId, string targetName, bool isRead, string betTransId)
        {
            var userSession = UserSession.Current;
            int roleId = userSession.RoleId;
            if (roleId != (int)UserTypes.Agent || userSession.AdminId != 0)
            {
                return;
            }

            var criteria = new AddMessageTargetCriteria 
            {
                MessageId = messageId,
                TargetId = targetId,
                TargetName = targetName,
                IsRead = isRead,
                BetTransId = betTransId
            };

            _messageRepository.AddMessageTarget(criteria);
        }

        public void UpdateViewedPTMessage(bool isViewed)
        {
            var userSession = UserSession.Current;
            int roleId = userSession.RoleId;
            if (roleId != (int)UserTypes.Agent || userSession.AdminId != 0)
            {
                return;
            }

            var criteria = new UpdateMessageStatusCriteria
            {
                CustId = userSession.CustId,
                IsViewed = isViewed
            };

            _messageRepository.UpdateMessageStatus(criteria);
        }

        public DataTable GetCustomerMessages(int targetID, string targetID2, DateTime lastPostTime, int totalMessage, bool isTest)
        {
            var criteria = new GetCustomerMessageCriteria
            {
                TargetId = targetID,
                TargetId2 = targetID2,
                LastPostTime = lastPostTime,
                TotalMessage = totalMessage,
                IsTest = isTest
            };

            var ds = _messageRepository.GetCustomerMessages(criteria);
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
            {
                return null;
            }

            return ds.Tables[0];
        }

        public void SetReadCustomerMessage(int userID, string msgIds)
        {
            var criteria = new UpdateCustomerMessageCriteria
            {
                UserId = userID,
                MessageIds = msgIds
            };

            _messageRepository.SetReadPrivateMessage(criteria);
        }
    }
}