using MauiAppCountryISO.ViewModels;

namespace MauiAppCountryISO.Views;

public partial class SplashScreen : ContentPage
{
    private readonly SplashScreenViewModel _viewModel;

    public SplashScreen(SplashScreenViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
       
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}