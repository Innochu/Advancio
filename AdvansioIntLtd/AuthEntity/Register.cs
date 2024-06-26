﻿using AdvansioIntLtd.Enum;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AdvansioIntLtd.AuthEntity
{
    public class Register
    {
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "PhoneNumber address is required.")]

        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password address is required.")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
       
        public Gender Gender { get; set; }
    }
}
