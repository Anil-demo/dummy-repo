using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;

namespace dummyusingCLI
{
    public class DummyTrigger
    {
        private readonly ILogger<DummyTrigger> _logger;

        public DummyTrigger(ILogger<DummyTrigger> logger)
        {
            _logger = logger;
        }

        [Function("DummyTrigger")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("Dummytrigger got executed");
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString("Hello from Github actions");
            return response;
        }
    }
}
