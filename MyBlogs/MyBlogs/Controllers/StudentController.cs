using MyBlogs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogs.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            BlogsDB db = new BlogsDB();

            db.Student.Add(new Models.Students()
            {
                Name = "mas",
                Age = 28
            });

            db.SaveChanges();

            var list = db.Student.ToList();

            return View(list);
        }
    }
}