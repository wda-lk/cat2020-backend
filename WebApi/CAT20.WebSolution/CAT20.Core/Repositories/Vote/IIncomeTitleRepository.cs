using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Vote;

namespace CAT20.Core.Repositories.Vote
{
    public interface IIncomeTitleRepository : IRepository<IncomeTitle>
    {
        Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleAsync();
        Task<IncomeTitle> GetWithIncomeTitleByIdAsync(int id);
        Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByIncomeTitleIdAsync(int Id);
        Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeIdAsync(int Id);
        Task<IEnumerable<IncomeTitle>> GetAllWithIncomeTitleByProgrammeIdandSabhaIdAsync(int ProgrammeId,int SabhaId);

        Task<IEnumerable<IncomeTitle>> GetAllIncomeTitlesForSabhaIdAsync(int Id);
    }
}
