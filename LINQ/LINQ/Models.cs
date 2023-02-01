using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string? EmployeeFullName { get; set; }
        public int DepartmentID { get; set; }
    }

    public class Departments
    {
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
    }
}
