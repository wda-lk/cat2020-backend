using CAT20.Core.Repositories.Control;
using System;
using System.Threading.Tasks;

namespace CAT20.Core
{
    public interface IControlUnitOfWork : IDisposable
    {
        IAppCategoryRepository AppCategories { get; }
        IBankDetailRepository BankDetails { get; }
        IDistrictRepository Districts { get; }
        IGenderRepository Genders { get; }
        ILanguageRepository Languages { get; }
        IMonthRepository Months { get; }
        IOfficeRepository Offices { get; }
        IOfficeTypeRepository OfficeTypes { get; }
        IProvinceRepository Provinces { get; }
        ISabhaRepository Sabhas { get; }
        ISelectedLanguageRepository SelectedLanguages { get; }
        IYearRepository Years { get; }
        IEmailOutBoxRepository  EmailOutBoxes { get; }
        IEmailConfigurationRepository EmailConfigurations { get; }
        Task<int> CommitAsync();

    }
}
