using CAT20.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Services.User
{
    public interface IUserDetailService
    {
        Task<IEnumerable<UserDetail>> GetAllUserDetails();
        Task<UserDetail> GetUserDetailById(int id);
        Task<UserDetail> CreateUserDetail(UserDetail newUserDetail);
        Task UpdateUserDetail(UserDetail userDetailToBeUpdated, UserDetail userDetail);
        Task DeleteUserDetail(UserDetail userDetail);

        Task<UserDetail> GetUserDetailByUsernamePassword(UserDetail userDetail);
        Task<UserDetail> Authenticate (string username, string password);

        Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaId(int id);
        Task<IEnumerable<UserDetail>> GetAllUserDetailsForOfficeId(int id);
        Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaIdandOfficeId(int SabhaId, int OfficeId);
    }
}

