using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StudentMVC.Models;

namespace StudentMVC.Controllers
{
    public class StudentsController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Students
        public ActionResult Index()
        {
            var stu = client.GetAsync("http://localhost:53300/api/Students").Result.Content.ReadAsStringAsync().Result;
            var json = JsonConvert.DeserializeObject<IList<Student>>(stu);
            return View(json);
        }
        public ActionResult Details(int id)
        {
            var stu = client.GetAsync("http://localhost:53300/api/Students/" + id).Result.Content.ReadAsStringAsync().Result;
            var stu1 = JsonConvert.DeserializeObject<Student>(stu);
            return View(stu1);
        }
        public ActionResult Delete(int id)
        {
            var delstu = client.GetAsync("http://localhost:53300/api/Students/" + id).Result.Content.ReadAsStringAsync().Result;
            var stu1 = JsonConvert.DeserializeObject<Student>(delstu);
            return View(stu1);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            var json = JsonConvert.SerializeObject(student);
            var delstu = client.DeleteAsync("http://localhost:53300/api/Students/" +student.StudentId).Result.Content.ReadAsStringAsync();
            return RedirectToAction("Index");

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            var json = JsonConvert.SerializeObject(student);
            var stu = new StringContent(json, Encoding.UTF8, "application/json");
            var poststu = client.PostAsync("http://localhost:53300/api/Students",stu).Result.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var editstu = client.GetAsync("http://localhost:53300/api/Students/" + id).Result.Content.ReadAsStringAsync().Result;
            var stu = JsonConvert.DeserializeObject<Student>(editstu);
            return View(stu);

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var stu = JsonConvert.SerializeObject(student);
            var stu1 = new StringContent(stu, Encoding.UTF8, "application/json");
            var editstu = client.PutAsync("http://localhost:53300/api/Students/"+student.StudentId,stu1).Result.Content.ReadAsStringAsync();
            return RedirectToAction("Index");
        }


    }
}