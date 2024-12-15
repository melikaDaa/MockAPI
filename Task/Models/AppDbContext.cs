
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Tasks1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
