using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;



namespace WeddingPlanner.Models
{
    public class weddingswrappermodel
    {
        public List<Wedding> allweddings { get; set; }
        public User user { get; set; }
        public User LoggedInUser { get; set;}
    }

}