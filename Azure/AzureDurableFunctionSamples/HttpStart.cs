using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using static AzureDurableFunctionSamples.Monitoring;

namespace AzureDurableFunctionSamples
{
    public static class HttpStart
    {
        [FunctionName("HttpStart_Fanout")]
        public static async Task<IActionResult> RunFanout(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post",  Route = "Fanout")] HttpRequest req,
            [DurableClient] IDurableClient starter,
            
            ILogger log)
        {
            string body = new StreamReader(req.Body).ReadToEnd();
            string instanceId = await starter.StartNewAsync("E2_BackupSiteContent", body);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");



            return starter.CreateCheckStatusResponse(req, instanceId);
        }

        [FunctionName("HttpStart_PhoneVerify")]
        public static async Task<IActionResult> RunPhoneVerify(
          [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "PhoneVerify")] HttpRequest req,
          [DurableClient] IDurableClient starter,

          ILogger log)
        {
            string body = new StreamReader(req.Body).ReadToEnd();
            string instanceId = await starter.StartNewAsync("E4_SmsPhoneVerification", body);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");



            return starter.CreateCheckStatusResponse(req, instanceId);
        }

        [FunctionName("HttpStart_Monitor")]
        public static async Task<IActionResult> RunMonitor(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Monitor")] HttpRequest req,
           [DurableClient] IDurableClient starter,
           
           ILogger log)
        {
            string body = new StreamReader(req.Body).ReadToEnd();
            var param = JsonConvert.DeserializeObject<MonitorRequest>(body);
            string instanceId = await starter.StartNewAsync("E3_Monitor", param);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");



            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    
    
    }
}
