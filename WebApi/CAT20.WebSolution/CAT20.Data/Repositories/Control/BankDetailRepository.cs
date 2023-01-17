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
    public class BankDetailRepository : Repository<BankDetail>, IBankDetailRepository
    {
        public BankDetailRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<BankDetail>> GetAllWithBankDetailAsync()
        {
            return await controlDbContext.BankDetails
                .Include(m => m.ID)
                .ToListAsync();
        }

        public async Task<BankDetail> GetWithBankDetailByIdAsync(int id)
        {
            return await controlDbContext.BankDetails
                .Include(m => m.ID)
                .SingleOrDefaultAsync(m => m.ID == id); ;
        }

        public async Task<IEnumerable<BankDetail>> GetAllWithBankDetailByBankDetailIdAsync(int bankDetailId)
        {
            return await controlDbContext.BankDetails
                .Include(m => m.ID)
                .Where(m => m.ID == bankDetailId)
                .ToListAsync();
        }

        private ControlDbContext controlDbContext
        {
            get { return Context as ControlDbContext; }
        }
    }
}