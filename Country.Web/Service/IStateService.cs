using Country.MVC.Models.State;

namespace Country.Web.Service
{
    public interface IStateService
    {
        Task<List<StateViewModel>> GetAllAsync();
        Task<StateViewModel> GetByIdAsync(int id);
        Task CreateAsync(CreateStateViewModel model);
        Task UpdateAsync(UpdateStateViewModel model);
        Task DeleteAsync(int id);
    }
}