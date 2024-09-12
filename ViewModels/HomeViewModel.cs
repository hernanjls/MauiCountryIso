using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppCountryISO.Models;
using MauiAppCountryISO.Services;
using MauiAppCountryISO.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;


namespace MauiAppCountryISO.ViewModels
{
    public partial class HomeViewModel : VmBase
    {
        private readonly ICountryService _countryRestService;

        [ObservableProperty]
        private ObservableCollection<Country> _itemsViewModel = new ObservableCollection<Country>();

        [ObservableProperty]
        private string _searchTerm;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private bool _isErrorVisible;

        [ObservableProperty]
        private bool _isBusy;

        public HomeViewModel(ICountryService countryRestService)
        {
            _countryRestService = countryRestService;
            // Initial population of countries
            _ = PopulateCountriesAsync();

            WeakReferenceMessenger.Default.Register<CountryAddedMessage>(this, async (r, m) =>
            {
                await PopulateCountriesAsync();
            });

            WeakReferenceMessenger.Default.Register<CountryUpdatedMessage>(this, async (r, m) =>
            {
                await PopulateCountriesAsync();
            });

        }

        [RelayCommand]
        public async Task PopulateCountriesAsync()
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            IsErrorVisible = false;

            try
            {
                var response = await _countryRestService.GetCountriesAsync();
                ItemsViewModel = new ObservableCollection<Country>(response.Records);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching countries: {ex.Message}");
                ErrorMessage = "Failed to load countries. Please try again.";
                IsErrorVisible = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task SearchCountriesAsync()
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            IsErrorVisible = false;

            try
            {
                ObservableCollection<Country> items;

                var response = await _countryRestService.GetCountriesAsync(SearchTerm);
                items = new ObservableCollection<Country>(response.Records);

                ItemsViewModel = items;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error searching countries: {ex.Message}");
                ErrorMessage = "Search failed. Please try again.";
                IsErrorVisible = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task EditItemAsync(Country item)
        {
            await Shell.Current.GoToAsync(nameof(CountryEditView), new Dictionary<string, object>
            {
                { nameof(CountryEditViewModel.CountryId), item.Id.ToString() },
            });
        }

        [RelayCommand]
        private async Task DeleteItemAsync(Country item)
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
                    var lst = await _countryRestService.GetStatesAsync(item.Id);

                    if (lst.Count > 0)
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Information",
                            "The country Item has related States, cannot be deleted",
                            "Ok"
                        );
                        return;
                    }

                    await _countryRestService.DeleteCountryAsync(item.Id);
                    await PopulateCountriesAsync();
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
        private async Task AddCountryAsync()
        {
            await Shell.Current.GoToAsync(nameof(CountryAddView));
        }

        [RelayCommand]
        private async Task GoToCountryDetailsAsync(Country country)
        {
            await Shell.Current.GoToAsync(nameof(CountryDetailsView),  new Dictionary<string, object>
            {
                { nameof(CountryDetailsViewModel.CountryItem), country }

            });
        }
    }
}
