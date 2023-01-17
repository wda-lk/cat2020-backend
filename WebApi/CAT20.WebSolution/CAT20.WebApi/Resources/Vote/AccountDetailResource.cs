using System;
using System.Collections.Generic;

namespace CAT20.WebApi.Resources.Vote
{
    public partial class AccountDetailResource
    {
        //public AccountDetailResource()
        //{
        //    accountBalDetail = new HashSet<AccountBalanceDetailResource>();
        //}

        public int ID { get; set; }
        public string AccountNo { get; set; }
        public string NameSinhala { get; set; }
        public string NameEnglish { get; set; }
        public string NameTamil { get; set; }
        public int? BankID { get; set; }
        public int? Status { get; set; }
        public int? OfficeID { get; set; }

        //public virtual ICollection<AccountBalanceDetailResource> accountBalDetail { get; set; }
    }
}