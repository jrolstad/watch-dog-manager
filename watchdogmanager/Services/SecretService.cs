using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Text;

namespace watchdogmanager.Services
{
    public class SecretService : ISecretService
    {
        private readonly SecretClient _client;

        public SecretService(SecretClient client)
        {
            _client = client;
        }

        public string GetSecret(string name)
        {
            var response = _client.GetSecret(name);
            return response.Value?.Value;
        }
    }

    public interface ISecretService
    {
        string GetSecret(string name);
    }
}
