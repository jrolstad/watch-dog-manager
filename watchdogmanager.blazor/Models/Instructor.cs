using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Models
{
    public class Instructor: IIdentifiable
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public string Room { get; set; }
    }
}
