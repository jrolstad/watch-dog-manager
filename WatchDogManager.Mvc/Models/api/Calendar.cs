using System;

namespace WatchDogManager.Mvc.Models.api
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Volunteer { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}