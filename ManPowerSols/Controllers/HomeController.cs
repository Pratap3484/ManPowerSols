using ManPowerSols.Core.Models;
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

namespace ManPowerSols.Controllers
{
    public class HomeController : Controller
    {
        MainRepoistory mps = new MainRepoistory();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult agentguide()
        {
            return View();
        }

        public ActionResult blog()
        {
            return View();
        }

        public ActionResult building()
        {
            return View();
        }

        public ActionResult construction()
        {
            return View();
        }

        public ActionResult electricy()
        {
            return View();
        }

        public ActionResult empguide()
        {
            return View();
        }

        public ActionResult isolation()
        {
            return View();
        }

        public ActionResult marine()
        {
            return View();
        }

        public ActionResult services()
        {
            return View();
        }

        public ActionResult voyage()
        {
            return View();
        }
        

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
        public JsonResult PostJobAndGetJobs(AgentJobPost jp)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                JsonResult jsr = GetjsonInfo("/JobDeatils/InsertJobDeatails", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetJobDetailsbyID(JobDetailsModel jp)
        {
            var res = "";
            try
            {
                string jsr = mps.GetJobDetailsbyID(jp);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteJob(DeleteJobModel jp)
        {
            var res = "";
            try
            {
                string jsr = mps.DeleteJob(jp);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCountryList()
        {
            var res = "";
            try
            {
                string jsr = mps.GetCountryList();
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetStatesbyCountry(StatesModel sm)
        {
            var res = "";
            try
            {
                string jsr = mps.GetStatesbyCountry(sm);
                return Json((new JavaScriptSerializer()).DeserializeObject(jsr), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCitiesbyState(CitiesModel cm)
        {
            var res = "";
            try
            {
                string jsr = mps.GetCitiesbyState(cm);
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