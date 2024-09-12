using MauiAppCountryISO.ViewModels;

namespace MauiAppCountryISO.Views;

public partial class CountryDetailsView : ContentPage
{
    CountryDetailsViewModel _vm;
    public CountryDetailsView(CountryDetailsViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm; 
       
    }

}