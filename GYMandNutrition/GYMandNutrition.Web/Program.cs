using GYMandNutrition.Shared.Services;
using GYMandNutrition.Web.Components;
using GYMandNutrition.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using Services.AppUserDetailServices;
using Services.AppUserExerciseProgramServise;
using Services.AppUserServices;
using Services.DailyMacroServices;
using Services.DailyNutritionDetailsService;
using Services.DailyNutritionServices;
using Services.ExerciseDetailServise;
using Services.ExerciseServices;
using Services.NutrientServices;
using Services.StatisticServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

// Add device-specific services used by the GYMandNutrition.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddSingleton<INutrientService, NutrientService>();
builder.Services.AddSingleton<IDailyNutritionService, DailyNutritionService>();
builder.Services.AddSingleton<IDailyNutritionDetailsService, DailyNutritionDetailsService>();
builder.Services.AddSingleton<IExerciseService, ExerciseService>();
builder.Services.AddSingleton<IExerciseDetailService, ExerciseDetailService>();
builder.Services.AddSingleton<IAppUserExerciseProgramService, AppUserExerciseProgramService>();
builder.Services.AddSingleton<IStatisticService, StatisticService>();
builder.Services.AddSingleton<IDailyMacroService, DailyMacroService>();
builder.Services.AddSingleton<IAppUserService, AppUserService>();
builder.Services.AddSingleton<IAppUserDetailService, AppUserDetailService>();
builder.Services.AddSingleton<MealTimeService>();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
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
});
builder.Services.AddBlazorBootstrap();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options =>
{
    options.DetailedErrors = true;
});

	
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddAdditionalAssemblies(typeof(GYMandNutrition.Shared._Imports).Assembly);

app.Run();
