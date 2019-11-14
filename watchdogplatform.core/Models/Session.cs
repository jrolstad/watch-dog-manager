using System;
using System.Dynamic;

namespace watchdogplatform.core.Models
{
    public class Session
    {
        public string Id { get; set; }
        public string OrganizationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}