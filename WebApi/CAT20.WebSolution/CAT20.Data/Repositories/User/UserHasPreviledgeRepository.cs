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
    public class UserHasPreviledgeRepository : Repository<UserHasPreviledge>, IUserHasPreviledgeRepository
    {
        public UserHasPreviledgeRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<UserHasPreviledge>> GetAllWithUserHasPreviledgeAsync()
        {
            return await userActivityDbContext.UserHasPreviledges
                .Include(m => m.ID)
                .ToListAsync();
        }

        public async Task<UserHasPreviledge> GetWithUserHasPreviledgeByIdAsync(int id)
        {
            return await userActivityDbContext.UserHasPreviledges
                .Include(m => m.ID)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<UserHasPreviledge>> GetAllWithUserHasPreviledgeByUserHasPreviledgeIdAsync(int Id)
        {
            return await userActivityDbContext.UserHasPreviledges
                .Include(m => m.ID)
                .Where(m => m.ID == Id)
                .ToListAsync();
        }

        private UserActivityDBContext userActivityDbContext
        {
            get { return Context as UserActivityDBContext; }
        }
    }
}