using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.User;
using Microsoft.VisualBasic;

namespace CAT20.Core.Repositories.User
{
    public interface IUserDetailRepository : IRepository<UserDetail>
    {
        Task<IEnumerable<UserDetail>> GetAllWithUserDetailAsync();
        Task<UserDetail> GetWithUserDetailByIdAsync(int id);
        Task<UserDetail> GetWithUserDetailByUsernamePasswordAsync(UserDetail userDetail);
        Task<IEnumerable<UserDetail>> GetAllWithUserDetailByUserDetailIdAsync(int Id);

        Task<UserDetail> Authenticate(string username, string password);

        Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaIdAsync(int id);
        Task<IEnumerable<UserDetail>> GetAllUserDetailsForOfficeIdAsync(int id);
        Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaIdandOfficeIdAsync(int SabhaId, int OfficeId);
    }
}
