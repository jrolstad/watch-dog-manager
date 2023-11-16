using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using watchdogcloud.core.Models;

namespace watchdogcloud.core.Mappers
{
    public class TenantMapper
    {
        public Tenant Map(TenantData toMap)
        {
            return new Tenant(toMap.id, toMap.name, toMap.code);
        }

        public TenantData Map(Tenant toMap, string partitionKey)
        {
            return new TenantData(toMap.Id, toMap.Name, toMap.Code, partitionKey);
        }
    }
}
