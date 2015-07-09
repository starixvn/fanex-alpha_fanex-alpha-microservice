namespace Fanex.Razorbill.Module.MemberInformation.Models.Commission
{
    using System.Collections.Generic;
    using Fanex.Razorbill.Module.MemberInformation.Resources;

    public class CommissionHint
    {
        public int CommissionId { get; set; }

        public string CommissionName
        {
            get
            {
                if (CommissionId == 1)
                {
                    return MemberInformationLang.Comm1;   
                }

                if (CommissionId == 2)
                {
                    return MemberInformationLang.Comm2;
                }

                return string.Empty;
            }
        }

        public IList<string> Bettypes { get; set; }
    }
}
