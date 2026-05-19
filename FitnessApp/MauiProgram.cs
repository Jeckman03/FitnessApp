using CommunityToolkit.Maui;
using DataAccessLibrary.Helper;
using DataAccessLibrary.Services;
using DataAccessLibrary.Sqllite;
using FitnessApp.ViewModels;
using FitnessApp.Views;
using FitnessAppLibrary.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FitnessApp
{
    public static class MauiProgram
    {
        public static async Task<MauiApp> CreateMauiApp()
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

            // Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CreateNewUserPage>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<WorkoutPage>();
            builder.Services.AddTransient<WeighinPopupPage>();

            // ViewModels
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<CreateNewUserViewModel>();
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<WorkoutViewModel>();
            builder.Services.AddTransient<WeighinPopupViewModel>();

            // Services
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "FitnessTracker.db3");
            string connectionString = $"Data Source={dbPath}";

            builder.Services.AddSingleton<SqLiteDataAccess>(s => new SqLiteDataAccess(connectionString));
            builder.Services.AddSingleton<IUserProfileService, UserProfileServices>();

            // Helper
            Dapper.SqlMapper.AddTypeHandler(new DateOnlyTypeHelper());

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dataAccess = scope.ServiceProvider.GetRequiredService<SqLiteDataAccess>();
                await dataAccess.InitializeDatabase();
            }

            return app;
        }
    }
}
