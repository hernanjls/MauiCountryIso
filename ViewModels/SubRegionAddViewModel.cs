using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppCountryISO.Models;
using MauiAppCountryISO.Services;

namespace MauiAppCountryISO.ViewModels
{
    [QueryProperty(nameof(CountryItem), nameof(CountryItem))]
    public partial class SubRegionAddViewModel : VmBase
    {
        private readonly ICountryService _countryRestService;

        [ObservableProperty]
        private Country? _countryItem;

        [ObservableProperty]
        private StateCreate _selectedItem;

        [ObservableProperty]
        private int _countryId;

        public SubRegionAddViewModel(ICountryService countryRestService)
        {
            _countryRestService = countryRestService;
            SelectedItem = new StateCreate();
        }

        partial void OnCountryItemChanged(Country? value)
        {
            if (value != null)
            {
                CountryId = value.Id;
            }
        }

        public void ResetState()
        {
            SelectedItem = new StateCreate();
        }

        [RelayCommand]
        private async Task SendItemAsync()
        {
            var ret_new = await _countryRestService.CreateStateAsync(CountryId, SelectedItem);

            if (ret_new != 0)
            {
                WeakReferenceMessenger.Default.Send(new SubRegionAddedMessage());
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
