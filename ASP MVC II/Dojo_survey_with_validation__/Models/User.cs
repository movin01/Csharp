using System.ComponentModel.DataAnnotations;
namespace Dojo_survey_with_validation__.Models
{
    public class User
    {
        [Required (ErrorMessage = "Please type a name")] 
        [MinLength(2, ErrorMessage = "Please type more than 2 letters!")]
        public string Firstname { get; set; }
        [Required]
        public string Location { get; set; }

        public string Language { get; set; }
        [MaxLength(20, ErrorMessage = "Please type something less than or  letters")]
        public string Comment { get; set; }
        
    }



}