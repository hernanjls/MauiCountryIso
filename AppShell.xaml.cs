using MauiAppCountryISO.Views;

namespace MauiAppCountryISO
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));

            Routing.RegisterRoute(nameof(CountryDetailsView), typeof(CountryDetailsView));
            Routing.RegisterRoute(nameof(SubRegionAddView), typeof(SubRegionAddView));
            Routing.RegisterRoute(nameof(SubRegionEditView), typeof(SubRegionEditView));
            Routing.RegisterRoute(nameof(CountryAddView), typeof(CountryAddView));
            Routing.RegisterRoute(nameof(CountryEditView), typeof(CountryEditView));

        }

    }

}
