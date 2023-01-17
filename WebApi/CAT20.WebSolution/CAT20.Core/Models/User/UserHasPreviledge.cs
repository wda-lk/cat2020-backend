using System;
using System.Collections.Generic;

namespace CAT20.Core.Models.User
{
    public partial class UserHasPreviledge
    {
        public int ID { get; set; }
        public int? UserDetailID { get; set; }
        public int? PreviledgeID { get; set; }
        public int? Status { get; set; }
        public int? SabhaID { get; set; }

        public virtual UserDetail userDetail { get; set; }
        public virtual Previledge previledge { get; set; }
    }
}