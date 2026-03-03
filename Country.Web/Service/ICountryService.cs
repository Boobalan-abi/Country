using Country.MVC.Models.Country;

namespace Country.Web.Service
{
    public interface ICountryService
    {
        Task<List<CountryViewModel>> GetAllAsync();
        Task<CountryViewModel?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCountryViewModel model);
        Task<bool> UpdateAsync(UpdateCountryViewModel model);
        Task<bool> DeleteAsync(int id);
    }
}