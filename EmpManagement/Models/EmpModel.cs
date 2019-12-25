using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpManagement.Models
{
    public class EmpModel
    {
        public int EmpID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Age { get; set; }
        public string MaritalStatus { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
    }
}