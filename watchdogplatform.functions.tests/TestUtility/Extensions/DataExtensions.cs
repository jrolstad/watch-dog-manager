using System;
using watchdogplatform.entityframework;

namespace watchdogplatform.functions.tests.TestUtility.Extensions
{
    public static class DataExtensions
    {
        public static void WithVolunteer(this TestCompositionRoot root, string name, string email=null)
        {
            var context = root.Get<WatchDogPlatformDbContext>();

            context.Volunteers.Add(new entityframework.Models.Volunteer
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Email = email
            });

            context.SaveChanges();
        }

        public static void WithOrganization(this TestCompositionRoot root, string name, string affiliatedWith = null)
        {
            var context = root.Get<WatchDogPlatformDbContext>();

            context.Organizations.Add(new entityframework.Models.Organization
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                AffiliatedWith = affiliatedWith
            });

            context.SaveChanges();
        }
    }
}