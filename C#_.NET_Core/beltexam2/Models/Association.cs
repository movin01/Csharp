using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace beltexam2.Models
{
    public class Association
    {
        public int AssociationId { get; set; }
        public int UserId { get; set; }
        public int HobbyId { get; set; }
        public User addtohobbys { get; set; }
        public Hobby aHobby { get; set; }

    }
}
