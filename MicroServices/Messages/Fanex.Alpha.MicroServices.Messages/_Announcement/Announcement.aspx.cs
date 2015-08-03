using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Resources;
using System.Web.UI;
using System.Xml;
using Fanex.Alpha.MicroServices.Messages.Services;
using Fanex.Razorbill.Module.Common.Services.LimitedCountryAccess;
using Fanex.Razorbill.Security.Configurations;
using Fanex.Razorbill.Security.Entities;
using Fanex.Razorbill.Security.Sessions;
using Sunplus.Agent.Model.BL.Definitions;
using Sunplus.Agent.Model.Entities;
using Sunplus.Agent.Model.Entities.Permission;
using Sunplus.Agent.Utilities;
using Fanex.Alpha.MicroServices.Messages._Announcement;

namespace Sunplus.Agent.UI._MemberInfo.Announcement
{
    public partial class Announcement_Page : Fanex.Age.UI.TplPage
    {
        private readonly IList<long> _showedMessageIds = new List<long>();

        public override void RenderContent(HtmlTextWriter writer)
        {
            string src = string.Empty;
            long id = 0;
            int top = 110, left = 400, width = 400, height = 200;

            string msg = this.GetSettingChangedMsg(out id);

            if (0 == id)
            {
                msg = this.GetAnnouncementMsg(out src, out id, out top, out left, out width, out height);
            }
            ////Other if here...

            if (0 != id)
            {
                writer.Write(this.CreatePopup(id, msg, top, left, width, height, src));
            }
            else
            {
                writer.Write("-");
            }
        }

        public override void ProcessRequest(ref System.Collections.Hashtable p)
        {
            string id = Request["id"];

            if (!string.IsNullOrEmpty(id))
            {
                string[] ids = id.Split(new char[] { ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string element in ids)
                {
                    int i = 0;
                    int.TryParse(element, out i);
                    if (0 == i)
                    {
                        continue;
                    }

                    this._showedMessageIds.Add(i);
                }
            }
        }

        public override object ValidateRequest(System.Collections.Hashtable p)
        {
            // DON'T want Annoucement shows while user is being in Security Page.
            // The NEW flow of Security Code.
            return SecurityCodeConfig.IsActive && SecurityCodeSession.IsRequireSecurityCode ? "-" : null;
        }

        public override object InvokeData(System.Collections.Hashtable p)
        {
            /*UserMessageBO userMessageBO = new UserMessageBO(CurrentUserSession.NetSessionId);
            DataTable dt = userMessageBO.GetPopupMessageStatus();*/

            IMessageService messageService = new MessageService();
            DataTable dt = messageService.GetPopupMessageStatus();

            bool isPositionTakingChanged = false, isBettingLimitChanged = false;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (!dt.Columns.Contains("typeid"))
                    {
                        break;
                    }

                    int typeId = 0;

                    int.TryParse(row["typeid"] + string.Empty, out typeId);
                    ////For Position Taking Changed
                    if (typeId == 1)
                    {
                        isPositionTakingChanged = true;
                    }
                    else if (typeId == 2)
                    {
                        ////For Betting Limit Changed
                        isBettingLimitChanged = true;
                    }
                }
            }

            return new object[] { isPositionTakingChanged, isBettingLimitChanged };
        }

        public long InsertPersonalMsg()
        {
            string currentCulture = CurrentUserSession.Language;
            string[] msgs =
                {
                    this.GetMsgByCulture("en-US"),
                    this.GetMsgByCulture("zh-TW"),
                    this.GetMsgByCulture("zh-CN"),
                    this.GetMsgByCulture("ja-JP"),
                    string.Empty,
                    this.GetMsgByCulture("th-TH"),
                    this.GetMsgByCulture("ko-KR"),
                    string.Empty
                };

            CurrentUserSession.Language = currentCulture;

            /*UserMessageBO userMessageBO = new UserMessageBO(CurrentUserSession.NetSessionId);
            DataTable dt = userMessageBO.InsPersonalMessage(msgs[0], msgs[1], msgs[2], msgs[3], msgs[4], msgs[5],
                                                            msgs[6], msgs[7], 1, false, 0, true);*/

            IMessageService messageService = new MessageService();
            DataTable dt = messageService.AddPersonalMessage(msgs[0], msgs[1], msgs[2], msgs[3], msgs[4], msgs[5],
                                                            msgs[6], msgs[7], 1, false, 0, true);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    /*userMessageBO.InsPersonalMsgTarget((decimal)dt.Rows[0]["messageId"], CurrentUserSession.UserId,
                                                       CurrentUserSession.UserName, false, "0");
                    userMessageBO.UpdateViewedPTMessage(true);*/

                    messageService.AddPersonalMessageTarget((decimal)dt.Rows[0]["messageId"], CurrentUserSession.UserId,
                                                       CurrentUserSession.UserName, false, "0");
                    messageService.UpdateViewedPTMessage(true);
                }
            }

            return (long)(decimal)dt.Rows[0]["messageId"];
        }

        public long InsertPositionTakingChangedMsg()
        {
            string curCulture = CurrentUserSession.Language;
            string[] arrLangMsg =
                {
                    this.GetPositionTakingChangedMsgByCulture("en-US"),
                    this.GetPositionTakingChangedMsgByCulture("zh-TW"),
                    this.GetPositionTakingChangedMsgByCulture("zh-CN"),
                    this.GetPositionTakingChangedMsgByCulture("ja-JP"),
                    string.Empty,
                    this.GetPositionTakingChangedMsgByCulture("th-TH"),
                    this.GetPositionTakingChangedMsgByCulture("ko-KR"),
                    string.Empty
                };
            CurrentUserSession.Language = curCulture;

            /*UserMessageBO userMessageBo = new UserMessageBO(CurrentUserSession.NetSessionId);
            DataTable dt = userMessageBo.InsPersonalMessage(arrLangMsg[0], arrLangMsg[1], arrLangMsg[2], arrLangMsg[3],
                                                            arrLangMsg[4], arrLangMsg[5], arrLangMsg[6], arrLangMsg[7],
                                                            1, false, 0, true);*/

            IMessageService messageService = new MessageService();
            DataTable dt = messageService.AddPersonalMessage(arrLangMsg[0], arrLangMsg[1], arrLangMsg[2], arrLangMsg[3],
                                                            arrLangMsg[4], arrLangMsg[5], arrLangMsg[6], arrLangMsg[7],
                                                            1, false, 0, true);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    /*userMessageBo.InsPersonalMsgTarget((decimal)dt.Rows[0]["messageId"], CurrentUserSession.UserId,
                                                       CurrentUserSession.UserName, false, "0");
                    userMessageBo.UpdateViewedPTMessage(true);*/

                    messageService.AddPersonalMessageTarget((decimal)dt.Rows[0]["messageId"], CurrentUserSession.UserId,
                                                       CurrentUserSession.UserName, false, "0");
                    messageService.UpdateViewedPTMessage(true);
                }
            }

            return (long)(decimal)dt.Rows[0]["messageId"];
        }

        public long InsertBettingLimitChangedMsg()
        {
            string curCulture = CurrentUserSession.Language;
            string[] arrLangMsg =
                {
                    this.GetBettingLimitChangedMsgByCulture("en-US"),
                    this.GetBettingLimitChangedMsgByCulture("zh-TW"),
                    this.GetBettingLimitChangedMsgByCulture("zh-CN"),
                    this.GetBettingLimitChangedMsgByCulture("ja-JP"),
                    string.Empty,
                    this.GetBettingLimitChangedMsgByCulture("th-TH"),
                    this.GetBettingLimitChangedMsgByCulture("ko-KR"),
                    string.Empty
                };
            CurrentUserSession.Language = curCulture;

            /*UserMessageBO userMessageBo = new UserMessageBO(CurrentUserSession.NetSessionId);
            DataTable dt = userMessageBo.InsPersonalMessage(arrLangMsg[0], arrLangMsg[1], arrLangMsg[2], arrLangMsg[3],
                                                            arrLangMsg[4], arrLangMsg[5], arrLangMsg[6], arrLangMsg[7],
                                                            1, false, 0, true);*/
            
            IMessageService messageService = new MessageService();
            DataTable dt = messageService.AddPersonalMessage(arrLangMsg[0], arrLangMsg[1], arrLangMsg[2], arrLangMsg[3],
                                                            arrLangMsg[4], arrLangMsg[5], arrLangMsg[6], arrLangMsg[7],
                                                            1, false, 0, true);
            
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    /*userMessageBo.InsPersonalMsgTarget((decimal)dt.Rows[0]["messageId"], CurrentUserSession.UserId,
                                                       CurrentUserSession.UserName, false, "0");
                    userMessageBo.UpdateViewedPTMessage(true);*/

                    messageService.AddPersonalMessageTarget((decimal)dt.Rows[0]["messageId"], CurrentUserSession.UserId,
                                                       CurrentUserSession.UserName, false, "0");
                    messageService.UpdateViewedPTMessage(true);
                }
            }

            return (long)(decimal)dt.Rows[0]["messageId"];
        }

        private string GetMsgByCulture(string culture)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Resources.Lang));
            return resourceManager.GetString("modifiedMinPTBettingLimitValue", new CultureInfo(culture)).Replace(
                "<br>", " ");
        }

        private string GetPositionTakingChangedMsgByCulture(string culture)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Resources.Lang));
            return resourceManager.GetString("modifiedMinPTValueText", new CultureInfo(culture)).Replace("<br>", " ");
        }

        private string GetBettingLimitChangedMsgByCulture(string culture)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Resources.Lang));
            return resourceManager.GetString("modifiedBettingLimitValue", new CultureInfo(culture)).Replace("<br>", " ");
        }

        private string GetSettingChangedMsg(out long id)
        {
            object[] dts = View as object[];
            bool isPositionTakingChanged = (bool)dts[0];
            bool isBettingLimitChanged = (bool)dts[1];
            string message = string.Empty;
            id = 0;

            ////Show PT and Betting Limit modifying information for Agent customer
            if (isPositionTakingChanged && isBettingLimitChanged)
            {
                message = Resources.Lang.modifiedMinPTBettingLimitValue;
                id = this.InsertPersonalMsg();
            }
            else
            {
                ////Show PT modifying information for Agent customer
                if (isPositionTakingChanged)
                {
                    message = Resources.Lang.modifiedMinPTValueText;
                    id = this.InsertPositionTakingChangedMsg();
                }
                ////Show Betting Limit modifying information for Agent customer
                if (isBettingLimitChanged)
                {
                    message = Resources.Lang.modifiedBettingLimitValue;
                    id = this.InsertBettingLimitChangedMsg();
                }
            }

            return message;
        }

        ////End Setting Changed Message

        private string CreatePopup(long id, string content, int top, int left, int width, int height, string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                AnnouncementText_Template tpl = new AnnouncementText_Template();
                tpl.announcementCookiesId =
                    Encryption.PearsonEncode(CurrentUserSession.UserId.ToString() +
                                             CurrentUserSession.SubAccId.ToString());
                tpl.popUpId = id.ToString();
                tpl.top = top.ToString();
                tpl.left = left.ToString();
                tpl.content = content;
                if (UserSession.Current.Language == "th-TH")
                {
                    tpl.toptitlepopup = "toptitlepopup_TH";
                }
                else if (UserSession.Current.Language == "zh-TW" || UserSession.Current.Language == "zh-CN")
                {
                    tpl.toptitlepopup = "toptitlepopup_TW";
                }
                else if (UserSession.Current.Language == "ko-KR")
                {
                    tpl.toptitlepopup = "toptitlepopup_KO";
                }
                else if (UserSession.Current.Language == "vi-VN")
                {
                    tpl.toptitlepopup = "toptitlepopup_vn";
                }
                else
                {
                    tpl.toptitlepopup = "toptitlepopup";
                }

                return tpl;
            }
            else
            {
                Announcement_Template tpl = new Announcement_Template();

                // Hide Do show not again
                // tpl.HiddenCheckBox = null;
                tpl.announcementCookiesId =
                    Encryption.PearsonEncode(CurrentUserSession.UserId.ToString() +
                                             CurrentUserSession.SubAccId.ToString());
                tpl.popUpId = id.ToString();
                tpl.width = width.ToString();
                tpl.height = height.ToString();
                tpl.top = top.ToString();
                tpl.left = left.ToString();
                tpl.src = source;

                return tpl;
            }
        }

        // Announcement Message
        private string GetAnnouncementMsg(out string source, out long id, out int top, out int left, out int width,
                                          out int height)
        {
            string content = string.Empty;
            source = string.Empty;

            ShowAnnouncementFor789YGroup();

            //new implement 
            id = top = left = width = height = 0;

            CheckToShowAnnouncmentsBySpecialBusinnesRule();

            content = GetAnnouncemntsFromLocalFiles(ref source, ref id, ref top, ref left, ref width, ref height);

            return content;
        }

        private void ShowAnnouncementFor789YGroup()
        {
            // Hard-code for 7y new domains
            string hostName = System.Web.HttpContext.Current.Request.Headers["Host"];

            switch (System.String.Compare(CurrentUserSession.Site, "789y", StringComparison.OrdinalIgnoreCase))
            {
                case 0:
                    if (hostName.Contains("b8ag.com") || hostName.Contains("b88ag.com"))
                        this._showedMessageIds.Add(-5);
                    break;
                default:
                    this._showedMessageIds.Add(-5);
                    break;
            }
        }

        private void CheckToShowAnnouncmentsBySpecialBusinnesRule()
        {
            //Check to show Virtual Sport
            if (!UserPermission.IsShowVirtualSports)
            {
                this._showedMessageIds.Add(-20130404);
                this._showedMessageIds.Add(-20140424);
            }

            //Check to show Bingo
            if (!UserPermission.IsShowBingo || !AppSettings.IsEnableBingo)
            {
                this._showedMessageIds.Add(-4);
            }

            if (!UserPermission.IsShowLiveCasino)
            {
                this._showedMessageIds.Add(-7);
            }

            //Check to show Keno
            ShowKenoAnnouncement();

            //to check show new security code flow
            ShowNewFlowSecurityCodeAnnouncement();

            ShowLimitedCountryAccessAnnouncement();

            ShowGoldDeluxeAnnouncement();
        }

        private void ShowKenoAnnouncement()
        {
            if (!UserPermission.EnableKeno)
            {
                this._showedMessageIds.Add(-2023);
            }
        }

        private void ShowLimitedCountryAccessAnnouncement()
        {
            ILimitedCountryAccessService limitedCountryAccessService = new LimitedCountryAccessService();
            if (!limitedCountryAccessService.ValidCountryAccess())
            {
                this._showedMessageIds.Add(-26071);
            }
        }

        private void ShowNewFlowSecurityCodeAnnouncement()
        {
            ISecurityCodeSession securityCodeSession = CookieLessSessionFactory.SecurityCodeSession;
            SecurityCodeStatus status = (SecurityCodeStatus)securityCodeSession.SecurityCodeResult;

            bool isForceUseSecurityCode = SecurityCodeConfig.IsActive &&
                (securityCodeSession.IsRequireSecurityCode ||
                (status == SecurityCodeStatus.FORCED_CHANGE_SC) ||
                (status == SecurityCodeStatus.PROVIDED_SC_SUCCESS && !securityCodeSession.IsInternal));

            if (!isForceUseSecurityCode ||
                CurrentUserSession.Site.ToLower().ToLower().Equals("789y"))
            {
                this._showedMessageIds.Add(-20140512);
            }
        }

        private void ShowGoldDeluxeAnnouncement()
        {
            var announcementThatShowToUserOfferedGoldDeluxe = -3543501;//redmineid + index [01]
            var announcementThatShowToUserNotOfferedGoldDeluxe = -3543502;//redmineid + index [02]

            // remove announcement if users are not offered Gold Deluxe
            if (!UserPermission.IsShowGoldDeluxeSettingForCredit)
            {
                this._showedMessageIds.Add(announcementThatShowToUserOfferedGoldDeluxe);
                this._showedMessageIds.Add(announcementThatShowToUserNotOfferedGoldDeluxe);
            }
            else
            {
                if (UserPermission.IsShowLiveCasino)
                {
                    this._showedMessageIds.Add(announcementThatShowToUserNotOfferedGoldDeluxe);
                }
                else
                {
                    this._showedMessageIds.Add(announcementThatShowToUserOfferedGoldDeluxe);
                }
            }
        }

        private string GetAnnouncemntsFromLocalFiles(ref string source, ref long id, ref int top, ref int left, ref int width, ref int height)
        {
            var content = string.Empty;
            var xmlPrivateMsg = GetPrivateAnnouncement();
            var xmlCommonMsg = GetCommonAnnouncement();

            JoinTheTwoAnnouncementTypes(xmlPrivateMsg, xmlCommonMsg);

            string language = CurrentUserSession.Language;
            XmlNodeList root = xmlCommonMsg.SelectNodes("FileDB/PopupAnnouncement");

            foreach (XmlNode node in root)
            {
                string nodeIds = node.Attributes["id"].Value;
                long nodeId = 0;
                long.TryParse(nodeIds, out nodeId);
                nodeId = -nodeId;

                // Skip old nodes
                if (0 == nodeId || this._showedMessageIds.Contains(nodeId))
                {
                    continue;
                }

                // to check private message by system
                if (node.Attributes["privatesystem"] != null &&
                    (!node.Attributes["privatesystem"].Value.Equals("*") ||
                    !string.IsNullOrEmpty(node.Attributes["privatesystem"].Value)))
                {
                    if (!node.Attributes["privatesystem"].Value.ToLower().Equals(CurrentUserSession.Site.ToLower()))
                    {
                        continue;
                    }
                }

                //Check expiration
                XmlAttribute startDateAttribute = node.Attributes["startdate"];
                XmlAttribute endDateAttribute = node.Attributes["enddate"];
                XmlAttribute effectDateAttribute = node.Attributes["effectdate"];
                DateTime? startDate = startDateAttribute == null ? (DateTime?)null : Convert.ToDateTime(startDateAttribute.Value);
                DateTime? endDate = endDateAttribute == null ? (DateTime?)null : Convert.ToDateTime(endDateAttribute.Value);
                string effectDate = effectDateAttribute == null ? string.Empty : Fanex.Common.Converter.ToString2(effectDateAttribute.Value);
                DateTime? currentDate = DateTime.Now;

                if (startDate.HasValue)
                {
                    switch (endDate.HasValue)
                    {
                        case true:
                            if (currentDate < startDate || currentDate > endDate) continue;
                            break;
                        case false:
                            if (currentDate < startDate) continue;
                            break;
                    }
                }

                id = nodeId;
                int.TryParse(node.Attributes["top"].Value, out top);
                int.TryParse(node.Attributes["left"].Value, out left);
                int.TryParse(node.Attributes["width"].Value, out width);
                int.TryParse(node.Attributes["height"].Value, out height);

                // Choose one new node
                XmlNodeList choosedNodes = node.SelectNodes(language);
                if (choosedNodes.Count == 0)
                {
                    choosedNodes = node.SelectNodes("en-US");
                }

                if (choosedNodes.Count == 0) continue;
                source = choosedNodes[0].Attributes["src"].Value;
                content = choosedNodes[0].InnerXml.Replace("{effectdate}", effectDate);

                break;
            }

            return content;
        }

        private static void JoinTheTwoAnnouncementTypes(XmlDocument xmlPrivateMsg, XmlDocument xmlCommonMsg)
        {
            if (xmlPrivateMsg.DocumentElement != null)
            {
                foreach (XmlNode childNode in xmlPrivateMsg.DocumentElement.ChildNodes)
                {
                    var newNode = xmlCommonMsg.ImportNode(childNode, true);
                    if (xmlCommonMsg.DocumentElement != null)
                    {
                        xmlCommonMsg.DocumentElement.AppendChild(newNode);
                    }
                }
            }
        }

        private XmlDocument GetPrivateAnnouncement()
        {
            string pathToPrivateMsg = "Resources/PopupAdAgentNeutral.xml";
            if (CurrentUserSession.IsSuper)
            {
                pathToPrivateMsg = "Resources/PopupAdSuperNeutral.xml";
            }
            else if (CurrentUserSession.IsMaster)
            {
                pathToPrivateMsg = "Resources/PopupAdMasterNeutral.xml";
            }

            var xmlPrivateMsg = new XmlDocument();
            xmlPrivateMsg.Load(Server.MapPath(pathToPrivateMsg));

            return xmlPrivateMsg;
        }

        private XmlDocument GetCommonAnnouncement()
        {
            string pathToCommonMsg = Server.MapPath("Resources/PopupAdCommon.xml");

            var xmlCommonMsg = new XmlDocument();
            xmlCommonMsg.Load(pathToCommonMsg);

            return xmlCommonMsg;
        }
    }
}