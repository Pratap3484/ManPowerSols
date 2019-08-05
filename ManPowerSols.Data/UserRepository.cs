using ManPowerSols.Core;
using ManPowerSols.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ManPowerSols.Data
{
    public class UserRepository
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
            }
            catch (Exception ex)
            {
                res = ex.Message.ToString();
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "UserRepository_GetjsonInfo", strMethod);
                return res;
            }

        }


        public string UpdateUserProfile(UserProfileModel jp)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                string jsr = GetjsonInfo("/UserDetails/UpdateUserPersonalDeatails", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "UpdateUserProfile", "UserRepository");
                res = ex.Message.ToString();
                return res;
            }
        }
        public string GetUserProfile(GetUserProfileModel jp)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                string jsr = GetjsonInfo("/UserDetails/GetUserPersonalDeatails", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetUserProfile", "UserRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string GetUserAppliedJobs(string usrid)
        {
            var res = "";
            try
            {
                object jp = new
                {
                    UserID = usrid
                };
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                string jsr = GetjsonInfo("/JobDeatils/GetAppliedJobDetailsByUserID", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetUserProfile", "UserRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

    }

}