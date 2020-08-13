using System;
using watchdogplatform.entityframework;

namespace watchdogplatform.functions.tests.TestUtility.Extensions
{
    public static class DataExtensions
    {
        public static void WithOrganization(this TestCompositionRoot root, string name)
        {
            var context = root.Get<WatchDogPlatformDbContext>();

            context.Organizations.Add(new entityframework.Models.Organization
            {
                Id = Guid.NewGuid().ToString(),
                Name = name
            });

            context.SaveChanges();
        }
    }
}