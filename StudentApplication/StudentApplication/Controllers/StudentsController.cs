using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentApplication.Models;
namespace StudentApplication.Controllers
{
    public class StudentsController : ApiController
    {
        private EmployeeManagementEntities employeeManagementEntities = new EmployeeManagementEntities();
        public HttpResponseMessage Get()
        {
            var stu = employeeManagementEntities.Students.ToList();
            var stu1 = Request.CreateResponse(HttpStatusCode.OK, stu);
            return stu1;
        }
        public HttpResponseMessage Get(int id)
        {
            var stu = employeeManagementEntities.Students.FirstOrDefault(s => s.StudentId == id);
            return Request.CreateResponse(HttpStatusCode.OK, stu);
        }
        public HttpResponseMessage Post([FromBody] Student student)
        {
            employeeManagementEntities.Students.Add(student);
            employeeManagementEntities.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        public HttpResponseMessage Put(int id,[FromBody] Student student)
        {
            var stu = employeeManagementEntities.Students.FirstOrDefault(s => s.StudentId == id);
            if(stu==null)
            {
               return  Request.CreateErrorResponse(HttpStatusCode.NoContent, "Student details with Id: " + id + " is not available");
            }
            
            
                stu.Name = student.Name;
                stu.Department = student.Department;
                employeeManagementEntities.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            
            

        }
        public HttpResponseMessage Delete(int id)
        {
            var stu = employeeManagementEntities.Students.FirstOrDefault(s => s.StudentId == id);
            if(stu==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Student details with Id: " + id + "Not Fond");
            }
            employeeManagementEntities.Students.Remove(stu);
            employeeManagementEntities.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
