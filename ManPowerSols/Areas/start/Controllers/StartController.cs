using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManPowerSols.Core.Models;
using System.Configuration;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using ManPowerSols.Data;
using ManPowerSols.Core;

namespace ManPowerSols.Areas.start.Controllers
{
    public class StartController : Controller
    {
        // GET: start/Start
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        //Common Method to call all service and convert result to the Json
        public JsonResult GetjsonInfo(string strMethod, string inputJson)
        {
            var res = "";
            try
            {
                string urlAddress = string.Empty;
                urlAddress = ConfigurationManager.AppSettings["serviceURL"];
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                ServicePointManager.MaxServicePointIdleTime = 1000;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                res = client.UploadString(urlAddress + strMethod, inputJson);
                JavaScriptSerializer jsJson = new JavaScriptSerializer();
                jsJson.MaxJsonLength = 2147483644;
                return Json((new JavaScriptSerializer()).DeserializeObject(res), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                ErrorLogcls.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetjsonInfo", strMethod);
                return Json(res, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult UserRegistration(UserModel um)
        {
            var res = "";
            try
            {
                um.ipaddress = "100:w";
                um.devicetype = "1";
                um.branch = "Web";
                string inputJson = (new JavaScriptSerializer()).Serialize(um);
                JsonResult jsr = GetjsonInfo("/ManPowers/RegisterUser", inputJson);
                //if (jsr.ResponseCode == "200")
                //{

                //}
                //return res;
                return jsr;
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Login(UserModel log)
        {
            MainModel objMainModel = new MainModel();
            var res = "";
            try
            {
                JsonResult jsr = null;
                log.ipaddress = objMainModel.GetIp();
                log.devicetype = "1";
                log.branch = "Web";
                //if (log.usertype != "1")
                //{
                string inputJson = (new JavaScriptSerializer()).Serialize(log);
                jsr = GetjsonInfo("/Signin/SignIn_with_Password", inputJson);
                //}
                //else
                //{
                //    if(log.emailid=="ADMIN" && log.password == "password")
                //    {
                //        jsr = null;
                //    }
                //}
                //if (jsr.ResponseCode == "200")
                //{

                //}
                //return res;
                return jsr;
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ApplyJob(JobApplyModel um)
        {
            var res = "";
            try
            {
                JsonResult jsr = null;
                string inputJson = (new JavaScriptSerializer()).Serialize(um);
                jsr = GetjsonInfo("/JobDeatils/InsertJobApplyDeatails", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAppliedUserbyJob(int jobid)
        {
            var res = "";
            try
            {
                JsonResult jsr = null;
                object jp = new
                {
                    Rec_ID = jobid
                };
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                jsr = GetjsonInfo("/JobDeatils/GetUserDeatailsByJobID", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ForgotPasswordSendLink(FormCollection frm)
        {
            ChangePasswordModel cpm = new ChangePasswordModel();
            MainRepoistory mps = new MainRepoistory();
            try
            {
                cpm.userid = frm["txtemail"];
                string res = mps.ForgotPasswordSendLink(cpm);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                var finalres = JsonConvert.DeserializeObject<ChangePasswordResult>(res);
                TempData["ResponseCode"] = finalres.ResponseCode;
                TempData["ResponseMessage"] = finalres.ResponseMessage;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType()?.ToString(), ex.GetType()?.Name?.ToString(), ex.InnerException?.ToString(), "ForgotPassword", "StartController");
            }
            return Redirect("/Start/Start/ForgotPassword");
        }
                
        public JsonResult ValidateForgotPwdCode(ChangePasswordModel cpm)
        {
           // ChangePasswordModel cpm = new ChangePasswordModel();
            MainRepoistory mps = new MainRepoistory();
            string finalres= string.Empty;
            try
            {
                finalres = mps.ValidateForgotPwdCode(cpm);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                var res = JsonConvert.DeserializeObject<ChangePasswordResult>(finalres);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                finalres = ex.Message.ToString();
                ErrorWriter.WriteLog(ex.GetType()?.ToString(), ex.GetType()?.Name?.ToString(), ex.InnerException?.ToString(), "ValidateForgotPwdCode", "StartController");
                return Json(finalres, JsonRequestBehavior.AllowGet);
               
            }
            
        }

        public JsonResult UpdatePassword(ChangePasswordModel cpm)
        {
            MainRepoistory mps = new MainRepoistory();
            string finalres = string.Empty;
            try
            {
                finalres = mps.UpdatePassword(cpm);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                var res = JsonConvert.DeserializeObject<ChangePasswordResult>(finalres);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                finalres = ex.Message.ToString();
                ErrorWriter.WriteLog(ex.GetType()?.ToString(), ex.GetType()?.Name?.ToString(), ex.InnerException?.ToString(), "UpdatePassword", "StartController");
                return Json(finalres, JsonRequestBehavior.AllowGet);

            }

        }

    }
}