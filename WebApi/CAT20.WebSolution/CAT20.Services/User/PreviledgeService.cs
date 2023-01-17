using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.User;
using CAT20.Core.Services.User;

namespace CAT20.Services.User
{
    public class PreviledgeService : IPreviledgeService
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public PreviledgeService(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Previledge> CreatePreviledge(Previledge newPreviledge)
        {
            await _unitOfWork.Previledges
                .AddAsync(newPreviledge);
            await _unitOfWork.CommitAsync();

            return newPreviledge;
        }
        public async Task DeletePreviledge(Previledge previledge)
        {
            _unitOfWork.Previledges.Remove(previledge);

            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Previledge>> GetAllPreviledges()
        {
            return await _unitOfWork.Previledges.GetAllAsync();
        }
        public async Task<Previledge> GetPreviledgeById(int id)
        {
            return await _unitOfWork.Previledges.GetByIdAsync(id);
        }
        public async Task UpdatePreviledge(Previledge previledgeToBeUpdated, Previledge previledge)
        {
            //previledgeToBeUpdated.Name = previledge.t;

            await _unitOfWork.CommitAsync();
        }
    }
}