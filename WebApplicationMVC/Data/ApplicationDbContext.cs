using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}