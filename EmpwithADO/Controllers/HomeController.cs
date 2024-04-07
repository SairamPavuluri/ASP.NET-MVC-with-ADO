using EmpwithADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpwithADO.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDataContext _Context;
        public HomeController()
        {
            _Context = new EmployeeDataContext();
        }
        public ActionResult GetEmployee()
        {
            List<Employee> emp = new List<Employee>();    
            emp=_Context.GetEmployees();  
            return View(emp);
        }
        public ActionResult Create() 
        {
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            int i=_Context.InsertEmployee(emp);
            if(i>0)
            {
                return RedirectToAction("GetEmployee");
            }
            else
            {
                ViewBag.Msg = "Employee not Inserted";
                return View();  
            }
        }
        public ActionResult Details(int id)
        {
            Employee emp = new Employee();
            emp=_Context.GetDetails(id);
            return View(emp);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            int i=_Context.DeleteEmp(id);
            return View();
        }
        public ActionResult Edit(int id) 
        {
            Employee emp = new Employee();
            emp = _Context.GetDetails(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            int i = _Context.EditEmployee(emp);
            if (i > 0)
            {
                return RedirectToAction("GetEmployee");
            }
            else
            {
                ViewBag.Msg = "Employee not Inserted";
                return View();
            }
            
        }
    }
}