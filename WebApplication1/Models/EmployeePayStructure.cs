using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmployeePayStructure
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string PayComponent { get; set; }
    }
}