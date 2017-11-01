using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{


     
    public class Employee 
    {

        [Key]
        public int ID { get; set; }
        public String EmpNo { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String DOB { get; set; }

        public String Stree1 { get; set; }
        public String Street2 { get; set; }
        public String City { get; set; }
        public String Pin { get; set; }
        public String District { get; set; }
        public String State { get; set; } // Probation/PIP/Sepration/

        public float TotalYearsOfExp { get; set; }
        public String WorkState { get; set; } // Assigned / Free To/from Projects 
        public float WorkLoad { get; set; } // If Emp is assigned /allocated . how much he is loaded .5.5 (Normal) .6 .5 (loaded)
        public String Country { get; set; }
        public String Address { get; set; }

        //For Forigen Key
        public int DeptID { get; set; }
        public virtual Department Department { get; set; }

        public string PofilePic { get; set; }

        public bool Enable { get; set; } // Active / Deactive





    }
    public class EmployeeSkillSet
    {
        public int ID { get; set; }
        public int SkillName { get; set; }
        public float YearsOfExp { get; set; }
        public int EmployeeID { get; set; }
    }

}