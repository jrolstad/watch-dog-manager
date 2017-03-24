using System;
namespace watch_dog_manager.mvc.core.EntityFramework.models
{
	public class Volunteer
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string Students { get; set; }

		public string Teachers { get; set; }

		public DateTime? LastBackgroundCheck { get; set; }

		public bool KickoffAttendee { get; set; }
	}
}
