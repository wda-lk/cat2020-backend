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
    public class BalancesheetSubtitleRepository : Repository<BalancesheetSubtitle>, IBalancesheetSubtitleRepository
    {
        public BalancesheetSubtitleRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllWithBalancesheetSubtitleAsync()
        {
            return await voteAccDbContext.BalancesheetSubtitles
                .Where(m => m.Status == 1)
                .ToListAsync();
        }

        public async Task<BalancesheetSubtitle> GetWithBalancesheetSubtitleByIdAsync(int id)
        {
            return await voteAccDbContext.BalancesheetSubtitles
                .Where(m => m.Status == 1)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllWithBalancesheetSubtitleByBalancesheetSubtitleIdAsync(int Id)
        {
            return await voteAccDbContext.BalancesheetSubtitles
                .Where(m => m.ID == Id && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllWithBalancesheetSubtitleByBalancesheetTitleIdAsync(int Id)
        {
            return await voteAccDbContext.BalancesheetSubtitles.Where(m => m.BalsheetTitleID == Id && m.Status==1)
                .ToListAsync();
        }
        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllWithBalancesheetSubtitleByBalancesheetTitleIdandSabhaIdAsync(int BalancesheetTitleId, int SabhaId)
        {
            return await voteAccDbContext.BalancesheetSubtitles.Where(m => m.BalsheetTitleID == BalancesheetTitleId && m.SabhaID == SabhaId && m.Status==1)
                .ToListAsync();
        }

        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllBalancesheetSubtitlesForSabhaIdAsync(int Id)
        {
            return await voteAccDbContext.BalancesheetSubtitles.Where(m => m.SabhaID == Id && m.Status == 1).ToListAsync();
        }

        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllBalancesheetSubtitlesForTitleIDAsync(int Id)
        {
            return await voteAccDbContext.BalancesheetSubtitles.Where(m => m.BalsheetTitleID == Id && m.Status == 1).ToListAsync();
        }

        
        private VoteAccDbContext voteAccDbContext
        {
            get { return Context as VoteAccDbContext; }
        }
    }
}