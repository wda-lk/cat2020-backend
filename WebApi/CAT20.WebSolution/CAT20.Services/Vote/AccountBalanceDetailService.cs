using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;
using CAT20.Core.Services.Vote;

namespace CAT20.Services.Vote
{
    public class AccountBalanceDetailService : IAccountBalanceDetailService
    {
        private readonly IVoteUnitOfWork _unitOfWork;
        public AccountBalanceDetailService(IVoteUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AccountBalanceDetail> CreateAccountBalanceDetail(AccountBalanceDetail newAccountBalanceDetail)
        {
            await _unitOfWork.AccountBalanceDetails
                .AddAsync(newAccountBalanceDetail);
            await _unitOfWork.CommitAsync();

            return newAccountBalanceDetail;
        }
        public async Task DeleteAccountBalanceDetail(AccountBalanceDetail accountBalanceDetail)
        {
            //_unitOfWork.AccountBalanceDetails.Remove(accountBalanceDetail);

            //await _unitOfWork.CommitAsync();

            //_unitOfWork.Programmes.Remove(programme);
            accountBalanceDetail.Status = 0;
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<AccountBalanceDetail>> GetAllAccountBalanceDetails()
        {
            return await _unitOfWork.AccountBalanceDetails.GetAllAsync();
        }
        public async Task<AccountBalanceDetail> GetAccountBalanceDetailById(int id)
        {
            return await _unitOfWork.AccountBalanceDetails.GetByIdAsync(id);
        }
        public async Task UpdateAccountBalanceDetail(AccountBalanceDetail accountBalanceDetailToBeUpdated, AccountBalanceDetail accountBalanceDetail)
        {
            //accountBalanceDetailToBeUpdated.Name = accountBalanceDetail.t;

            accountBalanceDetailToBeUpdated.BalanceAmount = accountBalanceDetail.BalanceAmount;
            accountBalanceDetailToBeUpdated.Year = accountBalanceDetail.Year;

            await _unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<AccountBalanceDetail>> GetAllWithAccountBalanceDetailByAccountDetailId(int Id)
        {
            return await _unitOfWork.AccountBalanceDetails.GetAllWithAccountBalanceDetailByAccountDetailIdAsync(Id);
        }

        public async Task<IEnumerable<AccountBalanceDetail>> GetAllWithAccountBalanceDetailBySabhaId(int Id)
        {
            return await _unitOfWork.AccountBalanceDetails.GetAllWithAccountBalanceDetailBySabhaIdAsync(Id);
        }

        public async Task<IEnumerable<AccountBalanceDetail>> GetAllWithAccountBalanceDetailByAccountDetailIdSabhaId(int AccountDetailId, int SabhaId)
        {
            return await _unitOfWork.AccountBalanceDetails.GetAllWithAccountBalanceDetailByAccountDetailIdSabhaIdAsync(AccountDetailId, SabhaId);
        }

        public async Task<IEnumerable<AccountBalanceDetail>> GetAllWithAccountBalanceDetailsBySabhaId( int SabhaId)
        {
            return await _unitOfWork.AccountBalanceDetails.GetAllWithAccountBalanceDetailBySabhaIdAsync(SabhaId);
        }

        public async Task<IEnumerable<AccountBalanceDetail>> GetAllWithAccountBalanceDetailByAccountId(int AccountId)
        {
            return await _unitOfWork.AccountBalanceDetails.GetAllWithAccountBalanceDetailByAccountIdAsync(AccountId);
        }

        
    }
}