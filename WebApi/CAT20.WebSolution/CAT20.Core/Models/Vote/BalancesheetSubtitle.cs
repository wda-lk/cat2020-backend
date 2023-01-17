using System;
using System.Collections.Generic;

namespace CAT20.Core.Models.Vote
{
    public partial class BalancesheetSubtitle
    {
        public int ID { get; set; }
        public string NameSinhala { get; set; }
        public string NameEnglish { get; set; }
        public string NameTamil { get; set; }
        public string Code { get; set; }
        public int? BalsheetTitleID { get; set; }
        public int? Status { get; set; }
        public int? SabhaID { get; set; }

        public virtual BalancesheetTitle balancesheetTitle { get; set; }
    }
}