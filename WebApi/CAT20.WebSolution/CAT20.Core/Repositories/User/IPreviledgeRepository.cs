using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.User;

namespace CAT20.Core.Repositories.User
{
    public interface IPreviledgeRepository : IRepository<Previledge>
    {
        Task<IEnumerable<Previledge>> GetAllWithPreviledgeAsync();
        Task<Previledge> GetWithPreviledgeByIdAsync(int id);
        Task<IEnumerable<Previledge>> GetAllWithPreviledgeByPreviledgeIdAsync(int Id);
    }
}
