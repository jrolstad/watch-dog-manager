using System.Collections.Generic;
using System.Linq;
using WatchDogManager.EntityFramework;
using WatchDogManager.Mvc.Application.Mappers;
using Teacher = WatchDogManager.Mvc.Models.api.Teacher;

namespace WatchDogManager.Mvc.Application.Managers
{
    public class TeacherManager
    {
        private readonly WatchDogManagerDbContext _context;
        private readonly TeacherMapper _mapper;

        public TeacherManager(WatchDogManagerDbContext context, TeacherMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ICollection<Models.api.Teacher> Get()
        {
            var volunteers = _context.Teachers
                .Select(v => _mapper.Map(v))
                .ToList();
            return volunteers;
        }

        public Models.api.Teacher Get(int id)
        {
            var dataEntity = _context.Teachers.FirstOrDefault(v => v.Id == id);

            var volunteer = _mapper.Map(dataEntity);

            return volunteer;
        }

        public Models.api.Teacher Create(Models.api.Teacher value)
        {
            var dataEntity = _mapper.MapNew(value);
            _context.Teachers.Add(dataEntity);
            _context.SaveChanges();

            var result = _mapper.Map(dataEntity);

            return result;
        }

        public Models.api.Teacher Update(Teacher value)
        {
            var dataEntity = _context.Teachers.First(v => v.Id == value.Id);

            _mapper.MapExisting(dataEntity, value);
            _context.SaveChanges();

            var result = _mapper.Map(dataEntity);

            return result;

        }

        public void Delete(int id)
        {
            var dataEntity = _context.Teachers.First(v => v.Id == id);

            _context.Teachers.Remove(dataEntity);
            _context.SaveChanges();
        }
    }
}