using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Repositories;

namespace watchdogmanager.Managers
{
    public class InstructorManager
    {
        private readonly InstructorRepository _repository;

        public InstructorManager(InstructorRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Instructor> GetByOrganization(string organizationId)
        {
            return _repository.Get()
                .Where(v => v.OrganizationId == organizationId)
                .ToList();
        }

        public Task<Instructor> GetById(string organizationId, string id)
        {
            var item = _repository.Get(id);

            return item;
        }

        public Task<Instructor> Add(string organizationId, Instructor toAdd)
        {
            toAdd.Id = Guid.NewGuid().ToString();
            var updated = AddInstructorToOrganization(organizationId, toAdd);

            var item = _repository.Save(updated);

            return item;
        }

       
        public Task<Instructor> Update(string organizationId, string Id, Instructor toUpdate)
        {
            toUpdate.Id = Id;
            var updated = AddInstructorToOrganization(organizationId, toUpdate);

            var item = _repository.Save(updated);

            return item;
        }

        public Task Delete(string organizationId, string id)
        {
            var item = _repository.Delete(id);

            return item;
        }

        private static Instructor AddInstructorToOrganization(string organizationId, Instructor toUpdate)
        {
            toUpdate.OrganizationId = organizationId;

            return toUpdate;
        }

    }
}
