using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace watchdogmanager.Models
{
    public class Volunteer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public List<Student> Students { get; set; }
        public List<CriminalHistory> CriminalHistoryChecks { get; set; }
        public List<string> Organizations { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public string InstructorId { get; set; }
    }

    public class CriminalHistory
    {
        public DateTime ResponseAt { get; set; }
        public CriminalHistoryStatus Status { get; set; }
    }

    public enum CriminalHistoryStatus
    {
        Failed,
        Passed
    }
}
