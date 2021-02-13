using System;
using System.Collections.Generic;

namespace watchdogmanager.blazor.Models
{
    public class ScheduleTemplate:IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
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
