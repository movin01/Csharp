using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class WrapperViewModelAll
    {
        public User LoggedInUser { get; set; }
         public List<Wedding> AllWeddings { get; set; }
         public List<User> AllUsers {get; set;}
         public User OneUser { get; set;}
         public Wedding OneWedding { get; set;}
         public Association OneAssociation { get; set;}
         
    }
}