using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Task.Model;

namespace Task.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {         } 
        public DbSet<User> Users { get; set; }  
    }
}
