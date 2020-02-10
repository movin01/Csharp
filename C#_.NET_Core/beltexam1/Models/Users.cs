using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace beltexam1.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "You must enter an Alias")]
        [Display(Name = "Alias:")]
        [MinLength(2, ErrorMessage = "Your Alias name must be at least 2 chars")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "You must enter a first name")]
        [Display(Name = "First Name:")]
        [MinLength(2, ErrorMessage = "Your first name must be at least 2 chars")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a last name")]
        [Display(Name = "Last Name:")]
        [MinLength(2, ErrorMessage = "Your last name must be at least 2 chars")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "You must enter a valid email address")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        [Display(Name = "Password:")]
        [MinLength(8, ErrorMessage = "Your password name must be at least 8 chars")]
        public string Password { get; set; }

        ////////////////////////////////////////////////////////////////
        // this is the connector to Thing

        public List<Association> Participants { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
    }
}
