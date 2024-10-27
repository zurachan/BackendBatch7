using BackendBatch7.Domain;
using BackendBatch7.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.API.Services;

public class SeedingWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public SeedingWorker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await SeedDataAsync();
    }

    private async Task SeedDataAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
        var departments = new List<Department>
        {
            new Department { Id = 1, Department_name = "Hành chính", CreatedBy = "System", CreatedDate = DateTime.Now },
            new Department { Id = 2, Department_name = "Nhân sự", CreatedBy = "System", CreatedDate = DateTime.Now },
            new Department { Id = 3, Department_name = "Kỹ thuật", CreatedBy = "System", CreatedDate = DateTime.Now },
            new Department { Id = 4, Department_name = "Phát triển phần mềm", CreatedBy = "System", CreatedDate = DateTime.Now },
            new Department { Id = 5, Department_name = "Vận hành", CreatedBy = "System", CreatedDate = DateTime.Now },
            new Department { Id = 6, Department_name = "Hỗ trợ khách hàng", CreatedBy = "System", CreatedDate = DateTime.Now }
        };

        var users = new List<User> {
            new User { Id = 1, First_name = "Admin first name", Last_name = "Admin last name", Email = "admin@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now },
            new User { Id = 2, First_name = "Hoàng Thái", Last_name = "Dương", Email = "duonght@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now },
            new User { Id = 3, First_name = "Trần Phương", Last_name = "Thảo", Email = "thaotp@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now },
            new User { Id = 4, First_name = "Hoàng Thị", Last_name = "Sophie", Email = "sophie@gmail.com", CreatedBy = "System", CreatedDate = DateTime.Now }
        };

        var roles = new List<Role> {
            new Role { Id = 1, Role_name = "Trưởng phòng", CreatedBy = "System", CreatedDate = DateTime.Now },
            new Role { Id = 2, Role_name = "Trưởng nhóm", CreatedBy = "System", CreatedDate = DateTime.Now },
            new Role { Id = 3, Role_name = "Nhân viên", CreatedBy = "System", CreatedDate = DateTime.Now },
        };


        await context.Department.AddRangeAsync(departments);
        await context.User.AddRangeAsync(users);
        await context.Role.AddRangeAsync(roles);
        await context.SaveChangesAsync();
        Console.WriteLine("Seeding complete!");
    }
}
