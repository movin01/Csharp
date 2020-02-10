using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Chef_N_Dishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "You must enter a Dish Name")]
        [Display(Name = "Name of Dish:")]
        [MinLength(2, ErrorMessage = "The name must be at least 2 chars")]
        public string DishName { get; set; }

        [Required(ErrorMessage = "You must enter a description")]
        [Display(Name = "Description:")]
        [MinLength(2, ErrorMessage = "The description must be at least 2 chars")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Calories greater than one")]
        [Display(Name = "Calories:")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a number greater than 1")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "You must enter a number greater than one")]
        [Display(Name = "Tastiness:")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a number greater than 1")]
        public int Tastiness { get; set; }


        ////////////////////////////////////////////////////////////////
        // this is the connector to Thing
        public int ChefID {get; set;}
        public Chef Creator {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
