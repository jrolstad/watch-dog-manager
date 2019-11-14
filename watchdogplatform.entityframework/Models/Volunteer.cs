using System;
using System.Collections.Generic;

namespace watchdogplatform.entityframework.Models
{
    public class Volunteer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CriminalHistoryStatus> CriminalHistoryChecks { get; set; }
    }

    public class CriminalHistoryStatus
    {
        public string Id { get; set; }
        public DateTime ResponseAt { get; set; }
        public bool Passed { get; set; }
    }
}