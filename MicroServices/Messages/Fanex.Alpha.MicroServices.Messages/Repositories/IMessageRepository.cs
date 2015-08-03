namespace Fanex.Alpha.MicroServices.Messages.Repositories
{
    using System.Data;
    using Fanex.NAP.Framework.Data;

    public interface IMessageRepository
    {
        bool SetReadPrivateMessage(ICriteria criteria);

        DataSet GetMessages(ICriteria criteria);

        DataSet GetPopupMessageStatus(ICriteria criteria);

        DataSet AddMessage(ICriteria criteria);

        void AddMessageTarget(ICriteria criteria);

        void UpdateMessageStatus(ICriteria criteria);

        DataSet GetCustomerMessages(ICriteria criteria);

        void UpdateCustomerMessageToRead(ICriteria criteria);
    }
}
