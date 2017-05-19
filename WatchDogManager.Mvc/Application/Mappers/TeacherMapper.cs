using WatchDogManager.Mvc.Models.api;

namespace WatchDogManager.Mvc.Application.Mappers
{
    public class TeacherMapper
    {
        public Teacher Map(EntityFramework.Teacher toMap)
        {
            return new Teacher
            {
                Id = toMap.Id,
                FirstName = toMap.FirstName,
                LastName = toMap.LastName,
                RoomNumber = toMap.RoomNumber,
                Grade = toMap.Grade
            };
        }

        public EntityFramework.Teacher MapNew(Teacher toMap)
        {
            var data = new EntityFramework.Teacher();
            MapExisting(data, toMap);

            return data;
        }
        public EntityFramework.Teacher MapExisting(EntityFramework.Teacher data, Teacher toMap)
        {
            data.Id = toMap.Id;
            data.FirstName = toMap.FirstName;
            data.LastName = toMap.LastName;
            data.RoomNumber = toMap.RoomNumber;
            data.Grade = toMap.Grade;

            return data;
        }
    }
}