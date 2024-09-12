using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppCountryISO.Services
{
    public interface IApiService
    {

        Task<TResponse> GetAsync<TResponse>(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse> DeleteAsync<TResponse>(string url);

      
    }
}
