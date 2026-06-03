using CommunityToolkit.Maui;
using DataAccessLibrary.Helper;
using DataAccessLibrary.Services;
using DataAccessLibrary.Sqllite;
using FitnessApp.ViewModels;
using FitnessApp.Views;
using FitnessAppLibrary.Services.HelperServices;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
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
            // DB
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "FitnessTracker.db3");
            string connectionString = $"Data Source={dbPath}";

            // Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CreateNewUserPage>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<WorkoutPage>();
            builder.Services.AddTransient<WeighinPopupPage>();
            builder.Services.AddTransient<LoginPage>();

            // ViewModels
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<CreateNewUserViewModel>();
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<WorkoutViewModel>();
            builder.Services.AddTransient<WeighinPopupViewModel>();
            builder.Services.AddTransient<LoginViewModel>();

            // Services
            builder.Services.AddSingleton<IDataAccess>(s => new SqLiteDataAccess(connectionString));
            builder.Services.AddSingleton<IUserDataAccess, UserDataAccess>();
            builder.Services.AddTransient<IUserProfileService, UserProfileServices>();
            builder.Services.AddTransient<IBodyMetricService, BodyMetricService>();
            builder.Services.AddTransient<IUnitConversionSerivce, UnitConversionService>();
            builder.Services.AddTransient<IMacroCalculatorService, MacroCalculatorService>();
            builder.Services.AddTransient<ICheckinService, CheckinService>();
            builder.Services.AddTransient<IDailyLogDataAccess, DailyLogDataAccess>();
            builder.Services.AddTransient<IPlanDataAccess, PlanDataAccess>();


            // DB

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
