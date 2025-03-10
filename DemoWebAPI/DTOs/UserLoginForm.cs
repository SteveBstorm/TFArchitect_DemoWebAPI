﻿using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.DTOs
{
    public class UserLoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
