
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppCountryISO.Models;
using MauiAppCountryISO.Services;
using MauiAppCountryISO.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiAppCountryISO.ViewModels
{
    [QueryProperty(nameof(CountryItem), nameof(CountryItem))]
    public partial class CountryDetailsViewModel : VmBase
    {
      
        private readonly ICountryService _countryRestService;

        [ObservableProperty]
        private Country _countryItem;

        [ObservableProperty]
        private ObservableCollection<State> _subRegionsViewModel = new ObservableCollection<State>();

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isErrorVisible;

        
        public CountryDetailsViewModel(ICountryService countryRestService)
        {
            _countryRestService = countryRestService;

            WeakReferenceMessenger.Default.Register<SubRegionAddedMessage>(this, async (r, m) =>
            {
                CountryItem = await _countryRestService.GetCountryAsync(CountryItem.Id);
                await LoadCountryDetailsAsync(CountryItem.Id);
            });

            WeakReferenceMessenger.Default.Register<SubRegionUpdatedMessage>(this, async (r, m) =>
            {
                CountryItem = await _countryRestService.GetCountryAsync(CountryItem.Id);
                await LoadCountryDetailsAsync(CountryItem.Id);
            });
        }

        partial void OnCountryItemChanged(Country value)
        {
            if (value != null)
            {
                _ = LoadCountryDetailsAsync(value.Id);
            }
        }

        private async Task LoadCountryDetailsAsync(int countryId)
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            IsErrorVisible = false;

            try
            {
                var subRegions = await _countryRestService.GetStatesAsync(countryId);
                SubRegionsViewModel.Clear();

                foreach (var subRegion in subRegions)
                {
                    SubRegionsViewModel.Add(subRegion);
                }

                OnPropertyChanged(nameof(SubRegionsViewModel));

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching country details: {ex.Message}");
                ErrorMessage = "Failed to load country details. Please try again.";
                IsErrorVisible = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

       

        [RelayCommand]
        private async Task EditItemAsync(State item)
        {
            await Shell.Current.GoToAsync(nameof(SubRegionEditView), new Dictionary<string, object>
            {
                { nameof(SubRegionEditViewModel.CountryItem), CountryItem },
                { nameof(SubRegionEditViewModel.StateItem), item }

            });
        }

        [RelayCommand]
        private async Task DeleteItemAsync(State item)
        {
            if (item == null)
                return;

            bool isConfirmed = await Application.Current.MainPage.DisplayAlert(
                "Confirm Delete", 
                "Are you sure you want to delete this item?", 
                "Yes", // Accept
                "No" // Cancel
            );

            if (isConfirmed)
            {

                try
                {
                    IsBusy = true;
                    await _countryRestService.DeleteStateAsync(CountryItem.Id, item.Id);
                    await RefreshSubRegions();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error deleting estate country: {ex.Message}");
                    ErrorMessage = "Failed to delete estate country. Please try again.";
                    IsErrorVisible = true;
                }
                finally
                {
                    IsBusy = false;
                }

            }
        }

        [RelayCommand]
        private async Task RefreshSubRegions()
        {

            CountryItem = await _countryRestService.GetCountryAsync(CountryItem.Id);
            OnPropertyChanged(nameof(CountryItem));
            await LoadCountryDetailsAsync(CountryItem.Id);


        }

        [RelayCommand]
        private async Task GoToRegionAddAsync()
        {
            await Shell.Current.GoToAsync(nameof(SubRegionAddView), new Dictionary<string, object>
            {
                { nameof(SubRegionAddViewModel.CountryItem), CountryItem }

            });

        }

       

    }
}
