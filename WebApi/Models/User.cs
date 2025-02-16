﻿using Microsoft.AspNetCore.Identity;

namespace WebApi.Models
{  
        public class ApplicationUser : IdentityUser
        {
            public string Document { get; set; } = string.Empty;
        }   
}
