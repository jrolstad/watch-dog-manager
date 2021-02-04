using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Repositories;

namespace watchdogmanager.Managers
{
    public class InstructorAvailabilityManager
    {
        private readonly InstructorAvailabilityRepository _repository;

        public InstructorAvailabilityManager(InstructorAvailabilityRepository repository)
        {
            _repository = repository;
        }

        public ICollection<InstructorAvailability> GetByOrganization(string organizationId)
        {
            return _repository.Get()
                .Where(v => v.OrganizationId == organizationId)
                .ToList();
        }

        public Task<InstructorAvailability> GetById(string organizationId, string id)
        {
            var item = _repository.Get(id);

            return item;
        }

        public Task<InstructorAvailability> Add(string organizationId, InstructorAvailability toAdd)
        {
            toAdd.Id = Guid.NewGuid().ToString();
            AddAvailabilityToOrganization(organizationId, toAdd);

            var item = _repository.Save(toAdd);

            return item;
        }

       
        public Task<InstructorAvailability> Update(string organizationId, string Id, InstructorAvailability toUpdate)
        {
            toUpdate.Id = Id;
            AddAvailabilityToOrganization(organizationId, toUpdate);

            var item = _repository.Save(toUpdate);

            return item;
        }

        public Task Delete(string organizationId, string id)
        {
            var item = _repository.Delete(id);

            return item;
        }

        private static void AddAvailabilityToOrganization(string organizationId, InstructorAvailability toUpdate)
        {
            toUpdate.OrganizationId = organizationId;
        }


    }
}
