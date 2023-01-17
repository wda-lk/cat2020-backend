using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;
using CAT20.Core.Services.Vote;

namespace CAT20.Services.Vote
{
    public class VoteDetailService : IVoteDetailService
    {
        private readonly IVoteUnitOfWork _unitOfWork;
        public VoteDetailService(IVoteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<VoteDetail> CreateVoteDetail(VoteDetail newVoteDetail)
        {
            await _unitOfWork.VoteDetails
                .AddAsync(newVoteDetail);
            await _unitOfWork.CommitAsync();

            return newVoteDetail;
        }
        public async Task DeleteVoteDetail(VoteDetail voteDetail)
        {
            voteDetail.Status = 0;
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<VoteDetail>> GetAllVoteDetails()
        {
            return await _unitOfWork.VoteDetails.GetAllAsync();
        }
        public async Task<VoteDetail> GetVoteDetailById(int id)
        {
            return await _unitOfWork.VoteDetails.GetByIdAsync(id);
        }
        public async Task UpdateVoteDetail(VoteDetail voteDetailToBeUpdated, VoteDetail voteDetail)
        {
            voteDetailToBeUpdated.Code = voteDetail.Code;
            voteDetailToBeUpdated.NameSinhala = voteDetail.NameSinhala;
            voteDetailToBeUpdated.NameEnglish = voteDetail.NameEnglish;
            voteDetailToBeUpdated.NameTamil = voteDetail.NameTamil;
            voteDetailToBeUpdated.VoteOrder = voteDetail.VoteOrder;
            voteDetailToBeUpdated.ProgrammeID = voteDetail.ProgrammeID;
            voteDetailToBeUpdated.ProgrammeNameSinhala = voteDetail.ProgrammeNameSinhala;
            voteDetailToBeUpdated.ProgrammeNameEnglish = voteDetail.ProgrammeNameEnglish;
            voteDetailToBeUpdated.ProgrammeNameTamil = voteDetail.ProgrammeNameTamil;
            voteDetailToBeUpdated.ProgrammeCode = voteDetail.ProgrammeCode;
            voteDetailToBeUpdated.ProjectID = voteDetail.ProjectID;
            voteDetailToBeUpdated.ProjectNameSinhala = voteDetail.ProjectNameSinhala;
            voteDetailToBeUpdated.ProjectNameEnglish = voteDetail.ProjectNameEnglish;
            voteDetailToBeUpdated.ProjectNameTamil = voteDetail.ProjectNameTamil;
            voteDetailToBeUpdated.ProjectCode = voteDetail.ProjectCode;
            voteDetailToBeUpdated.SubprojectID = voteDetail.SubprojectID;
            voteDetailToBeUpdated.SubprojectNameSinhala = voteDetail.SubprojectNameSinhala;
            voteDetailToBeUpdated.SubprojectNameEnglish = voteDetail.SubprojectNameEnglish;
            voteDetailToBeUpdated.SubprojectNameTamil = voteDetail.SubprojectNameTamil;
            voteDetailToBeUpdated.SubprojectCode = voteDetail.SubprojectCode;
            voteDetailToBeUpdated.IncomeTitleID = voteDetail.IncomeTitleID;
            voteDetailToBeUpdated.IncomeTitleNameSinhala = voteDetail.IncomeTitleNameSinhala;
            voteDetailToBeUpdated.IncomeTitleNameEnglish = voteDetail.IncomeTitleNameEnglish;
            voteDetailToBeUpdated.IncomeTitleNameTamil = voteDetail.IncomeTitleNameTamil;
            voteDetailToBeUpdated.IncomeTitleCode = voteDetail.IncomeTitleCode;
            voteDetailToBeUpdated.IncomeSubtitleID = voteDetail.IncomeSubtitleID;
            voteDetailToBeUpdated.IncomeSubtitleNameSinhala = voteDetail.IncomeSubtitleNameSinhala;
            voteDetailToBeUpdated.IncomeSubtitleNameEnglish = voteDetail.IncomeSubtitleNameEnglish;
            voteDetailToBeUpdated.IncomeSubtitleNameTamil = voteDetail.IncomeSubtitleNameTamil;
            voteDetailToBeUpdated.IncomeSubtitleCode = voteDetail.IncomeSubtitleCode;
            voteDetailToBeUpdated.IncomeOrExpense = voteDetail.IncomeOrExpense;
            voteDetailToBeUpdated.VoteOrBal = voteDetail.IncomeOrExpense;
            voteDetailToBeUpdated.BalancesheetTitleID = voteDetail.BalancesheetTitleID;
            voteDetailToBeUpdated.BalancesheetSubtitleID = voteDetail.BalancesheetSubtitleID;

        await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailBySabhaId(int SabhaId)
        {
            return await _unitOfWork.VoteDetails.GetAllWithVoteDetailBySabhaIdAsync(SabhaId);
        }

        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeId(int ProgrammeId)
        {
            return await _unitOfWork.VoteDetails.GetAllWithVoteDetailByProgrammeIdAsync(ProgrammeId);
        }

        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByIncomeSubTitleId(int IncomeSubTitleId)
        {
            return await _unitOfWork.VoteDetails.GetAllWithVoteDetailByIncomeSubTitleIdAsync(IncomeSubTitleId);
        }
        
        public async Task<IEnumerable<VoteDetail>> GetAllWithVoteDetailByProgrammeIdandSabhaId(int ProgrammeId, int SabhaId)
        {
            return await _unitOfWork.VoteDetails.GetAllWithVoteDetailByProgrammeIdandSabhaIdAsync(ProgrammeId, SabhaId);
        }

        public async Task<IEnumerable<VoteDetail>> GetAllVoteDetailsForSabhaId(int SabhaId)
        {
            return await _unitOfWork.VoteDetails.GetAllVoteDetailsForSabhaIdAsync( SabhaId);
        }
    }
}