using MauiAppCountryISO.Models;

namespace MauiAppCountryISO.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApiService _apiService;

        public AuthService(IApiService apiService)
        {
            _apiService = apiService;
        }

        //public async Task<bool> LoginAsync(LoginRequest loginRequest)
        //{
        //    var response = await _apiService.PostAsync<LoginRequest, UserManagerResponse>("auth/login", loginRequest);

        //    if (response.IsSuccess)
        //    {
        //        await GlobalProperties.SetTokenAsync(response.Message); // Use SecureStorage 
        //        return true;
        //    }

        //    return false;
        //}

        public async Task<bool> LoginAsync(LoginRequest loginRequest)
        {
            await Task.Delay(1000);
            await GlobalProperties.SetTokenAsync("fake_token"); // fake token
            return true;
        }

    }
}
