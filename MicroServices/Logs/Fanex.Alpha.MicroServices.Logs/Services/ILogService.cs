namespace Fanex.Alpha.MicroServices.Logs.Services
{
    using Fanex.Alpha.MicroServices.Logs.Criteria;

    public interface ILogService
    {
        bool CheckBelongingByUsername(CheckBelongingByUsernameCriteria criteria);
    }
}
