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

namespace AzureDurableFunctionSamples
{
    public static class HttpStart
    {
        [FunctionName("HttpStart")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post",  Route = "orchestrators/{functionName}")] HttpRequest req,
            [DurableClient] IDurableClient starter,
            string functionName,
            ILogger log)
        {
            string body = new StreamReader(req.Body).ReadLine();
            string instanceId = await starter.StartNewAsync<string>(functionName, body);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");



            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
