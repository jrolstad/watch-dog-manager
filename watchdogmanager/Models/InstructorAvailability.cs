using Newtonsoft.Json;
using System.Collections.Generic;

namespace watchdogmanager.Models
{
    public class InstructorAvailability
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        public string InstructorId { get; set; }
        public string ScheduleTemplateId { get; set; }
        public string OrganizationId { get; set; }

        public string Area { get; set; }
        public string Notes { get; set; }
        public List<InstructorSessionAvailability> Availability { get; set; }
    }

    public class InstructorSessionAvailability
    {
        public string ScheduleTemplateSessionId { get; set; }
        public string DayOfWeek { get; set; }
        public bool IsAvailable { get; set; }
    }
}
