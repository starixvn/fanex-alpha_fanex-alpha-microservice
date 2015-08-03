namespace Fanex.Alpha.MicroServices.Messages.Repositories
{
    using System.Data;
    using Fanex.Data;
    using Fanex.NAP.Framework.Data;

    public class MessageRepository : IMessageRepository
    {
        public bool SetReadPrivateMessage(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(criteria.GetSpParams());
                return true;
            }
        }

        public DataSet GetMessages(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                return db.ExecuteDataSet(criteria.GetSpParams());
            }
        }

        public DataSet GetPopupMessageStatus(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                return db.ExecuteDataSet(criteria.GetSpParams());
            }
        }

        public DataSet AddMessage(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                return db.ExecuteDataSet(criteria.GetSpParams());
            }
        }

        public void AddMessageTarget(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(criteria.GetSpParams());
            }
        }

        public void UpdateMessageStatus(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(criteria.GetSpParams());
            }
        }

        public DataSet GetCustomerMessages(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                return db.ExecuteDataSet(criteria.GetSpParams());
            }
        }

        public void UpdateCustomerMessageToRead(ICriteria criteria)
        {
            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.ExecuteNonQuery(criteria.GetSpParams());
            }
        }
    }
}