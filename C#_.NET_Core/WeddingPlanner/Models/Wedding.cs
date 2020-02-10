using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{

    public class Wedding
    {
        [Key]

        public int WeddingID { get; set;}

        [Required(ErrorMessage = "You must enter a name")]
        [Display(Name = "Wedder One:")]
        [MinLength(2, ErrorMessage = "The Name must be at least 2 charactors")]
        public string WedderOne { get; set; }

        [Required(ErrorMessage = "You must enter a name")]
        [Display(Name = "Wedder Two:")]
        [MinLength(2, ErrorMessage = "The Name must be at least 2 charactors")]
        public string WedderTwo { get; set; }

        [Required (ErrorMessage = "You must enter a Valid Date")]
        [Display(Name = "Date:")]
        [FutureDateValidation]

        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Address:")]
        [MinLength(2, ErrorMessage = "Enter an address with more than 2 charactors")]
        public String Address { get; set; }
// Responses = Guests
        public List<Association> Responses { get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        public int CreatorId { get; set;}
        public User Creator { get; set;}
        

    }

    public class FutureDateValidationAttribute : ValidationAttribute
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