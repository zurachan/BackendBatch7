using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.Domains
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Department_name = "Phát triển phần mềm", Created_date = DateTime.Now, IsDeleted = false },
                new Department { Id = 2, Department_name = "Vận hành", Created_date = DateTime.Now, IsDeleted = false },
                new Department { Id = 3, Department_name = "Hỗ trợ khách hàng", Created_date = DateTime.Now, IsDeleted = false });

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, First_name = "A", Last_name = "Nguyen Van", Email = "nguyenvanA@gmail.com", Created_date = DateTime.Now },
               new User { Id = 2, First_name = "B", Last_name = "Nguyen Van", Email = "nguyenvanB@gmail.com", Created_date = DateTime.Now },
               new User { Id = 3, First_name = "C", Last_name = "Nguyen Van", Email = "nguyenvanC@gmail.com", Created_date = DateTime.Now },
               new User { Id = 4, First_name = "D", Last_name = "Nguyen Van", Email = "nguyenvanD@gmail.com", Created_date = DateTime.Now },
               new User { Id = 5, First_name = "E", Last_name = "Nguyen Van", Email = "nguyenvanE@gmail.com", Created_date = DateTime.Now },
               new User { Id = 6, First_name = "F", Last_name = "Nguyen Van", Email = "nguyenvanF@gmail.com", Created_date = DateTime.Now },
               new User { Id = 7, First_name = "G", Last_name = "Nguyen Van", Email = "nguyenvanG@gmail.com", Created_date = DateTime.Now },
               new User { Id = 8, First_name = "H", Last_name = "Nguyen Van", Email = "nguyenvanH@gmail.com", Created_date = DateTime.Now },
               new User { Id = 9, First_name = "I", Last_name = "Nguyen Van", Email = "nguyenvanI@gmail.com", Created_date = DateTime.Now },
               new User { Id = 10, First_name = "J", Last_name = "Nguyen Van", Email = "nguyenvanJ@gmail.com", Created_date = DateTime.Now },
               new User { Id = 11, First_name = "K", Last_name = "Nguyen Van", Email = "nguyenvanK@gmail.com", Created_date = DateTime.Now },
               new User { Id = 12, First_name = "L", Last_name = "Nguyen Van", Email = "nguyenvanL@gmail.com", Created_date = DateTime.Now },
               new User { Id = 13, First_name = "M", Last_name = "Nguyen Van", Email = "nguyenvanM@gmail.com", Created_date = DateTime.Now },
               new User { Id = 14, First_name = "N", Last_name = "Nguyen Van", Email = "nguyenvanN@gmail.com", Created_date = DateTime.Now },
               new User { Id = 15, First_name = "O", Last_name = "Nguyen Van", Email = "nguyenvanO@gmail.com", Created_date = DateTime.Now },
               new User { Id = 16, First_name = "P", Last_name = "Nguyen Van", Email = "nguyenvanP@gmail.com", Created_date = DateTime.Now },
               new User { Id = 17, First_name = "Q", Last_name = "Nguyen Van", Email = "nguyenvanQ@gmail.com", Created_date = DateTime.Now },
               new User { Id = 18, First_name = "R", Last_name = "Nguyen Van", Email = "nguyenvanR@gmail.com", Created_date = DateTime.Now },
               new User { Id = 19, First_name = "S", Last_name = "Nguyen Van", Email = "nguyenvanS@gmail.com", Created_date = DateTime.Now },
               new User { Id = 20, First_name = "T", Last_name = "Nguyen Van", Email = "nguyenvanT@gmail.com", Created_date = DateTime.Now },
               new User { Id = 21, First_name = "U", Last_name = "Nguyen Van", Email = "nguyenvanU@gmail.com", Created_date = DateTime.Now },
               new User { Id = 22, First_name = "V", Last_name = "Nguyen Van", Email = "nguyenvanV@gmail.com", Created_date = DateTime.Now },
               new User { Id = 23, First_name = "W", Last_name = "Nguyen Van", Email = "nguyenvanW@gmail.com", Created_date = DateTime.Now },
               new User { Id = 24, First_name = "X", Last_name = "Nguyen Van", Email = "nguyenvanX@gmail.com", Created_date = DateTime.Now },
               new User { Id = 25, First_name = "Y", Last_name = "Nguyen Van", Email = "nguyenvanY@gmail.com", Created_date = DateTime.Now },
               new User { Id = 26, First_name = "Z", Last_name = "Nguyen Van", Email = "nguyenvanZ@gmail.com", Created_date = DateTime.Now }
               );
        }

    }
}
