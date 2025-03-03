using BackendBatch7.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
    }
}
