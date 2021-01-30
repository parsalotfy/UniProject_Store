using Microsoft.EntityFrameworkCore;
using SharedProject;

namespace Store_API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./StaticFiles/test.db");
        }

        public DbSet<Person> People { get; set; }
    }
}
