using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppCountryISO.Services;
using MauiAppCountryISO.Views;


namespace MauiAppCountryISO.ViewModels
{
    public class SplashScreenViewModel : VmBase
    {
        public SplashScreenViewModel()
        {
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            await Task.Delay(1000);

            var token = await SecureStorage.GetAsync("auth_token");

            if (!string.IsNullOrEmpty(token))
            {
                await GlobalProperties.SetTokenAsync(token);
                await Shell.Current.GoToAsync(nameof(HomeView));
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(LoginView));
            }
        }
    }
}
