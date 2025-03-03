using BackendBatch7.Domain.Entities;
using BackendBatch7.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BackendBatch7.API.Services;

public class SeedingWorker(IServiceScopeFactory scopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await SeedDataAsync();
    }

    private async Task SeedDataAsync()
    {
        using var scope = scopeFactory.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
        var now = DateTime.UtcNow;
        var departments = new List<Department>
        {
            new() { Id = 0, Department_name = "Hành chính", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, Department_name = "Nhân sự", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, Department_name = "Kỹ thuật", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, Department_name = "Phát triển phần mềm", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, Department_name = "Vận hành", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, Department_name = "Hỗ trợ khách hàng", CreatedBy = "System", CreatedDate = now }
        };

        var users = new List<User> {
            new() { Id = 0, First_name = "Admin first name", Last_name = "Admin last name", Email = "admin@gmail.com", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, First_name = "Hoàng Thái", Last_name = "Dương", Email = "duonght@gmail.com", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, First_name = "Trần Phương", Last_name = "Thảo", Email = "thaotp@gmail.com", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, First_name = "Hoàng Thị", Last_name = "Sophie", Email = "sophie@gmail.com", CreatedBy = "System", CreatedDate = now }
        };

        var roles = new List<Role> {
            new() { Id = 0, Role_name = "Trưởng phòng", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, Role_name = "Trưởng nhóm", CreatedBy = "System", CreatedDate = now },
            new() { Id = 0, Role_name = "Nhân viên", CreatedBy = "System", CreatedDate = now },
        };


        await context.Department.AddRangeAsync(departments);
        await context.User.AddRangeAsync(users);
        await context.Role.AddRangeAsync(roles);
        await context.SaveChangesAsync();
        Console.WriteLine("Seeding complete!");
    }
}
