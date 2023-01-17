using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;

namespace CAT20.Core.Repositories.Vote
{
    public interface IVoteAllocationRepository : IRepository<VoteAllocation>
    {
        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationAsync();
        Task<VoteAllocation> GetWithVoteAllocationByIdAsync(int id);
        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteAllocationIdAsync(int Id);
        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdAsync(int VoteDetailId);
        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationBySabhaIdAsync(int SabhaId);
        Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdSabhaIdAsync(int VoteDetailId, int SabhaId);
        Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForSabhaIdAsync(int Id);
        Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForVoteDetailIdandSabhaIdandYearAsync(int VoteDetailId, int SabhaId, int Year);
    }
}
