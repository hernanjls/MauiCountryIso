using MauiAppCountryISO.ViewModels;

namespace MauiAppCountryISO.Views;

public partial class SubRegionAddView : ContentPage
{
    private SubRegionAddViewModel _viewModel;
    public SubRegionAddView(SubRegionAddViewModel viewModel)
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