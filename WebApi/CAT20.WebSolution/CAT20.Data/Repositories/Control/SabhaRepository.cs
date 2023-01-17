using CAT20.Core.Models.Control;
using CAT20.Core.Repositories.Control;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Data.Repositories.Control
{
    public class SabhaRepository : Repository<Sabha>, ISabhaRepository
    {
        public SabhaRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Sabha>> GetAllWithSabhaAsync()
        {
            return await controlDbContext.Sabhas
                .Include(m => m.ID)
                .ToListAsync();
        }

        public async Task<Sabha> GetWithSabhaByIdAsync(int id)
        {
            return await controlDbContext.Sabhas
                .Include(m => m.ID)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<Sabha>> GetAllWithSabhaBySabhaIdAsync(int sabhaId)
        {
            return await controlDbContext.Sabhas
                .Include(m => m.ID)
                .Where(m => m.ID == sabhaId)
                .ToListAsync();
        }

        private ControlDbContext controlDbContext
        {
            get { return Context as ControlDbContext; }
        }
    }
}