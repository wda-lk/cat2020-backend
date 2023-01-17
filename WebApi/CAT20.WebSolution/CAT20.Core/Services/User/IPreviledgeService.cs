using CAT20.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Services.User
{
    public interface IPreviledgeService
    {
        Task<IEnumerable<Previledge>> GetAllPreviledges();
        Task<Previledge> GetPreviledgeById(int id);
        Task<Previledge> CreatePreviledge(Previledge newPreviledge);
        Task UpdatePreviledge(Previledge previledgeToBeUpdated, Previledge previledge);
        Task DeletePreviledge(Previledge previledge);
    }
}

