using GYMandNutrition.Services;
using GYMandNutrition.Shared.Services;
using Microsoft.Extensions.Logging;
using Services.DailyNutritionServices;
using Services.NutrientServices;

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
			builder.Services.AddMauiBlazorWebView();

#if DEBUG
	        builder.Services.AddBlazorWebViewDeveloperTools();
	        builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
