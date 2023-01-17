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
    public class IncomeSubtitleRepository : Repository<IncomeSubtitle>, IIncomeSubtitleRepository
    {
        public IncomeSubtitleRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<IncomeSubtitle>> GetAllWithIncomeSubtitleAsync()
        {
            return await voteAccDbContext.IncomeSubtitles
                .Include(m => m.ID)
                .Where(m => m.Status == 1)
                .ToListAsync();
        }

        public async Task<IncomeSubtitle> GetWithIncomeSubtitleByIdAsync(int id)
        {
            return await voteAccDbContext.IncomeSubtitles
                .Where(m => m.Status == 1)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<IncomeSubtitle>> GetAllWithIncomeSubtitleByIncomeSubtitleIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeSubtitles
                .Include(m => m.ID)
                .Where(m => m.ID == Id && m.Status == 1)
                .ToListAsync();
        }

        public async Task<IEnumerable<IncomeSubtitle>> GetAllWithIncomeSubtitleByIncometitleIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeSubtitles.Where(m => m.IncomeTitleID == Id && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<IncomeSubtitle>> GetAllWithIncomeSubtitleByIncometitleIdSabhaIdAsync(int IncomeTitleId, int SabhaId)
        {
            return await voteAccDbContext.IncomeSubtitles.Where(m => m.IncomeTitleID == IncomeTitleId && m.SabhaID == SabhaId && m.Status == 1)
                .ToListAsync();
        }

        public async Task<IEnumerable<IncomeSubtitle>> GetAllIncomeSubTitlesForSabhaIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeSubtitles.Where(m => m.SabhaID == Id && m.Status == 1).ToListAsync();
        }

        public async Task<IEnumerable<IncomeSubtitle>> GetAllIncomeSubTitlesForTitleIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeSubtitles.Where(m => m.IncomeTitleID == Id && m.Status == 1).ToListAsync();
        }

        public async Task<IEnumerable<IncomeSubtitle>> GetAllIncomeSubTitlesForProgrammeIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeSubtitles.Where(m => m.ProgrammeID == Id && m.Status == 1).ToListAsync();
        }

        private VoteAccDbContext voteAccDbContext
        {
            get { return Context as VoteAccDbContext; }
        }
    }
}