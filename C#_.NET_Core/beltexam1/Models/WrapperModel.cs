using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace beltexam1.Models
{
    public class WrapperViewModelAll
    {
        public User LoggedInUser { get; set; }
        public List<Idea> AllIdeas { get; set; }
        public User OneUser { get; set; }
        public List<User> AllUsers { get; set; }
        public Idea OneIdea { get; set; }
        public Association OneAssociation { get; set; }
    }
}
