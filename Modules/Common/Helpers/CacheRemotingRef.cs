// --------------------------------------------------------------------------
// <copyright file="CacheRemotingRef.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Kan.Nguyen" date="2015.04.06">Created</change>
// </history>

namespace Fanex.Razorbill.Module.Common.Helpers
{
    using System.Threading;
    using RemotingRef;

    /// <summary>
    /// Cache remote.
    /// </summary>
    public static class CacheRemotingRef
    {
        public static string CurrentTWLanguage
        {
            get
            {
                switch (Thread.CurrentThread.CurrentCulture.Name)
                {
                    case "en-US": return "en";
                    case "zh-TW": return "ch"; // Traditional
                    case "zh-CN": return "cs"; // Simplified
                    case "ja-JP": return "jp";
                    case "th-TH": return "th"; // Thai
                    case "ko-KR": return "ko"; // Korean
                    case "vi-VN": return "vn"; // Vietnamese
                    default: return "en";
                }
            }
        }

        public static string GetBettype(string bettypeId)
        {
            return RefData.GetBetTypeName(bettypeId, CurrentTWLanguage);
        }
    }
}