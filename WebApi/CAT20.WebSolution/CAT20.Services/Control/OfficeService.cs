using CAT20.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CAT20.Core.Models.Control;
using CAT20.Core.Services.Control;

namespace CAT20.Services.Control
{
    public class OfficeService : IOfficeService
    {
        private readonly IControlUnitOfWork _unitOfWork;
        public OfficeService(IControlUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Office> CreateOffice(Office newOffice)
        {
            await _unitOfWork.Offices
                .AddAsync(newOffice);
            await _unitOfWork.CommitAsync();

            return newOffice;
        }
        public async Task DeleteOffice(Office office)
        {
            _unitOfWork.Offices.Remove(office);

            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Office>> GetAllOffices()
        {
            return await _unitOfWork.Offices.GetAllAsync();
        }
        public async Task<Office> GetOfficeById(int id)
        {
            return await _unitOfWork.Offices.GetByIdAsync(id);
        }
        public async Task UpdateOffice(Office officeToBeUpdated, Office office)
        {
            //officeToBeUpdated.Name = office.t;

            await _unitOfWork.CommitAsync();
        }
    }
}