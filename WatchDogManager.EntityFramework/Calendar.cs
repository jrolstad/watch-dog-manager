using System;

namespace WatchDogManager.EntityFramework
{
    public class CalendarDay
    {
        public int Id { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}