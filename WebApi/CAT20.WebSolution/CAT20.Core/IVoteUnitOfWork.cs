using CAT20.Core.Models.Vote;
using CAT20.Core.Repositories.Common;
using CAT20.Core.Repositories.Vote;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CAT20.Core
{
    public interface IVoteUnitOfWork : IDisposable
    {
        
        IAccountBalanceDetailRepository AccountBalanceDetails { get; }
        IAccountDetailRepository AccountDetails { get; }
        IBalancesheetBalanceRepository BalancesheetBalances { get; }
        IBalancesheetSubtitleRepository BalancesheetSubtitles { get; }
        IBalancesheetTitleRepository BalancesheetTitles { get; }
        IProjectRepository Projects { get; }
        ISubProjectRepository SubProjects { get; }
        IIncomeSubtitleRepository IncomeSubtitles { get; }
        IIncomeTitleRepository IncomeTitles { get; }
        IVoteAllocationRepository VoteAllocations { get; }
        IVoteDetailRepository VoteDetails { get; }
        IProgrammeRepository Programmes { get; }
        IAuditLogRepository AuditLogs { get; }

        Task<int> CommitAsync();
    }
}
