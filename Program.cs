using ExerciseLibrary.Frontend.Clients;
using ExerciseLibrary.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

var exerciseLibraryApiUrl = builder.Configuration["ExerciseLibraryApiUrl"] ?? 
    throw new Exception("ExerciseLibraryApiUrl is not set");

builder.Services.AddHttpClient<ExercisesClient>(
    client => client.BaseAddress = new Uri(exerciseLibraryApiUrl));

builder.Services.AddHttpClient<GenresClient>(
    client => client.BaseAddress = new Uri(exerciseLibraryApiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
