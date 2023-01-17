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
    public class VoteDetailRepository : Repository<VoteDetail>, IVoteDetailRepository
    {
        public VoteDetailRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailAsync()
        {
            return await voteAccDbContext.VoteDetails
                .Where(m => m.Status == 1)
                .ToListAsync();
        }

        public async Task<VoteDetail> GetWithVoteDetailByIdAsync(int id)
        {
            return await voteAccDbContext.VoteDetails
                .Where(m => m.Status == 1)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByVoteDetailIdAsync(int Id)
        {
            return await voteAccDbContext.VoteDetails
                .Where(m => m.ID == Id && m.Status == 1)
                .ToListAsync();
        }

        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailBySabhaIdAsync(int SabhaId)
        {
            return await voteAccDbContext.VoteDetails.Where(m => m.SabhaID == SabhaId && m.Status == 1)
                .ToListAsync();
        }

        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeIdAsync(int ProgrammeId)
        {
            return await voteAccDbContext.VoteDetails.Where(m => m.ProgrammeID == ProgrammeId && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByIncomeSubTitleIdAsync(int IncomeSubtitleId)
        {
            return await voteAccDbContext.VoteDetails.Where(m => m.IncomeSubtitleID == IncomeSubtitleId && m.Status == 1)
                .ToListAsync();
        }

        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeIdandSabhaIdAsync(int ProgrammeId, int SabhaId)
        {
            return await voteAccDbContext.VoteDetails.Where(m => m.ProgrammeID == ProgrammeId && m.SabhaID == SabhaId && m.Status == 1)
                .OrderBy(m => m.VoteOrder.Value)
                .ToListAsync();
        }

        public async Task<IEnumerable<VoteDetail>> GetAllVoteDetailsForSabhaIdAsync(int Id)
        {
            return await voteAccDbContext.VoteDetails.Where(m => m.SabhaID == Id && m.Status == 1).OrderBy(m => m.VoteOrder).ToListAsync();
        }

        private VoteAccDbContext voteAccDbContext
        {
            get { return Context as VoteAccDbContext; }
        }
    }
}