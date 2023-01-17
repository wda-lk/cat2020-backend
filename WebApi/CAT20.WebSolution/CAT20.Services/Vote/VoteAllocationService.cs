using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;
using CAT20.Core.Services.Vote;

namespace CAT20.Services.Vote
{
    public class VoteAllocationService : IVoteAllocationService
    {
        private readonly IVoteUnitOfWork _unitOfWork;
        public VoteAllocationService(IVoteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<VoteAllocation> CreateVoteAllocation(VoteAllocation newVoteAllocation)
        {
            await _unitOfWork.VoteAllocations
                .AddAsync(newVoteAllocation);
            await _unitOfWork.CommitAsync();

            return newVoteAllocation;
        }
        public async Task DeleteVoteAllocation(VoteAllocation voteAllocation)
        {
            voteAllocation.Status = 0;
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<VoteAllocation>> GetAllVoteAllocations()
        {
            return await _unitOfWork.VoteAllocations.GetAllAsync();
        }
        public async Task<VoteAllocation> GetVoteAllocationById(int id)
        {
            return await _unitOfWork.VoteAllocations.GetByIdAsync(id);
        }
        public async Task UpdateVoteAllocation(VoteAllocation voteAllocationToBeUpdated, VoteAllocation voteAllocation)
        {
            //voteAllocationToBeUpdated.Name = voteAllocation.t;

            voteAllocationToBeUpdated.AllocationAmount = voteAllocation.AllocationAmount;
            voteAllocationToBeUpdated.IncomeAmount = voteAllocation.IncomeAmount;

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdAsync(int VoteDetailId)
        {
            return await _unitOfWork.VoteAllocations.GetAllWithVoteAllocationByVoteDetailIdAsync(VoteDetailId);
        }

        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationBySabhaId(int SabhaId)
        {
            return await _unitOfWork.VoteAllocations.GetAllWithVoteAllocationBySabhaIdAsync(SabhaId);
        }

        public async Task<IEnumerable<VoteAllocation>> GetAllWithVoteAllocationByVoteDetailIdSabhaId(int VoteDetailId, int SabhaId)
        {
            return await _unitOfWork.VoteAllocations.GetAllWithVoteAllocationByVoteDetailIdSabhaIdAsync(VoteDetailId, SabhaId);
        }

        public async Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForVoteDetailIdandSabhaIdandYear(int VoteDetailId, int SabhaId, int Year)
        {
            return await _unitOfWork.VoteAllocations.GetAllVoteAllocationsForVoteDetailIdandSabhaIdandYearAsync(VoteDetailId, SabhaId, Year);
        }
        
        public async Task<IEnumerable<VoteAllocation>> GetAllVoteAllocationsForSabhaId( int SabhaId)
        {
            return await _unitOfWork.VoteAllocations.GetAllVoteAllocationsForSabhaIdAsync( SabhaId);
        }

    }
}