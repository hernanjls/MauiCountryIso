using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppCountryISO.Models;
using MauiAppCountryISO.Services;
using MauiAppCountryISO.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppCountryISO.ViewModels
{
    public partial class LoginViewModel : VmBase
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isErrorVisible;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;

            Username = "useradmin@example.com";
            Password = "adm123456!!";
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            IsErrorVisible = false;

            var loginRequest = new LoginRequest { Email = Username, Password = Password };
            var success = await _authService.LoginAsync(loginRequest);

            if (success)
            {
                // Navigate to Home page
                await Shell.Current.GoToAsync(nameof(HomeView));
            }
            else
            {
                ErrorMessage = "Login failed. Please try again.";
                IsErrorVisible = true;
            }

            IsBusy = false;
        }
    }

}
