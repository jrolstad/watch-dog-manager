using System;
using Microsoft.AspNetCore.Http;

namespace watchdogplatform.blazor.Application.ViewModels
{
    public class UserViewModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserViewModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string Name { get; set; }

        public void Load()
        {
            this.Name = _httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }

    
}