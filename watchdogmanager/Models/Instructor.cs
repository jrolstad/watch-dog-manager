using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace watchdogmanager.Models
{
    public class Instructor
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
