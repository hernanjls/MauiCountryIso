using MauiAppCountryISO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppCountryISO.Services
{
    public interface ICountryService
    {
        
        Task<CountriesResponse> GetCountriesAsync(string searchTerm = "", int page = 1, int limit = 100);
        Task<int> CreateCountryAsync(CountryCreate countryCreate);
        Task<Country> GetCountryAsync(int countryId);
        Task UpdateCountryAsync(int countryId, CountryCreate countryCreate);
        Task DeleteCountryAsync(int countryId);
        Task<List<State>> GetStatesAsync(int countryId);
        Task<int> CreateStateAsync(int countryId, StateCreate stateCreate);
        Task<State> GetStateAsync(int countryId, int stateId);
        Task UpdateStateAsync(int countryId, int stateId, StateCreate stateCreate);
        Task DeleteStateAsync(int countryId, int stateId);
    }
}
