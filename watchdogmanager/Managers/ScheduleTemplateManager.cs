using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.Models;
using watchdogmanager.Repositories;

namespace watchdogmanager.Managers
{
    public class ScheduleTemplateManager
    {
        private readonly ScheduleTemplateRepository _repository;

        public ScheduleTemplateManager(ScheduleTemplateRepository repository)
        {
            _repository = repository;
        }

        public ICollection<ScheduleTemplate> GetByOrganization(string organizationId)
        {
            return _repository.Get()
                .Where(v => v.OrganizationId == organizationId)
                .ToList();
        }

        public Task<ScheduleTemplate> GetById(string organizationId, string id)
        {
            var item = _repository.Get(id);

            return item;
        }

        public Task<ScheduleTemplate> Add(string organizationId, ScheduleTemplate toAdd)
        {
            toAdd.Id = Guid.NewGuid().ToString();
            AddScheduleTemplateToOrganization(organizationId, toAdd);
            AssignIdentifiersToSession(toAdd, keepExistingIds: false);

            var item = _repository.Save(toAdd);

            return item;
        }

       
        public Task<ScheduleTemplate> Update(string organizationId, string Id, ScheduleTemplate toUpdate)
        {
            toUpdate.Id = Id;
            AddScheduleTemplateToOrganization(organizationId, toUpdate);
            AssignIdentifiersToSession(toUpdate, keepExistingIds: true);

            var item = _repository.Save(toUpdate);

            return item;
        }

        public Task Delete(string organizationId, string id)
        {
            var item = _repository.Delete(id);

            return item;
        }

        private static void AddScheduleTemplateToOrganization(string organizationId, ScheduleTemplate toUpdate)
        {
            toUpdate.OrganizationId = organizationId;
        }

        private static void AssignIdentifiersToSession(ScheduleTemplate toUpdate, bool keepExistingIds)
        {
            if (toUpdate.Sessions != null)
            {
                foreach(var session in toUpdate.Sessions)
                {
                    if(keepExistingIds)
                    {
                        session.Id = string.IsNullOrWhiteSpace(session.Id) ? Guid.NewGuid().ToString() : session.Id;
                    }
                    else
                    {
                        session.Id = Guid.NewGuid().ToString();
                    }

                }
            }
        }

    }
}
