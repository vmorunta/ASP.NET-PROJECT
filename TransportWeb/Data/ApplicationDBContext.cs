using Microsoft.EntityFrameworkCore;
using TransportWeb.Models;

namespace TransportWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { 

        }

        public DbSet<Post> Posts { get; set; }

    }
}
