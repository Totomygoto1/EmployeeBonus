using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApplication.Models
{
    interface IEmployee
    {

        int EmployeeId
        {
            get;
            set;
        }

        string Fullname
        {
            get;
            set;
        }

        string JobTitle
        {
            get;
            set;
        }

        int Salary
        {
            get;
            set;
        }

        int DepartmentId
        {
            get;
            set;
        }

        int Bonus
        {
            get;
            set;
        }

    }

    public abstract class BaseEmployee
    {

    }

    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public int Bonus { get; set; }
    }

}
