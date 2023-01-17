using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;
using CAT20.Core.Services.Vote;

namespace CAT20.Services.Vote
{
    public class BalancesheetTitleService : IBalancesheetTitleService
    {
        private readonly IVoteUnitOfWork _unitOfWork;
        public BalancesheetTitleService(IVoteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BalancesheetTitle> CreateBalancesheetTitle(BalancesheetTitle newBalancesheetTitle)
        {
            await _unitOfWork.BalancesheetTitles
                .AddAsync(newBalancesheetTitle);
            await _unitOfWork.CommitAsync();

            return newBalancesheetTitle;
        }
        public async Task DeleteBalancesheetTitle(BalancesheetTitle balancesheetTitle)
        {
            balancesheetTitle.Status = 0;
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<BalancesheetTitle>> GetAllBalancesheetTitles()
        {
            return await _unitOfWork.BalancesheetTitles.GetAllAsync();
        }
        public async Task<BalancesheetTitle> GetBalancesheetTitleById(int id)
        {
            return await _unitOfWork.BalancesheetTitles.GetByIdAsync(id);
        }
        public async Task UpdateBalancesheetTitle(BalancesheetTitle balancesheetTitleToBeUpdated, BalancesheetTitle balancesheetTitle)
        {
            balancesheetTitleToBeUpdated.NameSinhala = balancesheetTitle.NameSinhala;
            balancesheetTitleToBeUpdated.NameTamil = balancesheetTitle.NameTamil;
            balancesheetTitleToBeUpdated.NameEnglish = balancesheetTitle.NameEnglish;
            balancesheetTitleToBeUpdated.Code = balancesheetTitle.Code;
            balancesheetTitleToBeUpdated.Balpath = balancesheetTitle.Balpath;
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<BalancesheetTitle>> GetAllWithBalancesheetTitleByBalancesheetTitleId(int Id)
        {
            return await _unitOfWork.BalancesheetTitles.GetAllWithBalancesheetTitleByBalancesheetTitleIdAsync(Id);
        }

        public async Task<IEnumerable<BalancesheetTitle>> GetAllBalancesheetTitleBySabhaId(int Id)
        {
            return await _unitOfWork.BalancesheetTitles.GetAllWithBalancesheetTitleBySabhaIdAsync(Id);
        }
        
    }
}