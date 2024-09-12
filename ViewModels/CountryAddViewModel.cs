using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppCountryISO.Models;
using MauiAppCountryISO.Services;

namespace MauiAppCountryISO.ViewModels
{
    
    public partial class CountryAddViewModel : VmBase
    {
        private readonly ICountryService _countryRestService;

        
        [ObservableProperty]
        private CountryCreate _selectedItem;

        [ObservableProperty]
        private int _countryId;

        public CountryAddViewModel(ICountryService countryRestService)
        {
            _countryRestService = countryRestService;
            SelectedItem = new CountryCreate();
        }

        public void ResetState()
        {
            SelectedItem = new CountryCreate();
        }

        [RelayCommand]
        private async Task SendItemAsync()
        {
            var ret_new = await _countryRestService.CreateCountryAsync(SelectedItem);

            if (ret_new != 0)
            {
                WeakReferenceMessenger.Default.Send(new CountryAddedMessage());
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
