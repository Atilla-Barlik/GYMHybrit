using GYMandNutrition.Shared.Services;
using GYMandNutrition.Web.Components;
using GYMandNutrition.Web.Services;
using MudBlazor.Services;
using Services.AppUserExerciseProgramServise;
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
builder.Services.AddSingleton<MealTimeService>();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddMudServices();
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
