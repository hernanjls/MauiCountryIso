using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace MauiAppCountryISO.ViewModels
{
    public partial class VmBase : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy = false;

        // Command to navigate back
        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..", true);
        }

        // This method can be overridden in derived ViewModels for initialization logic
        public virtual Task OnInitializedAsync()
        {
            return Task.CompletedTask;
        }
    }
}
