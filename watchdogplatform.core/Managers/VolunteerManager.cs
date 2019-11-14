using System.Collections.Generic;
using System.Threading.Tasks;
using watchdogplatform.core.Models;
using watchdogplatform.core.Repositories;

namespace watchdogplatform.core.Managers
{
    public class VolunteerManager
    {
        private readonly VolunteerRepository _repository;

        public VolunteerManager(VolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Volunteer>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Volunteer> Save(Volunteer volunteerData)
        {
            return await _repository.Save(volunteerData);
        }
    }
}