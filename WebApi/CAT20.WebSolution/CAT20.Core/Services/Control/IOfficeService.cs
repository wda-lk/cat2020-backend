using CAT20.Core.Models.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Services.Control
{
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetAllOffices();
        Task<Office> GetOfficeById(int id);
        Task<Office> CreateOffice(Office newOffice);
        Task UpdateOffice(Office officeToBeUpdated, Office office);
        Task DeleteOffice(Office office);
    }
}

