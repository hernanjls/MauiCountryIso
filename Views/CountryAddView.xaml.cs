using MauiAppCountryISO.ViewModels;

namespace MauiAppCountryISO.Views;

public partial class CountryAddView : ContentPage
{
    private CountryAddViewModel _viewModel;
    public CountryAddView(CountryAddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.ResetState();
    }
}