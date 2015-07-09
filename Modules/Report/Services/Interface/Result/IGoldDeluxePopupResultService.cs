namespace Fanex.Razorbill.Module.Report.Services.Interface.Result
{
    using System.Collections.Generic;
    using Fanex.Result.Core.DTO;

    public interface IGoldDeluxePopupResultService
    {
        string GetPopupResult(long transId, int betType);
    }
}
