using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionWithAppConfig
{
    //for this function to work, use app service plan instead of consumption plan
    public class ReadQueuedMessage
    {
        [FunctionName("ReadQueuedMessage")]
        public void Run([QueueTrigger(queueName: "%TestApp:Storage:QueueName%")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
