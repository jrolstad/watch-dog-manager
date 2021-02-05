using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace watchdogmanager.blazor.Models
{
    public class Volunteer: IIdentifiable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public string InstructorId { get; set; }
    }
}
