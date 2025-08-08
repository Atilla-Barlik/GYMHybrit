using Blazored.LocalStorage;
using GYMandNutrition.Services;
using GYMandNutrition.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Services.AppUserDetailServices;
using Services.AppUserExerciseProgramServise;
using Services.AppUserServices;
using Services.AuthServices;
using Services.AvgKcalDailyServices;
using Services.DailyMacroServices;
using Services.DailyNutritionDetailsService;
using Services.DailyNutritionServices;
using Services.ExerciseDetailServise;
using Services.ExerciseServices;
using Services.LocalAuthStateProviderServices;
using Services.NutrientServices;
using Services.StatisticServices;

namespace GYMandNutrition
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
				});

			// Add device-specific services used by the GYMandNutrition.Shared project
			builder.Services.AddSingleton<IFormFactor, FormFactor>();
			builder.Services.AddSingleton<INutrientService, NutrientService>();
			builder.Services.AddSingleton<IDailyNutritionService, DailyNutritionService>();
            builder.Services.AddSingleton<IDailyNutritionDetailsService, DailyNutritionDetailsService>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IExerciseService, ExerciseService>();
            builder.Services.AddSingleton<IExerciseDetailService, ExerciseDetailService>();
            builder.Services.AddSingleton<IAppUserExerciseProgramService, AppUserExerciseProgramService>();
            builder.Services.AddSingleton<IStatisticService, StatisticService>();
            builder.Services.AddSingleton<IDailyMacroService, DailyMacroService>();
            builder.Services.AddSingleton<IAppUserService, AppUserService>();
            builder.Services.AddSingleton<IAppUserDetailService, AppUserDetailService>();
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<MealTimeService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<LocalAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(x => x.GetRequiredService<LocalAuthStateProvider>());
            builder.Services.AddMudBlazorResizeListener();
            builder.Services.AddSingleton<IAvgKcalDailyService, AvgKcalDailyService>();
            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
                config.ResizeOptions = new ResizeOptions
                {
                    EnableLogging = false,
                    ReportRate = 200,
                    NotifyOnBreakpointOnly = false
                };
                config.ResizeObserverOptions = new ResizeObserverOptions
                {
                    EnableLogging = false
                };

            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
	        builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
