using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace watchdogmanager.Models
{
    public class ScheduleTemplate
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string OrganizationId { get; set; }
        public List<ScheduleTemplateSession> Sessions { get; set; }
        
    }
    public class ScheduleTemplateSession
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsInstructorLed { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
