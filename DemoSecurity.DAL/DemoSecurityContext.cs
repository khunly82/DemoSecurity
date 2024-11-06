using DemoSecurity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoSecurity.DAL
{
    public class DemoSecurityContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DemoSecurityContext(DbContextOptions options): base(options)
        {
            
        }
    }
}
