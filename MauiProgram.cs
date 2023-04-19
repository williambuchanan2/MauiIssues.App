using CommunityToolkit.Maui;
using MauiIssues.Views;
using Microsoft.Extensions.Logging;
using MauiIssues.ViewModels;

namespace MauiIssues;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        RegisterViews(builder);
        return builder.Build();
    }


    public static void RegisterViews(MauiAppBuilder builder)
    {

        builder.Services.AddTransient<MainPageVm>();
        builder.Services.AddTransient<MainPage>();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));


        builder.Services.AddTransient<KeyboardIssueVm>();
        builder.Services.AddTransient<KeyboardIssue>();
        Routing.RegisterRoute(nameof(KeyboardIssue), typeof(KeyboardIssue));

        builder.Services.AddTransient<CarouselIssueVm>();
        builder.Services.AddTransient<CarouselIssue>();
        Routing.RegisterRoute(nameof(CarouselIssue), typeof(CarouselIssue));
    }

}
