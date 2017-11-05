using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class XSSController : Controller
    {
        protected static Dictionary<string, string> remark = new Dictionary<string, string>();
        // GET: XSS
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(FormCollection fc)
        {
            remark.Add(Request.Form["username"], Request.Form["content"]);

            ViewBag.remark = remark;

            return View(remark);
        }
    }
}