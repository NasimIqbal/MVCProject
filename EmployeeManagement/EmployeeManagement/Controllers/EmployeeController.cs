using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeManagementEntities employeeManagementEntities = new EmployeeManagementEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View(employeeManagementEntities.EmployeeTables.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeTable employeeTable)
        {
            Guid guid = Guid.NewGuid();
            var tokrn = guid.ToString();
            employeeTable.TokenNumber = tokrn;
            var emp = employeeManagementEntities.EmployeeTables.Add(employeeTable);
            employeeManagementEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        { 
            var emp = employeeManagementEntities.EmployeeTables.FirstOrDefault(e => e.TokenNumber == id);
            return View(emp);
        }
        public ActionResult Edit(string id)
        {
            var emp = employeeManagementEntities.EmployeeTables.FirstOrDefault(e=>e.TokenNumber==id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeTable employeeTable)
        {
            var emp = employeeManagementEntities.EmployeeTables.FirstOrDefault(e=>e.EmployeeId==employeeTable.EmployeeId);
            emp.Name = employeeTable.Name;
            emp.Salary = employeeTable.Salary;
            emp.DepartmentId = employeeTable.DepartmentId;
            employeeManagementEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var emp = employeeManagementEntities.EmployeeTables.FirstOrDefault(e => e.TokenNumber == id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(EmployeeTable emp)
        {
            var emplst = employeeManagementEntities.EmployeeTables.Find(emp.EmployeeId);
            employeeManagementEntities.EmployeeTables.Remove(emplst);
            employeeManagementEntities.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public JsonResult DeletedAjax(string id)
        {
            var emp = employeeManagementEntities.EmployeeTables.FirstOrDefault(e => e.TokenNumber == id);
            employeeManagementEntities.EmployeeTables.Remove(emp);
            employeeManagementEntities.SaveChanges();
            return Json("Successful");
        }
        [HttpPost]
        public JsonResult CreatedAjax(string Name,string Salary,string DepartmentId)
        {
            Guid guid = Guid.NewGuid();
            var tokrn = guid.ToString();
            EmployeeTable emptbl = new EmployeeTable();
            emptbl.TokenNumber = tokrn;
            emptbl.Name = Name;
            emptbl.Salary = int.Parse(Salary);
            emptbl.DepartmentId = int.Parse(DepartmentId);
            employeeManagementEntities.EmployeeTables.Add(emptbl);
            employeeManagementEntities.SaveChanges();
            return Json(Name+" details has been saved");
        }

    }
}