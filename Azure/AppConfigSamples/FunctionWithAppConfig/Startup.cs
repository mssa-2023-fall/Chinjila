using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(FunctionWithAppConfig.Startup))]

namespace FunctionWithAppConfig
{
    class Startup : FunctionsStartup
    {
     
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            // Add Azure App Configuration as additional configuration source
            builder.ConfigurationBuilder.AddAzureAppConfiguration(options =>
            {
                options.Connect(Environment.GetEnvironmentVariable("ConnectionString"))
                       // Load all keys that start with `TestApp:` and have no label
                       .Select("TestApp:*")
                       // Configure to reload configuration if the registered key 'TestApp:Settings:Sentinel' is modified.
                       // Use the default cache expiration of 30 seconds. It can be overriden via AzureAppConfigurationRefreshOptions.SetCacheExpiration.
                       .ConfigureRefresh(refreshOptions =>
                            refreshOptions.Register("TestApp:Settings:Sentinel", refreshAll: true)
                        )
                       // Load all feature flags with no label. To load specific feature flags and labels, set via FeatureFlagOptions.Select.
                       // Use the default cache expiration of 30 seconds. It can be overriden via FeatureFlagOptions.CacheExpirationInterval.
                       .UseFeatureFlags();
            });
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Make Azure App Configuration services and feature manager available through dependency injection
            builder.Services.AddAzureAppConfiguration();
            builder.Services.AddFeatureManagement();
        }
    }
}
