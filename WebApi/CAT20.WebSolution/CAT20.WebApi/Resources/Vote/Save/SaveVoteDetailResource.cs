using System;
using System.Collections.Generic;

namespace CAT20.WebApi.Resources.Vote.Save
{
    public partial class SaveVoteDetailResource
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string NameSinhala { get; set; }
        public string NameEnglish { get; set; }
        public string NameTamil { get; set; }
        public int? VoteOrder { get; set; }
        public int ProgrammeID { get; set; }
        public string? ProgrammeNameSinhala { get; set; }
        public string? ProgrammeNameEnglish { get; set; }
        public string? ProgrammeNameTamil { get; set; }
        public string? ProgrammeCode { get; set; }
        public int ProjectID { get; set; }
        public string? ProjectNameSinhala { get; set; }
        public string? ProjectNameEnglish { get; set; }
        public string? ProjectNameTamil { get; set; }
        public string? ProjectCode { get; set; }
        public int SubprojectID { get; set; }
        public string? SubprojectNameSinhala { get; set; }
        public string? SubprojectNameEnglish { get; set; }
        public string? SubprojectNameTamil { get; set; }
        public string? SubprojectCode { get; set; }
        public int IncomeTitleID { get; set; }
        public string? IncomeTitleNameSinhala { get; set; }
        public string? IncomeTitleNameEnglish { get; set; }
        public string? IncomeTitleNameTamil { get; set; }
        public string? IncomeTitleCode { get; set; }
        public int IncomeSubtitleID { get; set; }
        public string? IncomeSubtitleNameSinhala { get; set; }
        public string? IncomeSubtitleNameEnglish { get; set; }
        public string? IncomeSubtitleNameTamil { get; set; }
        public string? IncomeSubtitleCode { get; set; }
        public int? IncomeOrExpense { get; set; }
        public int? VoteOrBal { get; set; }
        public int SabhaID { get; set; }
        public string? SabhaCode { get; set; }
        public int Status { get; set; }
        public int? BalancesheetTitleID { get; set; }
        public int? BalancesheetSubtitleID { get; set; }
    }
}