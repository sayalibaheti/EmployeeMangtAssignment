using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpManagement.BL;
using EmpManagement.Models;
using SimpleInjector.Packaging;
using SimpleInjector;

namespace EmpManagement.Controllers
{
    public class HomeController : Controller
    {
        EmpBL empl = new EmpBL();
        public ActionResult Index()
        {
           var model= empl.GetEmployees(new EmpModel());
            return View(model);
        }

        public ActionResult GetEmployees(string age,string location,string salary)
        {
            var query = new EmpModel();
            query.Age = Int32.Parse(age==""?"0":age);
            query.Location = location;
            query.Salary = Int32.Parse(salary == "" ? "0" : salary);
            var model = empl.GetEmployees(query);
            return PartialView("_EmpList",model);
          
        }

        public ActionResult DeleteEmployee(string id)
        {
            try
            {
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