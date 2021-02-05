using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchdogmanager.blazor.Components.Organizations;
using watchdogmanager.blazor.Models;

namespace watchdogmanager.blazor.Components.Volunteers
{
    public partial class VolunteerDetail
    {
        [Parameter]
        public Volunteer Data { get; set; }

        GenericCommand<Student> DeleteStudentCommand { get; set; }

        protected override void OnInitialized()
        {
            DeleteStudentCommand = new GenericCommand<Student>(DeleteStudent);
        }

        protected override void OnParametersSet()
        {
            if(Data!=null)
            {
                Data.Students = Data.Students ?? new List<Student>();
            }
            
        }

        private void AddStudent()
        {
            if (Data?.Students == null) Data.Students = new List<Student>();
            Data.Students.Add(new Student());
        }

        private async Task DeleteStudent(Student student)
        {
            Data.Students.Remove(student);
            StateHasChanged();
        }
    }
}
