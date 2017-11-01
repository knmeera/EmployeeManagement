using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
        public class Department
        {
            [Key]   
            public int ID { get; set; } // Primary Key
            public string DeptName { get; set; }
            public bool Enable { get; set; }
            public virtual ICollection<Employee> Employees{ get; set; }


        public List<Department> GetAll()
        {
            List<Department> depts = new List<Department>();
            depts.Add(new Department { ID = 1, DeptName = "Admin", Enable = true });
            depts.Add(new Department { ID = 2, DeptName = "HR", Enable = true });
            depts.Add(new Department { ID = 3, DeptName = "Marketing", Enable = true });
            depts.Add(new Department { ID = 4, DeptName = "Development", Enable = true });

            return depts;
        }

    }

   
    
}