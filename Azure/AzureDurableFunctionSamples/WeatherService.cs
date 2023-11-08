using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using static AzureDurableFunctionSamples.Monitoring;

namespace AzureDurableFunctionSamples
{
    public static class WeatherService
    {
        [FunctionName("SlowWeatherService")]
        public static async Task<WeatherCondition> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            await context.CreateTimer(DateTime.Now.AddMinutes(1), CancellationToken.None ) ;
            if (Random.Shared.Next(1, 100) % 4 >= 1)
                return WeatherCondition.Clear;
            return WeatherCondition.Other;
        }

   
        [FunctionName("WeatherService")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("SlowWeatherService", null);

            log.LogInformation("Started orchestration with ID = '{instanceId}'.", instanceId);

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}