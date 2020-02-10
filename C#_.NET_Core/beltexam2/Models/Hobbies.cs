using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace beltexam2.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }

        [Required(ErrorMessage = "You must enter a Hobby Name")]
        [Display(Name = "Name:")]
        [MinLength(2, ErrorMessage = "The Hobby Name must be at least 2 chars")]
        public string HobbyName { get; set; }

        [Required(ErrorMessage = "You must enter a description")]
        [Display(Name = "Description:")]
        [MinLength(2, ErrorMessage = "The description must be at least 2 chars")]
        public string HobbyDescription { get; set; }
        public DateTime HobbyDate { get; set; }
        ////////////////////////////////////////////////////////////////
        // this is the connector to Thing

        public List<Association> Responses { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public class PastDateValidationAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ((DateTime)value < DateTime.Now)
                {
                    return new ValidationResult("Date of Birth must be in the Future");
                }
                return ValidationResult.Success;
            }
        }
    }
}