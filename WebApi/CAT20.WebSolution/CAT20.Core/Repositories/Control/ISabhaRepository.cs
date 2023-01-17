using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Control;

namespace CAT20.Core.Repositories.Control
{
    public interface ISabhaRepository : IRepository<Sabha>
    {
        Task<IEnumerable<Sabha>> GetAllWithSabhaAsync();
        Task<Sabha> GetWithSabhaByIdAsync(int id);
        Task<IEnumerable<Sabha>> GetAllWithSabhaBySabhaIdAsync(int Id);
    }
}
