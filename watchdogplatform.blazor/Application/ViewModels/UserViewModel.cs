using System;

namespace watchdogplatform.blazor.Application.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public void Load()
        {
            this.Name = Guid.NewGuid().ToString();
        }
    }

    
}