using CAT20.Core.Models.Vote;
using CAT20.Core.Repositories.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CAT20.Core
{
    public interface IUserUnitOfWork : IDisposable
    {

        IPreviledgeRepository Previledges { get; }
        IUserDetailRepository UserDetails { get; }
        IUserHasPreviledgeRepository UserHasPreviledges { get; }
        IUserRecoverQuestionRepository UserRecoverQuestions { get; }
        IAuditLogUserRepository AuditLogs { get; }
       
        Task<int> CommitAsync();
    }
}
