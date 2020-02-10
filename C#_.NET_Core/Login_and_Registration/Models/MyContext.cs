using Microsoft.EntityFrameworkCore;

    namespace Login_and_Registration.Models
    {
        public class MyContext : DbContext
        {
            public MyContext(DbContextOptions options) : base(options) { }
            public DbSet<User> User { get; set; } //as many as needed
        }
    }
