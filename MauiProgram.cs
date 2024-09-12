using CommunityToolkit.Maui;
using MauiAppCountryISO.Constants;
using MauiAppCountryISO.Services;
using MauiAppCountryISO.ViewModels;
using MauiAppCountryISO.Views;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MauiAppCountryISO
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
             .UseMauiApp<App>()
             .UseMauiCommunityToolkit()
             .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Add Data Service
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IApiService>(provider => new ApiService(ApiConstants.ApiBaseUrl)); 
            builder.Services.AddSingleton<ICountryService, CountryService>();


            // Add ViewModels
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<SplashScreenViewModel>();
            builder.Services.AddSingleton<CountryDetailsViewModel>();
            builder.Services.AddSingleton<SubRegionAddViewModel>();
            builder.Services.AddSingleton<SubRegionEditViewModel>();
            builder.Services.AddSingleton<CountryAddViewModel>();
            builder.Services.AddSingleton<CountryEditViewModel>();

            // Add Views
            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<HomeView>();
            builder.Services.AddSingleton<SplashScreen>();
            builder.Services.AddSingleton<CountryDetailsView>();
            builder.Services.AddSingleton<SubRegionAddView>();
            builder.Services.AddSingleton<SubRegionEditView>();
            builder.Services.AddSingleton<CountryAddView>();
            builder.Services.AddSingleton<CountryEditView>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
