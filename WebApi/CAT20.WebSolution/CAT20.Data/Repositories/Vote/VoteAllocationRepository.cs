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
    public class VoteAllocationRepository : Repository<VoteAllocation>, IVoteAllocationRepository
    {
        public VoteAllocationRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationAsync()
        {
            return await voteAccDbContext.VoteAllocations
                .Where(m => m.Status == 1)
                .ToListAsync();
        }

        public async Task<VoteAllocation> GetWithVoteAllocationByIdAsync(int id)
        {
            return await voteAccDbContext.VoteAllocations
                .Where(m => m.Status == 1)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteAllocationIdAsync(int Id)
        {
            return await voteAccDbContext.VoteAllocations
                .Where(m => m.ID == Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdAsync(int VoteDetailId)
        {
            return await voteAccDbContext.VoteAllocations.Where(m => m.VoteDetailID == VoteDetailId && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationBySabhaIdAsync(int SabhaId)
        {
            return await voteAccDbContext.VoteAllocations.Where(m => m.SabhaID == SabhaId && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdSabhaIdAsync(int VoteDetailId, int SabhaId)
        {
            return await voteAccDbContext.VoteAllocations.Where(m => m.VoteDetailID == VoteDetailId && m.SabhaID == SabhaId && m.Status == 1)
                .ToListAsync();
        }
        public async Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForVoteDetailIdandSabhaIdandYearAsync(int VoteDetailId, int SabhaId, int Year)
        {
            return await voteAccDbContext.VoteAllocations.Where(m => m.VoteDetailID == VoteDetailId && m.SabhaID == SabhaId && m.Status == 1 && m.Year==Year)
                .ToListAsync();
        }

        public async Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForSabhaIdAsync(int Id)
        {
            return await voteAccDbContext.VoteAllocations.Where(m => m.SabhaID == Id && m.Status == 1).ToListAsync();
        }

        private VoteAccDbContext voteAccDbContext
        {
            get { return Context as VoteAccDbContext; }
        }
    }
}