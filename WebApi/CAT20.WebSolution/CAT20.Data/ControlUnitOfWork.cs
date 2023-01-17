using CAT20.Core;
using CAT20.Core.Models.Control;
using CAT20.Core.Repositories.Common;
using CAT20.Core.Repositories.Control;
using CAT20.Core.Services.Control;
using CAT20.Data.Repositories.Common;
using CAT20.Data.Repositories.Control;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Data
{
    public class ControlUnitOfWork : IControlUnitOfWork
    {
        private readonly ControlDbContext _context;

        private AppCategoryRepository _appCategoryRepository;
        private BankDetailRepository _bankDetailRepository;
        private DistrictRepository _districtRepository;
        private GenderRepository _genderRepository;
        private LanguageRepository _languageRepository;
        private MonthRepository _monthRepository;
        private OfficeRepository _officeRepository;
        private OfficeTypeRepository _officeTypeRepository;
        private ProvinceRepository _provinceRepository;
        private SabhaRepository _sabhaRepository;
        private SelectedLanguageRepository _selectedLanguageRepository;
        private YearRepository _yearRepository;
        private AuditLogRepository _auditLogRepository;
        private EmailOutBoxRepository _emailOutBoxRepository;
        private EmailConfigurationRepository _configurationRepository;

        public ControlUnitOfWork(ControlDbContext context)
        {
            this._context = context;
        }

        public IAppCategoryRepository AppCategories => _appCategoryRepository = _appCategoryRepository ?? new AppCategoryRepository(_context);
        public IBankDetailRepository BankDetails => _bankDetailRepository = _bankDetailRepository ?? new BankDetailRepository(_context);
        public IDistrictRepository Districts => _districtRepository = _districtRepository ?? new DistrictRepository(_context);
        public IGenderRepository Genders => _genderRepository = _genderRepository ?? new GenderRepository(_context);
        public ILanguageRepository Languages => _languageRepository = _languageRepository ?? new LanguageRepository(_context);
        public IMonthRepository Months => _monthRepository = _monthRepository ?? new MonthRepository(_context);
        public IOfficeRepository Offices => _officeRepository = _officeRepository ?? new OfficeRepository(_context);
        public IOfficeTypeRepository OfficeTypes => _officeTypeRepository = _officeTypeRepository ?? new OfficeTypeRepository(_context);
        public IProvinceRepository Provinces => _provinceRepository = _provinceRepository ?? new ProvinceRepository(_context);
        public ISabhaRepository Sabhas => _sabhaRepository = _sabhaRepository ?? new SabhaRepository(_context);
        public ISelectedLanguageRepository SelectedLanguages => _selectedLanguageRepository = _selectedLanguageRepository ?? new SelectedLanguageRepository(_context);
        public IYearRepository Years => _yearRepository = _yearRepository ?? new YearRepository(_context);
        public IAuditLogRepository AuditLogs => _auditLogRepository = _auditLogRepository ?? new AuditLogRepository(_context);
        public IEmailOutBoxRepository EmailOutBoxes => _emailOutBoxRepository = _emailOutBoxRepository ?? new EmailOutBoxRepository(_context);
        public IEmailConfigurationRepository EmailConfigurations => _configurationRepository = _configurationRepository ?? new EmailConfigurationRepository(_context);

        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}