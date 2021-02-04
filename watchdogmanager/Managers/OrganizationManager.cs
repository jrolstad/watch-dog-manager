using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Repositories;

namespace watchdogmanager.Managers
{
    public class OrganizationManager
    {
        private readonly OrganizationRepository _repository;

        public OrganizationManager(OrganizationRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Organization> Get()
        {
            return _repository.Get()
                .ToList();
        }

        public Task<Organization> Get(string id)
        {
            var item = _repository.Get(id);

            return item;
        }

        public Task<Organization> Add(Organization toAdd)
        {
            toAdd.Id = Guid.NewGuid().ToString();
            var item = _repository.Save(toAdd);

            return item;
        }

        public Task<Organization> Update(string Id, Organization toUpdate)
        {
            toUpdate.Id = Id;
            var item = _repository.Save(toUpdate);

            return item;
        }

        public Task Delete(string id)
        {
            var item = _repository.Delete(id);

            return item;
        }
    }
}
