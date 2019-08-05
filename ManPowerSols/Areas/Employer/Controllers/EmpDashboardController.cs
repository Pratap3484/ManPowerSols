using ManPowerSols.Core;
using ManPowerSols.Core.Models;
using ManPowerSols.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ManPowerSols.Areas.Employer.Controllers
{
    public class EmpDashboardController : Controller
    {
        // GET: Employer/EmpDashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            //ViewBag.ResponseCode = null;
            //ViewBag.ResponseMessage = null;
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }
        public ActionResult ProfileUpdate()
        {
            return View();
        }
        public ActionResult MyDeals()
        {
            return View();
        }
        public ActionResult UserDeals()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(FormCollection frm)
        {
            ChangePasswordModel cpm = new ChangePasswordModel();
            MainRepoistory mps = new MainRepoistory();
            try
            {
                cpm.userid = frm["txtuserid"];
                cpm.usertype = frm["txtusertype"];
                cpm.password = frm["txtcurrentpwd"];
                cpm.newpassword = frm["txtnewpwd"];
                string res = mps.ChangePassword(cpm);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                var finalres = JsonConvert.DeserializeObject<ChangePasswordResult>(res);
                TempData["ResponseCode"] = finalres.ResponseCode;
                TempData["ResponseMessage"] = finalres.ResponseMessage;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "ChangePassword", "UserDashboardController");
            }
            return Redirect("/User/UserDashboard/ChangePassword");
        }
    }
   
}