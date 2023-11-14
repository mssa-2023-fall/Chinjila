using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using TestAppConfig;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("AppConfig");

// Load configuration from Azure App Configuration
builder.Configuration.AddAzureAppConfiguration(connectionString);
//builder.Configuration.AddAzureAppConfiguration(option =>
//{
//    option.Connect(new Uri("https://vcappconfig.azconfig.io"),new ManagedIdentityCredential());
//});


// Add services to the container.
builder.Services.AddRazorPages();
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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
