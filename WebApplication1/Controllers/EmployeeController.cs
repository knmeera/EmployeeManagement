using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
         static List<Employee> empList = new List<Employee>(); // Declaration how much memory allocated in-memeory 
        static List<EmployeePayStructure> empPayStr = new List<EmployeePayStructure>(); // Declaration how much memory allocated in-memeory 

        // GET: Employee
        public ActionResult Index()
        {
 
            //empList.Add(new Employee { ID = 1, EmpNo = "E001", FirstName = "A", LastName = "Gandhi", Gender = "M", Address = "Liitle India" });
            //empList.Add(new Employee { ID = 2, EmpNo = "E002", FirstName = "B", LastName = "Ravi", Gender = "M", Address = "Liitle India" });
            //empList.Add(new Employee { ID = 3, EmpNo = "E003", FirstName = "C", LastName = "Krishna", Gender = "M", Address = "Liitle India" });
            //empList.Add(new Employee { ID = 4, EmpNo = "E004", FirstName = "C", LastName = "Vijay", Gender = "M", Address = "Liitle India" });
            //empList.Add(new Employee { ID = 5, EmpNo = "E005", FirstName = "D", LastName = "Ajay", Gender = "M", Address = "Liitle India" });
            //empList.Add(new Employee { ID = 6, EmpNo = "E006", FirstName = "E", LastName = "Ramu", Gender = "M", Address = "Liitle India" });


            return View(empList);
        }

        public ActionResult Create()
        {

            Department e = new Department();
            ViewBag.Departments = new SelectList(e.GetAll(), "ID", "DeptName");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {

            //var id = frm["id"];
            //var name = frm["empname"];
            //var age = frm["age"];
            //var mobile = frm["mobile"];
            //var welcomeMessage = "Welcome  " + name;

            //Employee e = new Employee();
            //e.EmpNo = "0";
            //e.FirstName = "Ramesh";
            //e.Address = "S R Nagar";
            //e.DeptID = Int32.Parse(frm["ddlDept"]);

            // Validate Employee Model

            if (ValidateForm(emp))
            {
                // Do your Save or any business logic
                empList.Add(emp);

                EmployeePayStructure str = new EmployeePayStructure();
                str.EmployeeID = emp.ID;
                str.PayComponent = "BP:5000";

                EmployeePayStructure str1 = new EmployeePayStructure();
                str1.EmployeeID = emp.ID;
                str1.PayComponent = "HRA:600";

                EmployeePayStructure str2 = new EmployeePayStructure();
                str2.EmployeeID = emp.ID;
                str2.PayComponent = "DA:100";

                empPayStr.Add(str);
                empPayStr.Add(str1);
                empPayStr.Add(str2);

                ViewBag.Message = "Successfully Employee Created";
                return RedirectToAction("Index","Employee");
            }
            else
            {
                Department e = new Department();
                ViewBag.Departments = new SelectList(e.GetAll(), "ID", "DeptName");
            }


            return View();
        }


        // Resuable method for vallidation
        private bool ValidateForm(Employee emp)
        {
            if (emp.EmpNo == null || emp.EmpNo == String.Empty)
                ModelState.AddModelError("EmpNo", "Please enter EmpNo."); // Once this statement is exec. then ModelState.IsValid becomes false

            if (emp.FirstName == null || emp.FirstName == String.Empty)
                ModelState.AddModelError("FirstName", "Please Enter First Name.");

            if (emp.DeptID == 0)
                ModelState.AddModelError("DeptID", "Please Select Department.");

            return ModelState.IsValid;

        }
        public ActionResult EmployeeDashboard()
        {
            return View(); 
        }
        // This is the chils action method to render the _EmployeeStatDashboard.cshtml view 
        public ActionResult _EmployeeStatDashboard()
        {
            // Do your all Aggretation of Employee Stat
            //Calculate all and send to your Partial View
            return PartialView("_EmployeeStatDashboard");
        }
        public ActionResult _EmployeePayStructure(int ID)
        {
            //Get Employee PayStructure based on ID
            var payStr = empPayStr.Where(e => e.EmployeeID == ID);
            return PartialView("_EmployeePayStructure", payStr);

        }


    }
}