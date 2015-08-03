namespace Fanex.Alpha.MicroServices.Logs.Services
{
    using Fanex.Alpha.MicroServices.Logs.Criteria;
    using Fanex.Alpha.MicroServices.Logs.Repositories;

    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository = null)
        {
            _logRepository = logRepository ?? new LogRepository();
        }

        public bool CheckBelongingByUsername(CheckBelongingByUsernameCriteria criteria)
        {
            _logRepository.CheckBelongingByUsername(criteria);
            return criteria.CustId > 0;
        }
    }
}