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
using Newtonsoft.Json.Linq;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AzureDurableFunctionSamples
{
    public static class Monitoring
    {

        [FunctionName("E3_Monitor")]
        public static async Task Run([OrchestrationTrigger] IDurableOrchestrationContext monitorContext, ILogger log)
        {
            MonitorRequest input = monitorContext.GetInput<MonitorRequest>();
            if (!monitorContext.IsReplaying) { log.LogInformation($"Received monitor request. Location: {input?.Location}. Phone: {input?.Phone}."); }

            VerifyRequest(input);

            DateTime endTime = monitorContext.CurrentUtcDateTime.AddHours(6);
            if (!monitorContext.IsReplaying) { log.LogInformation($"Instantiating monitor for {input.Location}. Expires: {endTime}."); }

            while (monitorContext.CurrentUtcDateTime < endTime)
            {
                // Check the weather
                if (!monitorContext.IsReplaying) { log.LogInformation($"Checking current weather conditions for {input.Location} at {monitorContext.CurrentUtcDateTime}."); }

                bool isClear = await monitorContext.CallSubOrchestratorAsync<bool>("E3_GetIsClear", input.Location);

                if (isClear)
                {
                    // It's not raining! Or snowing. Or misting. Tell our user to take advantage of it.
                    if (!monitorContext.IsReplaying) { log.LogInformation($"Detected clear weather for {input.Location}. Notifying {input.Phone}."); }

                    await monitorContext.CallActivityAsync("E3_SendGoodWeatherAlert", input.Phone);
                    break;
                }
                else
                {
                    // Wait for the next checkpoint
                    var nextCheckpoint = monitorContext.CurrentUtcDateTime.AddMinutes(30);
                    if (!monitorContext.IsReplaying) { log.LogInformation($"Next check for {input.Location} at {nextCheckpoint}."); }

                    await monitorContext.CreateTimer(nextCheckpoint, CancellationToken.None);
                }
            }

            log.LogInformation($"Monitor expiring.");
        }

        [Deterministic]
        private static void VerifyRequest(MonitorRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "An input object is required.");
            }

            if (request.Location == null)
            {
                throw new ArgumentNullException(nameof(request.Location), "A location input is required.");
            }

            if (string.IsNullOrEmpty(request.Phone))
            {
                throw new ArgumentNullException(nameof(request.Phone), "A phone number input is required.");
            }
        }

        [FunctionName("E3_GetIsClear")]
        public static async Task<bool> GetIsClear([OrchestrationTrigger] IDurableOrchestrationContext E3Context)
        {
            //removed pointless WeatherUnderground service call
            //adding sample code to call "Long running service", which demostrate the built-in CallHttpAsync feature from the context
            
            var currentConditions= await E3Context.CallHttpAsync(HttpMethod.Get, new Uri("http://localhost:7052/api/WeatherService"));
            return currentConditions.Equals(WeatherCondition.Clear);
        }

        [FunctionName("E3_SendGoodWeatherAlert")]
        public static void SendGoodWeatherAlert(
        [ActivityTrigger] string phoneNumber,
        ILogger log,
        [TwilioSms(AccountSidSetting = "TwilioAccountSid", AuthTokenSetting = "TwilioAuthToken", From = "+18449892188")]
        out CreateMessageOptions message)
        {
            message = new CreateMessageOptions(new PhoneNumber(phoneNumber));
            message.Body = $"The weather's clear outside! Go take a walk!";
        }
          
          public enum WeatherCondition
        {
            Other,
            Clear,
            Precipitation,
        }

        public class MonitorRequest
        {
            public Location Location { get; set; }

            public string Phone { get; set; }
        }

        public class Location
        {
            public string State { get; set; }

            public string City { get; set; }

            public override string ToString() => $"{City}, {State}";
        }

    }
}