using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SampleIdentity.Areas.Identity.Data;
using SampleIdentity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SampleIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'SampleIdentityContextConnection' not found.");

builder.Services.AddDbContext<SampleIdentityContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<BasicUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SampleIdentityContext>();

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
