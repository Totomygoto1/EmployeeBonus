using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendApplication.Services;
using BackendApplication.Models;


namespace BonusUnitTest
{
    public class BonusPoolService
    {
        private readonly EmployeeContext _context;

        public BonusPoolService(EmployeeContext context)
        {
            _context = context;
        }

        public int TestCalculateToLowBonus(int selectedEmployeeId, int bonusPoolAmount)
        {
            //load the details of the selected employee using the Id
            Employee employee = _context.Employee
                .FirstOrDefault(item => item.EmployeeId == selectedEmployeeId);

            //get the total salary budget for the company
            int totalSalary = (int)_context.Employee.Sum(item => item.Salary);

            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employee.Salary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);
            employee.Bonus = bonusAllocation;

            int check = 0;

            if (bonusAllocation > 5000)
            {
                check = 1;
            }

            return check;
        }

    }
}
