using TimeApp.Components;
using TimeApp.Components.Services;
using BlazorBootstrap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add TimeService
builder.Services.AddSingleton<TimeService>();

// Add Blazor.Bootstrap services
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<ToastService>();

// Add HttpClient
builder.Services.AddHttpClient();

// Add health checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Add health check endpoint
app.MapHealthChecks("/health");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
