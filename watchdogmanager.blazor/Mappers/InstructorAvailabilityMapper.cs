using System;
using System.Collections.Generic;
using System.Linq;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Mappers
{
    public class InstructorAvailabilityMapper
    {
        public List<InstructorAvailability> Map(string instructorId, List<InstructorAvailability> existing, List<ScheduleTemplate> scheduleTemplates)
        {
            var availabilityById = existing.ToDictionary(a => a.ScheduleTemplateId);

            foreach(var template in scheduleTemplates)
            {
                var availability = MapTemplateToAvailability(instructorId, availabilityById, template);
                MapSessionAvailability(template, availability);
            }

            return availabilityById.Values.ToList();
        }

        private static InstructorAvailability MapTemplateToAvailability(string instructorId, Dictionary<string, InstructorAvailability> availabilityById, ScheduleTemplate template)
        {
            if (!availabilityById.ContainsKey(template.Id))
            {
                availabilityById.Add(template.Id, new InstructorAvailability
                {
                    ScheduleTemplateId = template.Id,
                    Availability = new List<InstructorSessionAvailability>(),
                });
            }

            var item = availabilityById[template.Id];
            item.InstructorId = instructorId;
            item.Name = template.Name;

            return item;
        }

        private static void MapSessionAvailability(ScheduleTemplate template, InstructorAvailability availability)
        {
            var availableSessionsById = availability.Availability.ToDictionary(a => a.ScheduleTemplateSessionId);

            var instructorLedSessions = template.Sessions
                .Where(s => s.IsInstructorLed)
                .ToList();

            foreach (var session in instructorLedSessions)
            {
                var item = MapSession(availableSessionsById, session);
                MapDaysOfTheWeek(item);
            }

            RemoveOrphanedSessions(availableSessionsById, instructorLedSessions);

            availability.Availability = availableSessionsById.Values
                .OrderBy(a => a.Start)
                .ToList();
        }

        private static InstructorSessionAvailability MapSession(Dictionary<string, InstructorSessionAvailability> availableSessionsById, ScheduleTemplateSession session)
        {
            if (!availableSessionsById.ContainsKey(session.Id))
            {
                availableSessionsById.Add(session.Id, new InstructorSessionAvailability
                {
                    ScheduleTemplateSessionId = session.Id,
                    IsAvailable = new Dictionary<string, bool>(),

                });
            }

            var item = availableSessionsById[session.Id];
            item.Start = session.Start;
            return item;
        }

        private static void RemoveOrphanedSessions(Dictionary<string, InstructorSessionAvailability> availableSessionsById, List<ScheduleTemplateSession> instructorLedSessions)
        {
            var orphanedAvailability = availableSessionsById.Values
                .Where(a => !instructorLedSessions.Any(s => s.Id == a.ScheduleTemplateSessionId))
                .ToList(); ;

            orphanedAvailability.ForEach(a => availableSessionsById.Remove(a.ScheduleTemplateSessionId));
        }

        private static void MapDaysOfTheWeek(InstructorSessionAvailability item)
        {
            foreach (var day in GetDaysOfTheWeek())
            {
                var dayName = day.ToString();
                if (!item.IsAvailable.ContainsKey(dayName))
                {
                    item.IsAvailable.Add(dayName, false);
                }
            }
        }

        private static IEnumerable<DayOfWeek> GetDaysOfTheWeek()
        {
            yield return DayOfWeek.Monday;
            yield return DayOfWeek.Tuesday;
            yield return DayOfWeek.Wednesday;
            yield return DayOfWeek.Thursday;
            yield return DayOfWeek.Friday;
        }
        
    }
}
