using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Chef { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Calories { get; set; }
        [Required]
        [Range(1, 5)]
        public int Tastiness { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }
    }
}


