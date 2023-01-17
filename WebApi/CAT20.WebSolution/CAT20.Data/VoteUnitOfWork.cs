using CAT20.Core;
using CAT20.Core.Models.Vote;
using CAT20.Core.Repositories.Common;
using CAT20.Core.Repositories.Vote;
using CAT20.Data.Repositories.Common;
using CAT20.Data.Repositories.Vote;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Data
{
    public class VoteUnitOfWork : IVoteUnitOfWork
    {
        private readonly VoteAccDbContext _context;

        
        private ProgrammeRepository _programmeRepository;
        private AccountBalanceDetailRepository _accountBalanceRepository;
        private AccountDetailRepository _accountDetailRepository;
        private BalancesheetBalanceRepository _balancesheetBalanceRepository;
        private BalancesheetSubtitleRepository _balancesheetSubtitleRepository;
        private BalancesheetTitleRepository _balancesheetTitleRepository;
        private ProjectRepository _projectRepository;
        private SubProjectRepository _subProjectRepository;
        private IncomeSubtitleRepository _incomeSubtitleRepository;
        private IncomeTitleRepository _incomeTitleRepository;
        private VoteAllocationRepository _voteAllocationRepository;
        private VoteDetailRepository _voteDetailRepository;
        private AuditLogRepository _auditLogRepository;

        public VoteUnitOfWork(VoteAccDbContext context)
        {
            this._context = context;
        }

        public IProgrammeRepository Programmes => _programmeRepository = _programmeRepository ?? new ProgrammeRepository(_context);
        public IAccountBalanceDetailRepository AccountBalanceDetails => _accountBalanceRepository = _accountBalanceRepository ?? new AccountBalanceDetailRepository(_context);
        public IBalancesheetBalanceRepository BalancesheetBalances => _balancesheetBalanceRepository = _balancesheetBalanceRepository ?? new BalancesheetBalanceRepository(_context);
        public IAccountDetailRepository AccountDetails => _accountDetailRepository = _accountDetailRepository ?? new AccountDetailRepository(_context);
        public IBalancesheetSubtitleRepository BalancesheetSubtitles => _balancesheetSubtitleRepository = _balancesheetSubtitleRepository ?? new BalancesheetSubtitleRepository(_context);
        public IBalancesheetTitleRepository BalancesheetTitles => _balancesheetTitleRepository = _balancesheetTitleRepository ?? new BalancesheetTitleRepository(_context);
        public IProjectRepository Projects => _projectRepository = _projectRepository ?? new ProjectRepository(_context);
        public IIncomeSubtitleRepository IncomeSubtitles => _incomeSubtitleRepository = _incomeSubtitleRepository ?? new IncomeSubtitleRepository(_context);
        public ISubProjectRepository SubProjects => _subProjectRepository = _subProjectRepository ?? new SubProjectRepository(_context);
        public IIncomeTitleRepository IncomeTitles => _incomeTitleRepository = _incomeTitleRepository ?? new IncomeTitleRepository(_context);
        public IVoteAllocationRepository VoteAllocations => _voteAllocationRepository = _voteAllocationRepository ?? new VoteAllocationRepository(_context);
        public IVoteDetailRepository VoteDetails => _voteDetailRepository = _voteDetailRepository ?? new VoteDetailRepository(_context);
        public IAuditLogRepository AuditLogs => _auditLogRepository = _auditLogRepository ?? new AuditLogRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}