using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace MauiAppCountryISO.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(string apiBaseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(apiBaseAddress)
            };
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new Exception($"Error de validación (422): {errorResponse}");
                    }

                    throw new Exception($"Error in POST Request: {response.StatusCode} - {response.ReasonPhrase}. Detalles: {errorResponse}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"HTTP request error: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                throw new Exception($"Error deserializing response: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"error: {ex.Message}");
            }
        }

        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error in GET Request: {response.ReasonPhrase}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseBody);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error in PUT Request: {response.ReasonPhrase}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseBody);
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error in DELETE request: {response.ReasonPhrase}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseBody);
        }
    }
}