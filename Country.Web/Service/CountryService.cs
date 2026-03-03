using Country.MVC.Models.Country;
using Country.Web.Service;
using System.Text;
using System.Text.Json;

namespace Country.MVC.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ApiClient");
        }

        public async Task<List<CountryViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Country");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<CountryViewModel>>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<CountryViewModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Country/{id}");

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<CountryViewModel>(data,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task CreateAsync(CreateCountryViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Country", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(UpdateCountryViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Country/{model.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Country/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}