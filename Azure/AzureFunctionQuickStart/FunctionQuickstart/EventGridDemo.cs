// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using Azure.Messaging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionQuickstart
{
    public class EventGridDemo
    {
        private readonly ILogger<EventGridDemo> _logger;

        public EventGridDemo(ILogger<EventGridDemo> logger)
        {
            _logger = logger;
        }

        [Function(nameof(EventGridDemo))]
        public void Run([EventGridTrigger] string cloudEvent)
        {
            _logger.LogInformation("Event String: {0}", cloudEvent);
        }
    }
}
