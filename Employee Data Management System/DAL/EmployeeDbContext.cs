using Employee_Data_Management_System.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Data_Management_System.DAL
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
