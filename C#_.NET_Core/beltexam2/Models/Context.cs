using Microsoft.EntityFrameworkCore;


namespace beltexam2.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Hobby> Hobbies {get;set;}
        public DbSet<Association> Associations {get;set;}
    }
}