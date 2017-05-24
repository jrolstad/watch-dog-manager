using System;
using System.Collections.Generic;

namespace WatchDogManager.EntityFramework
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
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<ScheduleAvailability> Availability { get; set; }
    }

    public class ScheduleAvailability
    {
        public int Id { get; set; }
        public DateTime At { get; set; }
        public bool IsAvailable { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}