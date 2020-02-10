using System.Collections.Generic;
namespace Chef_N_Dishes.Models
{
    public class WrapperViewModel
    {
        public List<Chef> AllChefs {get; set;}
        public Dish OneDish {get; set;}
        public List<Dish> AllDishes {get; set;}
        public Chef OneChef {get; set;}
    }
}