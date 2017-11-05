using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class CSRFController : Controller
    {
        // GET: CSRF
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BIndex()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ContentResult Post()
        {

            return Content("转账成功,金额：" + Request.Form["money"]);
        }

        public ActionResult Ajax()
        {
            return View();
        }


        [HttpPost]
        public ContentResult Ajax_Post()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Content("转账成功,金额：" + Request.Form["money"]);
            }

            return null;
        }
    }
}