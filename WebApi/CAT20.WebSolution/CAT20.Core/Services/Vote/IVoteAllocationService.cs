using CAT20.Core.Models.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Services.Vote
{
    public interface IVoteAllocationService
    {
        Task<IEnumerable<VoteAllocation>> GetAllVoteAllocations();
        Task<VoteAllocation> GetVoteAllocationById(int id);
        Task<VoteAllocation> CreateVoteAllocation(VoteAllocation newVoteAllocation);
        Task UpdateVoteAllocation(VoteAllocation voteAllocationToBeUpdated, VoteAllocation voteAllocation);
        Task DeleteVoteAllocation(VoteAllocation voteAllocation);

        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdAsync(int VoteDetailId);
        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationBySabhaId(int SabhaId);
        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdSabhaId(int VoteDetailId, int SabhaId);
        Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForVoteDetailIdandSabhaIdandYear(int VoteDetailId, int SabhaId,int Year);
        Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForSabhaId(int SabhaId);
    }
}

