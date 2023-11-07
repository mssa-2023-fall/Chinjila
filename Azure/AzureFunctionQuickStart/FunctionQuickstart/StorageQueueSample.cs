using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionQuickstart
{
    public class StorageQueueSample
    {
        private readonly ILogger<StorageQueueSample> _logger;

        public StorageQueueSample(ILogger<StorageQueueSample> logger)
        {
            _logger = logger;
        }

        [Function("SampleWithQueue")]
        public void Run([QueueTrigger("myqueue-items", Connection = "imgstorvc")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
