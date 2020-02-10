using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_and_Registration.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "You must enter a first name!")]
        [Display(Name = "First Name:")]
        [MinLength(2, ErrorMessage = "Your first name must be atleast 2 characters long!")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a Last name!")]
        [Display(Name = "Last Name:")]
        [MinLength(2, ErrorMessage = "Your Last name must be atleast 2 characters long!")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "You must enter an Email Address!")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Will not be mapped to your users table!
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}