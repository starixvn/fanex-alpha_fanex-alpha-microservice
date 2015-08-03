namespace Fanex.Alpha.MicroServices.Messages.Utilities
{
    using System.Data;
    using System.Web;
    using DNAide.Core;
    using Sunplus.Agent.Model.Entities;

    public static class Utility
    {
        public static string ThemeDir
        {
            get
            {
                return @"App_Themes/" + UserSession.Current.SiteName;
            }
        }

        public static string RowBgOdd
        {
            get
            {
                if (HttpContext.Current.Session["Tpl_Theme"] != null && HttpContext.Current.Session["Tpl_Theme"].Equals("AgencyV2"))
                {
                    return "#F6F8F9";
                }

                return "#f9f9f7";
            }
        }

        public static string RowBgEven
        {
            get
            {
                if (HttpContext.Current.Session["Tpl_Theme"] != null && HttpContext.Current.Session["Tpl_Theme"].Equals("AgencyV2"))
                {
                    return "#faf9ee";
                }

                return "#ffffff";
            }
        }

        public static string RowBgOver
        {
            get
            {
                if (HttpContext.Current.Session["Tpl_Theme"] != null && HttpContext.Current.Session["Tpl_Theme"].Equals("AgencyV2"))
                {
                    return "#f8ff8d";
                }

                return "#ffff00";
            }
        }

        public static string GetContentMsg(DataRow msg, string language)
        {
            string content = string.Empty;
            switch (language)
            {
                case "en-US":
                    content = CastAide.AsString(msg["Content_en"], string.Empty);
                    break;

                case "th-TH":
                    content = CastAide.AsString(msg["Content_th"], string.Empty);
                    break;

                case "zh-TW":
                    content = CastAide.AsString(msg["Content_ch"], string.Empty);
                    if (string.IsNullOrEmpty(content))
                    {
                        content = CastAide.AsString(msg["Content_cs"], string.Empty);
                    }

                    break;

                case "zh-CN":
                    content = CastAide.AsString(msg["Content_cs"], string.Empty);
                    if (string.IsNullOrEmpty(content))
                    {
                        content = DNAide.Core.CastAide.AsString(msg["Content_ch"], string.Empty);
                    }

                    break;

                case "ja-JP":
                    content = CastAide.AsString(msg["Content_jp"], string.Empty);
                    break;

                case "ko-KR":
                    content = CastAide.AsString(msg["Content_ko"], string.Empty);
                    break;
            }

            if (string.IsNullOrEmpty(content))
            {
                content = CastAide.AsString(msg["Content_en"], string.Empty);
            }

            return content;
        }
    }
}