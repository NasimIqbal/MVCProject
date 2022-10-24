using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeManagementAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (EmployeeManagementEntities entities = new EmployeeManagementEntities())
            {
                var emp= entities.Employees.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
                
        }
        public HttpResponseMessage Get(int id)
        {
            using (EmployeeManagementEntities entities = new EmployeeManagementEntities())
            {
                var emp= entities.Employees.FirstOrDefault(e => e.EmployeeId == id);
                if (emp == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Employee with Id "+id.ToString()+" Not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
            }

        }
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            using (EmployeeManagementEntities entities = new EmployeeManagementEntities())
            {
                entities.Employees.Add(employee);
                entities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {
            try
            {


                using (EmployeeManagementEntities entities = new EmployeeManagementEntities())
                {
                    var emp = entities.Employees.FirstOrDefault(e => e.EmployeeId == id);
                    if (emp == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " not found");
                    }
                    else
                    {
                        emp.Name = employee.Name;
                        emp.DepartmentId = employee.DepartmentId;
                        emp.Salary = employee.Salary;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, emp);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeManagementEntities entities = new EmployeeManagementEntities())
                {
                    var emp = entities.Employees.FirstOrDefault(e => e.EmployeeId == id);
                    if (emp == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee details not found");
                    }
                    else
                    {

                        entities.Employees.Remove(emp);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, emp);
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
