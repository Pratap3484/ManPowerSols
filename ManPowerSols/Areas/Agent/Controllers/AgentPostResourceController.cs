using ManPowerSols.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ManPowerSols.Areas.Agent.Controllers
{
    public class AgentPostResourceController : Controller
    {
        // GET: Agent/AgentPostResource
        public ActionResult Index()
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
        public JsonResult AgentJobPost(AgentJobPost jp)
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
    }
}