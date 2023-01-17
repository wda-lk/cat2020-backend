using CAT20.Core.Models.Control;
using CAT20.Core.Models.Vote;
using CAT20.Core.Repositories.Vote;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Data.Repositories.Vote
{
    public class BalancesheetTitleRepository : Repository<BalancesheetTitle>, IBalancesheetTitleRepository
    {
        public BalancesheetTitleRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<BalancesheetTitle>> GetAllWithBalancesheetTitleAsync()
        {
            return await voteAccDbContext.BalancesheetTitles
                .Where(m => m.Status == 1)
                .ToListAsync();
        }

        public async Task<BalancesheetTitle> GetWithBalancesheetTitleByIdAsync(int id)
        {
            return await voteAccDbContext.BalancesheetTitles
                .Where(m => m.Status == 1)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<BalancesheetTitle>> GetAllWithBalancesheetTitleByBalancesheetTitleIdAsync(int Id)
        {
            return await voteAccDbContext.BalancesheetTitles
                .Where(m => m.ID == Id && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<BalancesheetTitle>> GetAllWithBalancesheetTitleBySabhaIdAsync(int SabahId)
        {
            return await voteAccDbContext.BalancesheetTitles.Where(m => m.SabhaID == SabahId && m.Status == 1)
                .ToListAsync();
        }

        private VoteAccDbContext voteAccDbContext
        {
            get { return Context as VoteAccDbContext; }
        }
    }
}