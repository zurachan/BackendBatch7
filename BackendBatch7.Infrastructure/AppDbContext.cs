using BackendBatch7.Domain;
using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Khởi tạo dữ liệu mẫu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, First_name = "Admin first name", Last_name = "Admin last name", Email = "admin@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now },
                new User { Id = 2, First_name = "Hoàng Thái", Last_name = "Dương", Email = "duonght@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now },
                new User { Id = 3, First_name = "Trần Phương", Last_name = "Thảo", Email = "thaotp@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now },
                new User { Id = 4, First_name = "Hoàng Thị", Last_name = "Sophie", Email = "sophie@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now }
                );
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Department_name = "Hành chính", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Department { Id = 2, Department_name = "Nhân sự", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Department { Id = 3, Department_name = "Kỹ thuật", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Department { Id = 4, Department_name = "Phát triển phần mềm", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Department { Id = 5, Department_name = "Vận hành", CreatedBy = "System", CreatedDate = DateTime.Now },
                new Department { Id = 6, Department_name = "Hỗ trợ khách hàng", CreatedBy = "System", CreatedDate = DateTime.Now }
                );
        }

        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
