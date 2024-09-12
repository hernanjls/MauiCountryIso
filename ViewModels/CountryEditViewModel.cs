using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppCountryISO.Models;
using MauiAppCountryISO.Services;

namespace MauiAppCountryISO.ViewModels
{
    [QueryProperty(nameof(CountryId), nameof(CountryId))]
    
    public partial class CountryEditViewModel : VmBase
    {
        private readonly ICountryService _countryRestService;

        [ObservableProperty]
        private string _countryId;

        [ObservableProperty]
        private CountryCreate _selectedItem;

        public CountryEditViewModel(ICountryService countryRestService)
        {
            _countryRestService = countryRestService;
            SelectedItem = new CountryCreate();
        }

        partial void OnCountryIdChanged(string value)
        {
            _ = GetDataAsync(value);

        }

        private async Task GetDataAsync(string value)
        {
            var reg = await _countryRestService.GetCountryAsync(int.Parse(value));

            if (reg != null)
            {
                SelectedItem.Code = reg.Code;
                SelectedItem.Name = reg.Name;
                SelectedItem.Alpha_2 = reg.Alpha_2;
                SelectedItem.Alpha_3 = reg.Alpha_3;
                SelectedItem.Iso_3166_2 = reg.Iso_3166_2;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        [RelayCommand]
        private async Task SendItemAsync()
        {
            await _countryRestService.UpdateCountryAsync(int.Parse(CountryId), SelectedItem);

            WeakReferenceMessenger.Default.Send(new CountryUpdatedMessage());
            await Shell.Current.GoToAsync("..");
            
        }
    }
}
