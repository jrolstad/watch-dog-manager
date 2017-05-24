using System;
using System.Collections.Generic;

namespace WatchDogManager.Mvc.Models.api
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public string RoomNumber { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }

    public class Schedule
    {
        public string Name { get; set; }
        
        public Dictionary<string,bool> Availablity { get; set; }
    }
}