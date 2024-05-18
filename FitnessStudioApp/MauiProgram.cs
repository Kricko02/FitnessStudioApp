using FitnessStudioApp.Services;
using FitnessStudioApp.ViewModels;
using FitnessStudioApp.Views;
using Material.Components.Maui.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;

namespace FitnessStudioApp;

public static class MauiProgram
{
    public static IServiceProvider Services { get; private set; }

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("MaterialIcons-Regular.ttf", "IconsFont");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .UseMaterialComponents();

        builder.Services.AddTransient<WorkoutsPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<ProfilePage>();

        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddRefitClient<IApiService>()
                 .ConfigureHttpClient(client =>
                 {
                     client.BaseAddress = new Uri("https://192.168.1.16:7018/");
                     client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                 })
                 .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                 {
                     ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                 });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();
        Services = app.Services;
        return app;
    }
}
