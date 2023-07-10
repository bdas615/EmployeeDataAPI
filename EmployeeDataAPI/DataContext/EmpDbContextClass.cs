using EmployeeDataAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataAPI.DataContext
{
    public class EmpDbContextClass : DbContext
    {
        public EmpDbContextClass(DbContextOptions<EmpDbContextClass> options) : base(options) { }
  

        public DbSet<EmployeeParameters> EmployeeData { get; set; }

        public DbSet<SignUp> SignUpData { get; set; }

    }
}
