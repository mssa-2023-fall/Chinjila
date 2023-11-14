using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.FeatureManagement;
using Microsoft.Identity.Client;
using TestAppConfig;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("AppConfig");

// Load configuration from Azure App Configuration
//builder.Configuration.AddAzureAppConfiguration(connectionString);
//builder.Configuration.AddAzureAppConfiguration(option =>
//{
//    option.Connect(new Uri("https://vcappconfig.azconfig.io"),new ManagedIdentityCredential());
//});
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(connectionString)
           // Load all keys that start with `TestApp:` and have no label
           .Select("TestApp:*", LabelFilter.Null)
           // Configure to reload configuration if the registered sentinel key is modified
           .ConfigureRefresh(refreshOptions =>
                refreshOptions.Register("TestApp:Settings:Sentinel", refreshAll: true));

    // Load all feature flags with no label
    options.UseFeatureFlags(featureFlagOptions =>
    {
        featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(5);
    });
});

// Add services to the container.
builder.Services.AddRazorPages();
// Add Azure App Configuration middleware to the container of services.
builder.Services.AddAzureAppConfiguration();

// Add feature management to the container of services.
builder.Services.AddFeatureManagement();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("TestApp:Settings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAzureAppConfiguration();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
