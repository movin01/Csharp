using Microsoft.EntityFrameworkCore;
namespace Chef_N_Dishes.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes {get;set;}
        public DbSet<Chef> Chefs {get;set;}
    }
}