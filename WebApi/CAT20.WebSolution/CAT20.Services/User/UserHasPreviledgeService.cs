using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.User;
using CAT20.Core.Services.User;

namespace CAT20.Services.User
{
    public class UserHasPreviledgeService : IUserHasPreviledgeService
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public UserHasPreviledgeService(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserHasPreviledge> CreateUserHasPreviledge(UserHasPreviledge newUserHasPreviledge)
        {
            await _unitOfWork.UserHasPreviledges
                .AddAsync(newUserHasPreviledge);
            await _unitOfWork.CommitAsync();

            return newUserHasPreviledge;
        }
        public async Task DeleteUserHasPreviledge(UserHasPreviledge userHasPreviledge)
        {
            _unitOfWork.UserHasPreviledges.Remove(userHasPreviledge);

            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<UserHasPreviledge>> GetAllUserHasPreviledges()
        {
            return await _unitOfWork.UserHasPreviledges.GetAllAsync();
        }
        public async Task<UserHasPreviledge> GetUserHasPreviledgeById(int id)
        {
            return await _unitOfWork.UserHasPreviledges.GetByIdAsync(id);
        }
        public async Task UpdateUserHasPreviledge(UserHasPreviledge userHasPreviledgeToBeUpdated, UserHasPreviledge userHasPreviledge)
        {
            //userHasPreviledgeToBeUpdated.Name = userHasPreviledge.t;

            await _unitOfWork.CommitAsync();
        }
    }
}