using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using System.Net.Http;

namespace watchdogmanager.functions.Functions
{
    public static class SwaggerFunctions
    {
        [SwaggerIgnore]
        [FunctionName("Swagger")]
        public static HttpResponseMessage RunSwaggerJSON(
             [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Swagger/json")] HttpRequestMessage req,
             [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return swashBuckleClient.CreateSwaggerDocumentResponse(req);
        }

        [SwaggerIgnore]
        [FunctionName("SwaggerUi")]
        public static HttpResponseMessage RunSwaggerUI(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Swagger/ui")] HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return swashBuckleClient.CreateSwaggerUIResponse(req, "swagger/json");
        }
    }
}
