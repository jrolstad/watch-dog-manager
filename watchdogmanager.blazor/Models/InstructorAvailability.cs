using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Models
{
    public class InstructorAvailability:IIdentifiable
    {
        public string Id { get; set; }

        public string InstructorId { get; set; }
        public string ScheduleTemplateId { get; set; }
        public string Name { get; set; }

        public string Notes { get; set; }
        public List<InstructorSessionAvailability> Availability { get; set; }
    }

    public class InstructorSessionAvailability
    {
        public string ScheduleTemplateSessionId { get; set; }
        public DateTime Start { get; set; }
        public string DayOfWeek { get; set; }
        public bool IsAvailable { get; set; }
    }
}
