namespace Fanex.Razorbill.Module.Report.Services.Implement.Result
{
    using Fanex.Razorbill.Module.Report.Criteria.Result;
    using Fanex.Razorbill.Module.Report.Repositories.Impl.Result;
    using Fanex.Razorbill.Module.Report.Repositories.Interface.Result;
    using Fanex.Razorbill.Module.Report.Services.Interface.Result;
    using Fanex.Result.Core;
    using Fanex.Result.Core.DTO;
    using Sunplus.Agent.Model.Entities;

    public class GoldDeluxePopupResultService : IGoldDeluxePopupResultService
    {
        private IGoldDeluxePopupResultDataAccess _goldDeluxeDataAccess;

        public GoldDeluxePopupResultService(IGoldDeluxePopupResultDataAccess goldDeluxeDataAccess = null)
        {
            _goldDeluxeDataAccess = goldDeluxeDataAccess ?? new GoldDeluxePopupResultDataAccess();
        }

        public string GetPopupResult(long transId, int betType)
        {
            var criteria = new GetGoldDeluxePopupResultCriteria { TransId = transId, BetType = betType };
            var goldDeluxes = _goldDeluxeDataAccess.GetGoldDeluxePopupResult(criteria);

            return ResultEngine.HtmlParser<GoldDeluxe>(goldDeluxes, GetGoldDeluxeResultPopupSettings());
        }

        private ResultSetting GetGoldDeluxeResultPopupSettings()
        {
            return new ResultSetting
            {
                SportType = SportType.GoldDeluxe,
                IsOutRight = false,
                IsParlayPopUp = false,
                IsPopUp = true,
                LanguageCode = UserSession.Current.Language,
                VisibleMatchCodeIDColumn = false,
                HighlightWinnerTeam = true
            };
        }
    }
}