using ManPowerSols.Core;
using ManPowerSols.Core.Models;
using ManPowerSols.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ManPowerSols.Areas.User.Controllers
{
    public class UserDashboardController : Controller
    {
        UserRepository ur = new UserRepository();
        // GET: User/UserDashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ViewProfile()
        {
            return View();
        }

        public ActionResult UserDeals()
        {
            return View();
        }

        public ActionResult Jobs()
        {
            return View();
        }

        public System.Drawing.Image Base64ToImage(string bs64str)
        {
            System.Drawing.Image image=null;
            try
            {
                byte[] imageBytes = Convert.FromBase64String(bs64str);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                image = System.Drawing.Image.FromStream(ms, true);
               
            }
            catch(Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetUserProfile", "UserDashboardController");
            }
            return image;

        }

        public class img
        {
            public string ImgPath { get; set; }
        }
        public JsonResult UpdateUserProfile(UserProfileModel up,img imagpath)
        {
            var res = "";
            try
            {
                //if (up.ImgPath != "" && up.ImgPath != null)
                //{
                //    if (up.ImgPath.IndexOf(".png") > -1) { }
                //    else
                //    {
                //        Base64ToImage(up.ImgPath).Save(Server.MapPath("~/ProfilePics/" + up.UserID + ".png"));
                //        up.ImgPath = "/ProfilePics/" + up.UserID + ".png";
                //    }
                //}
                //else
                //{
                //    up.ImgPath = "http://mps.manpowersupplier.net/img/admin.png";
                //}
                if (imagpath.ImgPath != "" && imagpath.ImgPath != null)
                {
                    if (imagpath.ImgPath.IndexOf(".png") > -1) { }
                    else
                    {
                        Base64ToImage(imagpath.ImgPath).Save(Server.MapPath("~/ProfilePics/" + up.UserID + ".png"));
                        imagpath.ImgPath = "/ProfilePics/" + up.UserID + ".png";
                    }
                }
                else
                {
                    imagpath.ImgPath = "http://mps.manpowersupplier.net/img/admin.png";
                }
                up.ImgPath = imagpath.ImgPath;
                string jsr = ur.UpdateUserProfile(up);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "UpdateUserProfile", "UserDashboardController");
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUserProfile(GetUserProfileModel up)
        {
            var res = "";
            try
            {
                string jsr = ur.GetUserProfile(up);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetUserProfile", "UserDashboardController");
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUserAppliedJobs(string usrid)
        {
            var res = "";
            try
            {
                string jsr = ur.GetUserAppliedJobs(usrid);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetUserAppliedJobs", "UserDashboardController");
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
            catch(Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "ChangePassword", "UserDashboardController");
            }
            return Redirect("/User/UserDashboard/ChangePassword");
        }
    }
}