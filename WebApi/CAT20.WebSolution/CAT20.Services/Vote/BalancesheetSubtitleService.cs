using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;
using CAT20.Core.Services.Vote;

namespace CAT20.Services.Vote
{
    public class BalancesheetSubtitleService : IBalancesheetSubtitleService
    {
        private readonly IVoteUnitOfWork _unitOfWork;
        public BalancesheetSubtitleService(IVoteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BalancesheetSubtitle> CreateBalancesheetSubtitle(BalancesheetSubtitle newBalancesheetSubtitle)
        {
            await _unitOfWork.BalancesheetSubtitles
                .AddAsync(newBalancesheetSubtitle);
            await _unitOfWork.CommitAsync();

            return newBalancesheetSubtitle;
        }
        public async Task DeleteBalancesheetSubtitle(BalancesheetSubtitle balancesheetSubtitle)
        {
            balancesheetSubtitle.Status = 0;
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllBalancesheetSubtitles()
        {
            return await _unitOfWork.BalancesheetSubtitles.GetAllAsync();
        }
        public async Task<BalancesheetSubtitle> GetBalancesheetSubtitleById(int id)
        {
            return await _unitOfWork.BalancesheetSubtitles.GetByIdAsync(id);
        }
        public async Task UpdateBalancesheetSubtitle(BalancesheetSubtitle balancesheetSubtitleToBeUpdated, BalancesheetSubtitle balancesheetSubtitle)
        {
            balancesheetSubtitleToBeUpdated.NameSinhala = balancesheetSubtitle.NameSinhala;
            balancesheetSubtitleToBeUpdated.NameTamil = balancesheetSubtitle.NameTamil;
            balancesheetSubtitleToBeUpdated.NameEnglish = balancesheetSubtitle.NameEnglish;
            balancesheetSubtitleToBeUpdated.Code = balancesheetSubtitle.Code;
            await _unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllWithBalancesheetSubtitleByBalancesheetTitleId(int Id)
        {
            return await _unitOfWork.BalancesheetSubtitles.GetAllWithBalancesheetSubtitleByBalancesheetTitleIdAsync(Id);
        }
        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllWithBalancesheetSubtitleByBalancesheetTitleIdandSabhaId(int BalancesheetTitleId, int SabhaId)
        {
            return await _unitOfWork.BalancesheetSubtitles.GetAllWithBalancesheetSubtitleByBalancesheetTitleIdandSabhaIdAsync(BalancesheetTitleId, SabhaId);
        }

        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllBalancesheetSubtitlesForSabhaId(int SabhaId)
        {
            return await _unitOfWork.BalancesheetSubtitles.GetAllBalancesheetSubtitlesForSabhaIdAsync(SabhaId);
        }

        public async Task<IEnumerable<BalancesheetSubtitle>> GetAllBalancesheetSubtitlesForTitleID(int TitleID)
        {
            return await _unitOfWork.BalancesheetSubtitles.GetAllBalancesheetSubtitlesForTitleIDAsync(TitleID);
        }
        

    }
}