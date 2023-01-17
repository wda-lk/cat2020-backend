using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.User;

namespace CAT20.Core.Repositories.User
{
    public interface IUserHasPreviledgeRepository : IRepository<UserHasPreviledge>
    {
        Task<IEnumerable<UserHasPreviledge>> GetAllWithUserHasPreviledgeAsync();
        Task<UserHasPreviledge> GetWithUserHasPreviledgeByIdAsync(int id);
        Task<IEnumerable<UserHasPreviledge>> GetAllWithUserHasPreviledgeByUserHasPreviledgeIdAsync(int Id);
    }
}
