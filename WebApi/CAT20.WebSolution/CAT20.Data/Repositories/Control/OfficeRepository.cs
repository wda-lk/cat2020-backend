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
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Office>> GetAllWithOfficeAsync()
        {
            return await controlDbContext.Offices
                .Include(m => m.ID)
                .ToListAsync();
        }

        public async Task<Office> GetWithOfficeByIdAsync(int id)
        {
            return await controlDbContext.Offices
                .Include(m => m.ID)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<Office>> GetAllWithOfficeByOfficeIdAsync(int officeId)
        {
            return await controlDbContext.Offices
                .Include(m => m.ID)
                .Where(m => m.ID == officeId)
                .ToListAsync();
        }

        private ControlDbContext controlDbContext
        {
            get { return Context as ControlDbContext; }
        }
    }
}