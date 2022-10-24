using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmployeeManagement1.Controllers
{
    public class EmployeesController : Controller
    {
      private HttpClient client = new HttpClient();
        // GET: Employees
        public ActionResult Index()
        {
            
            var getemp = client.GetAsync("http://localhost:54661/api/Employees").Result.Content.ReadAsStringAsync();
           var emplist= System.Text.Json.JsonSerializer.Deserialize<IList<Employee>>(getemp.Result);
         
            return View(emplist);
        }
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(Employee employee)
        {

            var json = JsonConvert.SerializeObject(employee);
            var data = new StringContent(json,Encoding.UTF8,"application/json");
            var postemp = await client.PostAsync("http://localhost:54661/api/Employees", data).Result.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            // var jsonstring = JsonConvert.SerializeObject(id);
            //  var json = JsonConvert.DeserializeObject(jsonstring);
            var emp = client.GetAsync("http://localhost:54661/api/Employees/" + id).Result.Content.ReadAsStringAsync().Result;
            var asp = JsonConvert.DeserializeObject<Employee>(emp);


            return View(asp);
        }
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            var json = JsonConvert.SerializeObject(employee);
            var delemp = client.DeleteAsync("http://localhost:54661/api/Employees/" + employee.EmployeeId).Result.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var emp = client.GetAsync("http://localhost:54661/api/Employees/" + id).Result.Content.ReadAsStringAsync().Result;
            var asp = JsonConvert.DeserializeObject<Employee>(emp);
            return View(asp);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var jsonstring = JsonConvert.SerializeObject(employee);
            var data = new StringContent(jsonstring, Encoding.UTF8, "application/json");
            var editemp = client.PutAsync("http://localhost:54661/api/Employees/"+employee.EmployeeId,data).Result.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var emp = client.GetAsync("http://localhost:54661/api/Employees/" + id).Result.Content.ReadAsStringAsync().Result;
            var asp = JsonConvert.DeserializeObject<Employee>(emp);

            return View(asp);
        }


    }
}