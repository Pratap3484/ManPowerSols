﻿using ManPowerSols.Core.Models;
using ManPowerSols.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ManPowerSols.Areas.Employer.Controllers
{
    public class EmpViewPostsController : Controller
    {
        JobsRepository mps = new JobsRepository();
        // GET: Employer/EmpViewPosts
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult EditJobDetails(JobDetailsModel jp)
        {
            var res = "";
            try
            {
                string jsr = mps.EditJobDetails(jp);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateJobDetails(AgentJobPost jp)
        {
            var res = "";
            try
            {
                string jsr = mps.UpdateJobDetails(jp);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

    }
}