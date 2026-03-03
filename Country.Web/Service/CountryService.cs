using Country.MVC.Models.Country;
using Country.Web.Service;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Country.MVC.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CountryService> _logger;

        public CountryService(IHttpClientFactory factory, ILogger<CountryService> logger)
        {
            _httpClient = factory.CreateClient("ApiClient");
            _logger = logger;
        }

        public async Task<List<CountryViewModel>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Country");

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogWarning("GetAllAsync failed: {StatusCode}, {Response}", response.StatusCode, error);
                    return new List<CountryViewModel>();
                }

                var data = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<CountryViewModel>>(data,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CountryViewModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllAsync");
                return new List<CountryViewModel>();
            }
        }

        public async Task<CountryViewModel?> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Country/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("GetByIdAsync failed for Id {Id}: {StatusCode}", id, response.StatusCode);
                    return null;
                }

                var data = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CountryViewModel>(data,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetByIdAsync for Id {Id}", id);
                return null;
            }
        }

        public async Task<bool> CreateAsync(CreateCountryViewModel model)
        {
            try
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Country", content);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("CreateAsync failed: {StatusCode}", response.StatusCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in CreateAsync");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(UpdateCountryViewModel model)
        {
            try
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Country/{model.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("UpdateAsync failed for Id {Id}: {StatusCode}", model.Id, response.StatusCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateAsync for Id {Id}", model.Id);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Country/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("DeleteAsync failed for Id {Id}: {StatusCode}", id, response.StatusCode);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteAsync for Id {Id}", id);
                return false;
            }
        }
    }
}