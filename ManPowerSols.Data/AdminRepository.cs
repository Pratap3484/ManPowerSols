using ManPowerSols.Core;
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

namespace ManPowerSols.Data
{
    public class AdminRepository
    {
        public string GetjsonInfo(string strMethod, string inputJson)
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
                return res;
               // return Json((new JavaScriptSerializer()).DeserializeObject(res), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetjsonInfo", strMethod);
                return res;
            }

        }
        public string GetRegsiteredUsers()
        {
            var res = "";
            try
            {
                string inputJson = "";
                string jsr = GetjsonInfo("/Admin/GetPendingUserDetails", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetRegsiteredUsers", "AdminRepository");
                res = ex.Message.ToString();
                return res;
            }
        }
        

            public string ApproveUser(ApproveUser au)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(au);
                string jsr = GetjsonInfo("/Admin/UpdateUserStatus", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "UpdateUserStatus", "AdminRepository");
                res = ex.Message.ToString();
                return res;
            }
        }
        public string UpdateJobAccess(UpdateAccess au)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(au);
                string jsr = GetjsonInfo("/JobDeatils/UpdateJobDetailsAccessStatus", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "UpdateJobAccess", "AdminRepository");
                res = ex.Message.ToString();
                return res;
            }
        }
        public string GetEmpPostsbyStatus(UpdateAccess au)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(au);
                string jsr = GetjsonInfo("/JobDeatils/GetJobDeatailsByAccessStatus", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetEmpPostsbyStatus", "AdminRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string GetEmpAgentDeals(string usrid,string rectype)
        {
            var res = "";
            try
            {
                object jp = new
                {
                    UserID = usrid,
                    RecordType=rectype
                };
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                string jsr = GetjsonInfo("/JobDeatils/GetAppliedJobDetailsByUserIDWithRecordType", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetUserProfile", "UserRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string UpdateAppliedJob(JobApplyModel jm)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(jm);
                string jsr = GetjsonInfo("/JobDeatils/UpdateJobApplyDeatails", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetAppliedUserbyJob", "AdminRepository");
                res = ex.Message.ToString();
                return res;
            }
        }
    }
}