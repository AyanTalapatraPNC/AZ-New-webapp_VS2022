using Microsoft.EntityFrameworkCore;

namespace AZ_New_webapp_VS2022.Models

{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
