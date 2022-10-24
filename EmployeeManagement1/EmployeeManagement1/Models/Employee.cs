using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public string TokenNumber { get; set; }
    
     }
}