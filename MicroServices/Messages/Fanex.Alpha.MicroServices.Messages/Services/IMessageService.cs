namespace Fanex.Alpha.MicroServices.Messages.Services
{
    using System;
    using System.Data;
    using Fanex.NAP.Framework.Data;

    public interface IMessageService
    {
        bool SetReadPrivateMessage(ICriteria criteria);

        DataTable GetMessages(int targetId, int siteid, int ispublic, int isspecial, int record, string startDate, string endDate, bool IsTest);

        DataTable GetPopupMessageStatus();

        DataTable AddPersonalMessage(string content_en, string content_ch, string content_cs, string content_jp, string content_it, string content_th, string content_ko, string content_es, int msgType, bool isSticky, int matchId, bool isBatch);

        void AddPersonalMessageTarget(decimal messageId, int targetId, string targetName, bool isRead, string betTransId);

        void UpdateViewedPTMessage(bool isViewed);

        DataTable GetCustomerMessages(int targetID, string targetID2, DateTime lastPostTime, int totalMessage, bool isTest);

        void SetReadCustomerMessage(int userID, string msgIds);
    }
}
