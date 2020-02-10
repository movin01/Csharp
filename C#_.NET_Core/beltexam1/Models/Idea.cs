using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace beltexam1.Models
{
    public class Idea
    {
        [Key]
        public int IdeaId { get; set; }

        [Required(ErrorMessage = "You must enter an Idea")]
        [Display(Name = "Idea:")]
        [MinLength(5, ErrorMessage = "The idea must be at least 5 chars")]
        public string goodIdea { get; set; }

        public DateTime ThingDate { get; set; }

        // this is the connector
        // Responses = people who liked the idea
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