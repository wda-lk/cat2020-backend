using CAT20.Core.Models.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Services.Vote
{
    public interface IIncomeTitleService
    {
        Task<IEnumerable<IncomeTitle>> GetAllIncomeTitles();
        Task<IncomeTitle> GetIncomeTitleById(int id);
        Task<IncomeTitle> CreateIncomeTitle(IncomeTitle newIncomeTitle);
        Task UpdateIncomeTitle(IncomeTitle incomeTitleToBeUpdated, IncomeTitle incomeTitle);
        Task DeleteIncomeTitle(IncomeTitle incomeTitle);

        Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeId(int Id);
        Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeIdandSabhaId(int ProgrammeId, int SabhaId);
        Task<IEnumerable<IncomeTitle>> GetAllIncomeTitlesForSabhaId( int SabhaId);

    }
}

