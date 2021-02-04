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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public string Room { get; set; }
        public string Area { get; set; }
        public string OrganizationId { get; set; }
    }
}
