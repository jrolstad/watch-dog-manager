using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace watchdogmanager.Factories
{
    public interface ICosmosClientFactory
    {
        CosmosClient Create();
    }
}
