using System;
using System.Collections.Generic;

namespace CAT20.WebApi.Resources.Vote
{
    public partial class BalancesheetSubtitleResource
    {
        public int ID { get; set; }
        public string NameSinhala { get; set; }
        public string NameEnglish { get; set; }
        public string NameTamil { get; set; }
        public string Code { get; set; }
        public int? BalsheetTitleID { get; set; }
        public string Status { get; set; }
        public int? SabhaID { get; set; }

        //public virtual BalancesheetTitleResource balancesheetTitle { get; set; }
    }
}