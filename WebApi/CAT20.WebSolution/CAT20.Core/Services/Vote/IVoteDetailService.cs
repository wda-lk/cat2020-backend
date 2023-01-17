using CAT20.Core.Models.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Services.Vote
{
    public interface IVoteDetailService
    {
        Task<IEnumerable<VoteDetail>> GetAllVoteDetails();
        Task<VoteDetail> GetVoteDetailById(int id);
        Task<VoteDetail> CreateVoteDetail(VoteDetail newVoteDetail);
        Task UpdateVoteDetail(VoteDetail voteDetailToBeUpdated, VoteDetail voteDetail);
        Task DeleteVoteDetail(VoteDetail voteDetail);

        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailBySabhaId(int SabhaId);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeId(int ProgrammeId);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByIncomeSubTitleId(int IncomeSubTitleId);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeIdandSabhaId(int ProgrammeId, int SabhaId);
        Task<IEnumerable<VoteDetail>> GetAllVoteDetailsForSabhaId(int SabhaId);

    }
}

