using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace watchdogmanager.Models
{
    public class Organization
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
    }
}
