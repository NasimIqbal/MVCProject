using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Web.Mvc;
namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        List<Employee> employee = new List<Employee>()
        {
            new Employee{Id=1,Name="Nasim",Salary=25000}

        };
        // GET api/values
        public ActionResult Get()
        {
            return employee;
        }

        // GET api/values/5
        public ActionResult Get(int id)
        {
            return employee.FirstOrDefault(e => e.Id == id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
