using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;

namespace FunctionQuickstart.DurableFunctionsTut
{
    public class DurableFunctionStarter
    {
        private readonly ILogger _logger;

        public DurableFunctionStarter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DurableFunctionStarter>();
        }

        [Function("DurableFunctionStarter")]
        public static async Task<HttpResponseData>  Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "orchestrators/{functionName}")] HttpRequestData req,
            [DurableClient] DurableTaskClient client,
            string functionName,
            string path,
            ILogger log
            )
        {


            //string eventData = new StreamReader(req.Body).ReadToEnd();
            string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(functionName, path);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return client.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
