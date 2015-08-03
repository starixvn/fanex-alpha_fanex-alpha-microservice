namespace Fanex.Razorbill.Module.Report.Repositories.Interface.Result
{
    using System.Collections.Generic;
    using Fanex.Razorbill.Module.Report.Criteria.Result;
    using Fanex.Result.Core.DTO;

    public interface IGoldDeluxePopupResultDataAccess
    {
        IList<GoldDeluxe> GetGoldDeluxePopupResult(GetGoldDeluxePopupResultCriteria criteria);
    }
}