using System;
using System.Collections.Generic;

namespace CAT20.WebApi.Resources.Vote
{
    public partial class VoteAllocationResource
    {
        public int ID { get; set; }
        public int? VoteDetailID { get; set; }
        public double? AllocationAmount { get; set; }
        public double? IncomeAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Year { get; set; }
        public int? Status { get; set; }
        public int? SabhaID { get; set; }
    }
}