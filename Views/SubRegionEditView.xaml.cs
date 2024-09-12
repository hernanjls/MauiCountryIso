using MauiAppCountryISO.ViewModels;

namespace MauiAppCountryISO.Views;

public partial class SubRegionEditView : ContentPage
{
    private SubRegionEditViewModel _viewModel;
    public SubRegionEditView(SubRegionEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}