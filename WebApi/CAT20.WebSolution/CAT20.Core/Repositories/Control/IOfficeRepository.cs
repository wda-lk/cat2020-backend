using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Control;

namespace CAT20.Core.Repositories.Control
{
    public interface IOfficeRepository : IRepository<Office>
    {
        Task<IEnumerable<Office>> GetAllWithOfficeAsync();
        Task<Office> GetWithOfficeByIdAsync(int id);
        Task<IEnumerable<Office>> GetAllWithOfficeByOfficeIdAsync(int Id);
    }
}
