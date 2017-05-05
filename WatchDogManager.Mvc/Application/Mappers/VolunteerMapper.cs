using WatchDogManager.Mvc.Models.api;

namespace WatchDogManager.Mvc.Application.Mappers
{
    public class VolunteerMapper

    {
        public Volunteer Map(EntityFramework.Volunteer toMap)
        {
            return new Volunteer
            {
                Id = toMap.Id,
                Name = toMap.Name,
                Email = toMap.Email,
                Phone = toMap.Phone,
                BackgroundCheck = toMap.BackgroundCheck,
                Students = toMap.Students,
                Teachers = toMap.Teachers
            };
        }

        public EntityFramework.Volunteer MapNew(Volunteer toMap)
        {
            var data = new EntityFramework.Volunteer();
            MapExisting(data, toMap);

            return data;
        }
        public EntityFramework.Volunteer MapExisting(EntityFramework.Volunteer data, Volunteer toMap)
        {
            data.Name = toMap.Name;
            data.Email = toMap.Email;
            data.Phone = toMap.Phone;
            data.BackgroundCheck = toMap.BackgroundCheck;
            data.Students = toMap.Students;
            data.Teachers = toMap.Teachers;

            return data;
        }
    }
}