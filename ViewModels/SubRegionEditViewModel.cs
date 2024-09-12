using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppCountryISO.Models;
using MauiAppCountryISO.Services;

namespace MauiAppCountryISO.ViewModels
{
    [QueryProperty(nameof(CountryItem), nameof(CountryItem))]
    [QueryProperty(nameof(StateItem), nameof(StateItem))]
    public partial class SubRegionEditViewModel : VmBase
    {
        private readonly ICountryService _countryRestService;

        [ObservableProperty]
        private Country? _countryItem;

        [ObservableProperty]
        private State? _stateItem;

        [ObservableProperty]
        private StateCreate _selectedItem;

        [ObservableProperty]
        private int _countryId;

        [ObservableProperty]
        private int _estateId;

        public SubRegionEditViewModel(ICountryService countryRestService)
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

        partial void OnStateItemChanged(State? value)
        {
            if (value != null)
            {
                ResetState();
                EstateId = value.Id;
                SelectedItem.Name = value.Name;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public void ResetState()
        {
            SelectedItem = new StateCreate();
        }

        [RelayCommand]
        private async Task SendItemAsync()
        {
            await _countryRestService.UpdateStateAsync(CountryId, EstateId, SelectedItem);

            WeakReferenceMessenger.Default.Send(new SubRegionUpdatedMessage());
            await Shell.Current.GoToAsync("..");
            
        }
    }
}
