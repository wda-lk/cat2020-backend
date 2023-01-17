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
    public class IncomeTitleRepository : Repository<IncomeTitle>, IIncomeTitleRepository
    {
        public IncomeTitleRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleAsync()
        {
            return await voteAccDbContext.IncomeTitles
                .Where(m => m.Status == 1)
                .ToListAsync();
        }

        public async Task<IncomeTitle> GetWithIncomeTitleByIdAsync(int id)
        {
            return await voteAccDbContext.IncomeTitles
                .Where(m => m.Status == 1)
                .SingleAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByIncomeTitleIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeTitles
                .Where(m => m.ID == Id && m.Status == 1)
                .ToListAsync();
        }

        public async Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeTitles.Where(m => m.ProgrammeID == Id && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeIdandSabhaIdAsync(int ProgrammeId, int SabhaId)
        {
            return await voteAccDbContext.IncomeTitles.Where(m => m.ProgrammeID == ProgrammeId && m.SabhaID == SabhaId && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<IncomeTitle>> GetAllIncomeTitlesForSabhaIdAsync(int Id)
        {
            return await voteAccDbContext.IncomeTitles.Where(m => m.SabhaID == Id && m.Status == 1).ToListAsync();
        }
        private VoteAccDbContext voteAccDbContext
        {
            get { return Context as VoteAccDbContext; }
        }
    }
}