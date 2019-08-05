using ManPowerSols.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data;
using ManPowerSols.Core.Models;
using Newtonsoft.Json;
using ManPowerSols.Core;

namespace ManPowerSols.Areas.Admin.Controllers
{
    public class AdDashboardController : Controller
    {
        // GET: Admin/AdDashboard

        AdminRepository arobj = new AdminRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
        public ActionResult EmpJobs()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult CreateAdmin()
        {
            return View();
        }
        public ActionResult AdminDeals()
        {
            return View();
        }

        public JsonResult GetRegsiteredUsers()
        {
            var res = "";
            try
            {
                string jsr = arobj.GetRegsiteredUsers();
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ApproveUser(ApproveUser au)
        {
            var res = "";
            try
            {
                string jsr = arobj.ApproveUser(au);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateJobAccess(UpdateAccess ua)
        {
            var res = "";
            try
            {
                string jsr = arobj.UpdateJobAccess(ua);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmpPostsbyStatus(UpdateAccess ua)
        {
            var res = "";
            try
            {
                string jsr = arobj.GetEmpPostsbyStatus(ua);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmpAgentDeals(string usrid, string rectype)
        {
            var res = "";
            try
            {
                string jsr = arobj.GetEmpAgentDeals(usrid, rectype);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateAppliedJob(JobApplyModel jm)
        {
            var res = "";
            try
            {
                string jsr = arobj.UpdateAppliedJob(jm);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
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
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "ChangePassword", "AdminDashboardController");
            }
            return Redirect("/Admin/AdDashboard/ChangePassword");
        }

    }

   
}
