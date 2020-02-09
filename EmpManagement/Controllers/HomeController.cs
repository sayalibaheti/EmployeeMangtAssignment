using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleInjector.Packaging;
using SimpleInjector;
using BusinessLogicLayer;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            try
            {
                EmployeeBL empl = new EmployeeBL();
                var model = empl.GetEmployeeList(new DTO.EmployeeDTO());
                var LocList = empl.GetLocations();
                ViewBag.Locations = LocList;
                return View(model);
            }
            catch
            {
                throw;
            }
        } 

        public ActionResult GetEmployees(string age,string location,string salary)
        {
            try
            {
                EmployeeBL empl = new EmployeeBL();
                var query = new DTO.EmployeeDTO();
                query.Age = Int32.Parse(age == "" ? "0" : age);
                query.Location = location;
                query.Salary = Int32.Parse(salary == "" ? "0" : salary);
                var model = empl.GetEmployeeList(query);
                return PartialView("_EmpList", model);
            }
            catch
            {
                throw;
            }
        }

        public ActionResult DeleteEmployee(string id)
        {
            try
            {
                EmployeeBL empl = new EmployeeBL();
                bool isSuccess=  empl.DeleteEmployee(Convert.ToInt32(id));
                if(isSuccess)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch(Exception)
            {
                return Json("fails");
            }

           
        }


    }
}