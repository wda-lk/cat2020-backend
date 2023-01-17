using CAT20.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Services.User
{
    public interface IUserHasPreviledgeService
    {
        Task<IEnumerable<UserHasPreviledge>> GetAllUserHasPreviledges();
        Task<UserHasPreviledge> GetUserHasPreviledgeById(int id);
        Task<UserHasPreviledge> CreateUserHasPreviledge(UserHasPreviledge newUserHasPreviledge);
        Task UpdateUserHasPreviledge(UserHasPreviledge userHasPreviledgeToBeUpdated, UserHasPreviledge userHasPreviledge);
        Task DeleteUserHasPreviledge(UserHasPreviledge userHasPreviledge);
    }
}

