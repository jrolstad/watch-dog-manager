using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Repositories;

namespace watchdogmanager.Managers
{
    public class VolunteerManager
    {
        private readonly VolunteerRepository _repository;

        public VolunteerManager(VolunteerRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Volunteer> GetByOrganization(string organizationId)
        {
            return _repository.Get()
                .Where(v=>v.Organizations.Contains(organizationId))
                .ToList();
        }

        public Task<Volunteer> GetById(string organizationId, string id)
        {
            var item = _repository.Get(id);

            return item;
        }

        public Task<Volunteer> Add(string organizationId, Volunteer toAdd)
        {
            toAdd.Id = Guid.NewGuid().ToString();
            var updated = AddVolunteerToOrganization(organizationId, toAdd);

            var item = _repository.Save(updated);

            return item;
        }

       
        public Task<Volunteer> Update(string organizationId, string Id, Volunteer toUpdate)
        {
            toUpdate.Id = Id;
            var updated = AddVolunteerToOrganization(organizationId, toUpdate);

            var item = _repository.Save(updated);

            return item;
        }

        public Task Delete(string organizationId, string id)
        {
            var item = _repository.Delete(id);

            return item;
        }

        private static Volunteer AddVolunteerToOrganization(string organizationId, Volunteer toAdd)
        {
            if (toAdd.Organizations == null)
            {
                toAdd.Organizations = new List<string>();
            }
            if (!toAdd.Organizations.Contains(organizationId))
            {
                toAdd.Organizations.Add(organizationId);
            }

            return toAdd;
        }

    }
}
