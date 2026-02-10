using employee_crud.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_crud.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employee { get; set; }
    public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
    public DbSet<EmployeePhone> EmployeePhone { get; set; }
}