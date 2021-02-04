using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace watchdogmanager.functions.Extensions
{
    public static class HttpRequestExtensions
    {
        public static T Content<T>(this HttpRequest request)
        {
            if (request?.Body == null) return default;

            using var reader = new StreamReader(request.Body);
            var bodyContent = reader.ReadToEnd();

            var contentObject = JsonConvert.DeserializeObject<T>(bodyContent);

            return contentObject;
        }
    }
}
