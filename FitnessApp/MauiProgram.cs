using FitnessApp.ViewModels;
using FitnessApp.Views;
using Microsoft.Extensions.Logging;

namespace FitnessApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CreateNewUserPage>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<WorkoutPage>();

            // ViewModels
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<CreateNewUserViewModel>();
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<WorkoutViewModel>();

            // Services

            return builder.Build();
        }
    }
}
