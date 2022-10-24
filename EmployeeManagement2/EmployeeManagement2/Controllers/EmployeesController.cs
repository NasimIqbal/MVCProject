using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement2.Models;

namespace EmployeeManagement2.Controllers
{
    [LogActionFilter]
    public class EmployeesController : Controller
    {
        // GET: Employees
        [Authorize(Roles ="admin, Employee")]
        [RequireHttps]
        [OutputCache(Duration=20)]
        [HandleError(View="Error.chstml")]
        

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult Edit(Employee employee)
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}