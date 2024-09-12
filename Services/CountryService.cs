using MauiAppCountryISO.Models;

namespace MauiAppCountryISO.Services
{
    public class CountryService : ICountryService
    {
        readonly IApiService _apiService;

        public CountryService(IApiService apiService)
        {
            _apiService = apiService;
        }
        
        public async Task<CountriesResponse> GetCountriesAsync(string searchTerm = "", int page = 1, int limit = 100)
        {
            var url = $"/countries?page={page}&limit={limit}";
            var ret =  await _apiService.GetAsync<CountriesResponse>(url);

            if(!string.IsNullOrEmpty(searchTerm))
            {
                var items = ret.Records.Where(x=>x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                ret.Records = items;
            }

            return ret;

        }

        public async Task<int> CreateCountryAsync(CountryCreate countryCreate)
        {
            var url = "/countries";
            return await _apiService.PostAsync<CountryCreate, int>(url, countryCreate);
        }

        public async Task<Country> GetCountryAsync(int countryId)
        {
            var url = $"/countries/{countryId}";
            return await _apiService.GetAsync<Country>(url);
        }

        public async Task UpdateCountryAsync(int countryId, CountryCreate countryCreate)
        {
            var url = $"/countries/{countryId}";
            await _apiService.PutAsync<CountryCreate, object>(url, countryCreate);
        }
        public async Task DeleteCountryAsync(int countryId)
        {
            var url = $"/countries/{countryId}";
            await _apiService.DeleteAsync<object>(url);
        }

        public async Task<List<State>> GetStatesAsync(int countryId)
        {
            var url = $"/countries/{countryId}/states";
            return await _apiService.GetAsync<List<State>>(url);
        }

        public async Task<int> CreateStateAsync(int countryId, StateCreate stateCreate)
        {
            var url = $"/countries/{countryId}/states";
            return await _apiService.PostAsync<StateCreate, int>(url, stateCreate);
        }

        public async Task<State> GetStateAsync(int countryId, int stateId)
        {
            var url = $"/countries/{countryId}/states/{stateId}";
            return await _apiService.GetAsync<State>(url);
        }

        public async Task UpdateStateAsync(int countryId, int stateId, StateCreate stateCreate)
        {
            var url = $"/countries/{countryId}/states/{stateId}";
            await _apiService.PutAsync<StateCreate, object>(url, stateCreate);
        }
        public async Task DeleteStateAsync(int countryId, int stateId)
        {
            var url = $"/countries/{countryId}/states/{stateId}";
            await _apiService.DeleteAsync<object>(url);
        }
    }
}
