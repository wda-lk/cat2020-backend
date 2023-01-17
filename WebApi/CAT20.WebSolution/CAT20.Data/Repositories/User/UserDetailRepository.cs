using CAT20.Core.Models.User;
using CAT20.Core.Repositories.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Data.Repositories.User
{
    public class UserDetailRepository : Repository<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<UserDetail>> GetAllWithUserDetailAsync()
        {
            return await userActivityDbContext.UserDetails
                .Include(m => m.ID)
                .ToListAsync();
        }

        public async Task<UserDetail> GetWithUserDetailByIdAsync(int id)
        {
            return await userActivityDbContext.UserDetails
                .Include(m => m.ID)
                .SingleOrDefaultAsync(m => m.ID == id);
        }

        public async Task<UserDetail> GetWithUserDetailByUsernamePasswordAsync(UserDetail userDetail)
        {
            return await userActivityDbContext.UserDetails
                .Where(m => m.Username == userDetail.Username && m.Password == userDetail.Password)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserDetail>> GetAllWithUserDetailByUserDetailIdAsync(int Id)
        {
            return await userActivityDbContext.UserDetails
                .Include(m => m.ID)
                .Where(m => m.ID == Id)
                .ToListAsync();
        }

        public async Task<UserDetail> Authenticate(string username, string password)
        {
            return await userActivityDbContext.UserDetails
                .Where(m => m.Username == username.ToString() && m.Password == password.ToString()).FirstAsync();
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaIdAsync(int sabhaID)
        {
            return await userActivityDbContext.UserDetails.Where(m => m.SabhaID == sabhaID)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetailsForOfficeIdAsync(int Id)
        {
            return await userActivityDbContext.UserDetails.Where(m => m.OfficeID == Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetailsForSabhaIdandOfficeIdAsync(int SabhaId, int OfficeId)
        {
            return await userActivityDbContext.UserDetails.Where(m => m.SabhaID == SabhaId && m.OfficeID == OfficeId)
                .ToListAsync();
        }

        private UserActivityDBContext userActivityDbContext
        {
            get { return Context as UserActivityDBContext; }
        }
    }
}