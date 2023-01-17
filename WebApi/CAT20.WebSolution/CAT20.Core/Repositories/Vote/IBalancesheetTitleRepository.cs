using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;

namespace CAT20.Core.Repositories.Vote
{
    public interface IBalancesheetTitleRepository : IRepository<BalancesheetTitle>
    {
        Task<IEnumerable<BalancesheetTitle>> GetAllWithBalancesheetTitleAsync();
        Task<BalancesheetTitle> GetWithBalancesheetTitleByIdAsync(int id);
        Task<IEnumerable<BalancesheetTitle>> GetAllWithBalancesheetTitleByBalancesheetTitleIdAsync(int Id);
        Task<IEnumerable<BalancesheetTitle>> GetAllWithBalancesheetTitleBySabhaIdAsync(int Id);
    }
}
