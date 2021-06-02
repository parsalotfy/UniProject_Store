using Microsoft.EntityFrameworkCore;
using SharedProject;

namespace Store_API.Models
{
    public class StoreContext : DbContext
    {
        
         public StoreContext(DbContextOptions<StoreContext> options) : base(options)
         {

         }
        
        //public DbSet<Person> People { get; set; }
        public DbSet<Person> People { get; set; }

    }
}
