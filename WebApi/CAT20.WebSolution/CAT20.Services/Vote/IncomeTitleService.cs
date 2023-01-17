using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;
using CAT20.Core.Services.Vote;

namespace CAT20.Services.Vote
{
    public class IncomeTitleService : IIncomeTitleService
    {
        private readonly IVoteUnitOfWork _unitOfWork;
        public IncomeTitleService(IVoteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IncomeTitle> CreateIncomeTitle(IncomeTitle newIncomeTitle)
        {
            await _unitOfWork.IncomeTitles
                .AddAsync(newIncomeTitle);
            await _unitOfWork.CommitAsync();

            return newIncomeTitle;
        }
        public async Task DeleteIncomeTitle(IncomeTitle incomeTitle)
        {
            incomeTitle.Status = 0;
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<IncomeTitle>> GetAllIncomeTitles()
        {
            return await _unitOfWork.IncomeTitles.GetAllAsync();
        }
        public async Task<IncomeTitle> GetIncomeTitleById(int id)
        {
            return await _unitOfWork.IncomeTitles.GetByIdAsync(id);
        }
        public async Task UpdateIncomeTitle(IncomeTitle incomeTitleToBeUpdated, IncomeTitle incomeTitle)
        {
            incomeTitleToBeUpdated.NameSinhala = incomeTitle.NameSinhala;
            incomeTitleToBeUpdated.NameTamil = incomeTitle.NameTamil;
            incomeTitleToBeUpdated.NameEnglish = incomeTitle.NameEnglish;
            incomeTitleToBeUpdated.Code = incomeTitle.Code;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeId(int Id)
        {
            return await _unitOfWork.IncomeTitles.GetAllWithIncomeTitleByProgrammeIdAsync(Id);
        }

        public async Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeIdandSabhaId(int ProgrammeId, int SabhaId)
        {
            return await _unitOfWork.IncomeTitles.GetAllWithIncomeTitleByProgrammeIdandSabhaIdAsync(ProgrammeId, SabhaId);
        }

        public async Task<IEnumerable<IncomeTitle>> GetAllIncomeTitlesForSabhaId( int SabhaId)
        {
            return await _unitOfWork.IncomeTitles.GetAllIncomeTitlesForSabhaIdAsync( SabhaId);
        }
    }
}