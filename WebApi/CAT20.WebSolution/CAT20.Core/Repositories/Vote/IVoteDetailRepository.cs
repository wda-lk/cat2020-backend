using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;

namespace CAT20.Core.Repositories.Vote
{
    public interface IVoteDetailRepository : IRepository<VoteDetail>
    {
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailAsync();
        Task<VoteDetail> GetWithVoteDetailByIdAsync(int id);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByVoteDetailIdAsync(int Id);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailBySabhaIdAsync(int SabhaId);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeIdAsync(int ProgrammeId);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByIncomeSubTitleIdAsync(int IncomeSubTitleId);
        Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeIdandSabhaIdAsync(int ProgrammeId, int SabhaId);
        Task<IEnumerable<VoteDetail>> GetAllVoteDetailsForSabhaIdAsync(int Id);
    }
}
