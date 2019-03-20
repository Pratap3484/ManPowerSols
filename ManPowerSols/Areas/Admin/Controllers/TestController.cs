using ManPowerSols.Core.Models;
using ManPowerSols.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManPowerSols.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Admin/Test
        TestRepository trObj = new TestRepository();
        public ActionResult Index()
        {
           
            return View();
        }

        public JsonResult Test(TestModel tm)
        {
            string a = "fdsd";
            string b = "fdsd";
            string c = "fdsd";
            var data = trObj.TestRep(tm);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}