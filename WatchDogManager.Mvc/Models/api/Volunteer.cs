using System;

namespace WatchDogManager.Mvc.Models.api
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BackgroundCheck { get; set; }
        public string Students { get; set; }
        public string Teachers { get; set; }
    }
}