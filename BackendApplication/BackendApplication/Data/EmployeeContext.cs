using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackendApplication.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext (DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<BackendApplication.Models.Employee> Employee { get; set; }
        public DbSet<BackendApplication.Models.Department> Department { get; set; }
        public DbSet<BackendApplication.Models.CalculateBonus> CalculateBonus { get; set; }
        public DbSet<BackendApplication.Models.BonusPoolCalculatorResult> BonusPoolCalculatorResult { get; set; }

    }
}
