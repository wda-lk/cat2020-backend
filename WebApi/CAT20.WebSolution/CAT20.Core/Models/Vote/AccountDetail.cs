using System;
using System.Collections.Generic;

namespace CAT20.Core.Models.Vote
{
    public partial class AccountDetail
    {
        public AccountDetail()
        {
            accountBalDetail = new HashSet<AccountBalanceDetail>();
        }

        public int ID { get; set; }
        public string AccountNo { get; set; }
        public string NameSinhala { get; set; }
        public string NameEnglish { get; set; }
        public string NameTamil { get; set; }
        public int? BankID { get; set; }
        public int? Status { get; set; }
        public int? OfficeID { get; set; }

        public virtual ICollection<AccountBalanceDetail> accountBalDetail { get; set; }
    }
}