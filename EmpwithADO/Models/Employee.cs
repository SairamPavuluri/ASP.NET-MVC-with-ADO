using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpwithADO.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string DepID { get; set; }
        public string Salary { get; set;}
        public string Email { get; set; }
        public string City { get; set; }
    }
}