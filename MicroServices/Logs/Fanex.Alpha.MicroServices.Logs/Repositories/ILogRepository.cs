namespace Fanex.Alpha.MicroServices.Logs.Repositories
{
    using Fanex.Alpha.MicroServices.Logs.Criteria;

    public interface ILogRepository
    {
        void CheckBelongingByUsername(CheckBelongingByUsernameCriteria criteria);
    }
}
