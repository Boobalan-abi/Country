using Country.MVC.Models.State;
using Country.Web.Service;
using System.Text;
using System.Text.Json;

namespace Country.MVC.Services
{
    public class StateService : IStateService
    {
        private readonly HttpClient _httpClient;

        public StateService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ApiClient");
        }

        public async Task<List<StateViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("State");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<StateViewModel>>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<StateViewModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"State/{id}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<StateViewModel>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateAsync(CreateStateViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("State", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(UpdateStateViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"State/{model.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"State/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}