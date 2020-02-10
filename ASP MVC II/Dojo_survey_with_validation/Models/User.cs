using System.ComponentModel.DataAnnotations;
namespace Dojo_survey_with_model.Models
{
    public class User
    {
        [Required (ErrorMessage = "Please type something more than 2 letters")] 
        [MinLength(2)]
        public string Firstname { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Language { get; set; }
        [MaxLength(20)]
        public string Comment { get; set; }
    }



}