using CAT20.Core;
using CAT20.Core.Models.User;
using CAT20.Core.Repositories.User;
using CAT20.Data.Repositories.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Data
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly UserActivityDBContext _context;


        private PreviledgeRepository _previledgeRepository;
        private UserDetailRepository _userDetailRepository;
        private UserHasPreviledgeRepository _userHasPreviledgeRepository;
        private UserRecoverQuestionRepository _userRecoverQuestionRepository;
        private AuditLogUserRepository _auditLogUserRepository;


        public UserUnitOfWork(UserActivityDBContext context)
        {
            this._context = context;
        }

        public IPreviledgeRepository Previledges => _previledgeRepository = _previledgeRepository ?? new PreviledgeRepository(_context);
        public IUserDetailRepository UserDetails => _userDetailRepository = _userDetailRepository ?? new UserDetailRepository(_context);
        public IUserHasPreviledgeRepository UserHasPreviledges => _userHasPreviledgeRepository = _userHasPreviledgeRepository ?? new UserHasPreviledgeRepository(_context);
        public IUserRecoverQuestionRepository UserRecoverQuestions => _userRecoverQuestionRepository = _userRecoverQuestionRepository ?? new UserRecoverQuestionRepository(_context);
        public IAuditLogUserRepository AuditLogs => _auditLogUserRepository = _auditLogUserRepository ?? new AuditLogUserRepository(_context);


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