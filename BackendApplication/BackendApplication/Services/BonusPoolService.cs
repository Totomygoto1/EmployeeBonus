using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendApplication.Models;

namespace BackendApplication.Services
{
    public class BonusPoolService
    {
        private readonly EmployeeContext _context;

        public BonusPoolService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> CalculateAsync(int selectedEmployeeId, int bonusPoolAmount)
        {
            //load the details of the selected employee using the Id
            Employee employee = await _context.Employee
                .FirstOrDefaultAsync(item => item.EmployeeId == selectedEmployeeId);

            //get the total salary budget for the company
            int totalSalary = (int)_context.Employee.Sum(item => item.Salary);

            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employee.Salary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);
            employee.Bonus = bonusAllocation;

            return employee;
        }

    }
}
