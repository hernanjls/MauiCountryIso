using MauiAppCountryISO.Models;
using MauiAppCountryISO.ViewModels;

namespace MauiAppCountryISO.Views;

public partial class HomeView : ContentPage
{

    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IsVisible = false 
        });

    }

}