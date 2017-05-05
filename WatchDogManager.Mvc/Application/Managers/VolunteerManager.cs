using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WatchDogManager.EntityFramework;
using WatchDogManager.Mvc.Application.Mappers;
using Volunteer = WatchDogManager.Mvc.Models.api.Volunteer;

namespace WatchDogManager.Mvc.Application.Managers
{
    public class VolunteerManager
    {
        private readonly WatchDogManagerDbContext _context;
        private readonly VolunteerMapper _mapper;

        public VolunteerManager(WatchDogManagerDbContext context, VolunteerMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ICollection<Volunteer> Get()
        {
            var volunteers = _context.Volunteers
                .Select(v => _mapper.Map(v))
                .ToList();
            return volunteers;
        }

        public Volunteer Get(int id)
        {
            var dataEntity = _context.Volunteers.FirstOrDefault(v => v.Id == id);

            var volunteer = _mapper.Map(dataEntity);

            return volunteer;
        }

        public Volunteer Create(Volunteer value)
        {
            var dataEntity = _mapper.MapNew(value);
            _context.Volunteers.Add(dataEntity);
            _context.SaveChanges();

            var result = _mapper.Map(dataEntity);

            return result;
        }

        public Volunteer Update(Volunteer value)
        {
            var dataEntity = _context.Volunteers.First(v => v.Id == value.Id);

            _mapper.MapExisting(dataEntity, value);
            _context.SaveChanges();

            var result = _mapper.Map(dataEntity);

            return result;

        }

        public void Delete(int id)
        {
            var dataEntity = _context.Volunteers.First(v => v.Id == id);

            _context.Volunteers.Remove(dataEntity);
        }
    }
}