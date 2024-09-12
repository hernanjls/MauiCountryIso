using MauiAppCountryISO.ViewModels;

namespace MauiAppCountryISO.Views;

public partial class CountryEditView : ContentPage
{
    private CountryEditViewModel _viewModel;
    public CountryEditView(CountryEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

}