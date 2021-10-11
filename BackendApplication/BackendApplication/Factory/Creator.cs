using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApplication.Models;

namespace BackendApplication.Factory
{
    // Factory Method Pattern using IEmployee - Employee

    public abstract class Creator
    {
        public abstract void CreateEmployeeList();
        public abstract int CheckToLowEmployeeBonus();

        public void TemplateMethod()
        {
            CreateEmployeeList();
            CheckToLowEmployeeBonus();
        }

    }

    public class ConcreteCreator : Creator
    {
        public List<Employee> lstEmployee = new List<Employee>();

        public override void CreateEmployeeList()
        {
            lstEmployee.Add(new Models.Employee() { EmployeeId = 7, Fullname = "Mary-Ann Nyambi", JobTitle = "HR Manager", Salary = 65000, DepartmentId = 1, Bonus = 15000000 });
            lstEmployee.Add(new Models.Employee() { EmployeeId = 8, Fullname = "David Santiago", JobTitle = "Sales Manager", Salary = 85000, DepartmentId = 1, Bonus = 25000000 });
            lstEmployee.Add(new Models.Employee() { EmployeeId = 9, Fullname = "Paul Martins", JobTitle = "Software Architect", Salary = 65000, DepartmentId = 1, Bonus = 150000 });
            
        }

        public override int CheckToLowEmployeeBonus()
        {
            foreach (Employee emp in lstEmployee)
            {
                if (emp.Bonus < 1000)
                {
                    return 0;
                }
                else
                {
                    Console.WriteLine("EmployeeID: " + emp.EmployeeId + "Employee: " + emp.Fullname + " Bonus: " + emp.Bonus + "\n");
                }
            }
            return 1;

        }

    }
}
