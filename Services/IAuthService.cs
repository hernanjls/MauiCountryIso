using MauiAppCountryISO.Models;

namespace MauiAppCountryISO.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginRequest loginRequest);
    }
}
