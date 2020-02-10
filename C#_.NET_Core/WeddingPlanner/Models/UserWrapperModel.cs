using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class WrapperViewModel
    {
        public User RegisteredUser {get; set;}
        // public List<User> AllUsers { get; set; }
        // public Thing OneThing { get; set; }
        // public List<Thing> AllThings { get; set; }

        public LoggedInUser LoggedUser { get; set; }

    }
}


