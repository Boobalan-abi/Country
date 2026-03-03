using Country.MVC.Models.Country;

namespace Country.Web.Service
{
    public interface ICountryService
    {
        Task<List<CountryViewModel>> GetAllAsync();
        Task<CountryViewModel> GetByIdAsync(int id);
        Task CreateAsync(CreateCountryViewModel model);
        Task UpdateAsync(UpdateCountryViewModel model);
        Task DeleteAsync(int id);
    }
}
