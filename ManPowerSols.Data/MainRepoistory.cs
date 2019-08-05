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
    public class MainRepoistory
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

         public string GetJobDetailsbyID(JobDetailsModel jp)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                string jsr = GetjsonInfo("/JobDeatils/GetJobDetailsByJobID", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetJobDetailsbyID", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string DeleteJob(DeleteJobModel jp)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(jp);
                string jsr = GetjsonInfo("/JobDeatils/UpdateJobRecordStatus", inputJson);

                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "UpdateJobRecordStatus", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string GetCountryList()
        {
            var res = "";
            try
            {
                string jsr = GetjsonInfo("/ManPowers/GetCountryList", "");
                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetCountryList", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string GetStatesbyCountry(StatesModel sm)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(sm);
                string jsr = GetjsonInfo("/ManPowers/GetStateList", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetStatesbyCountry", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string GetCitiesbyState(CitiesModel cm)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(cm);
                string jsr = GetjsonInfo("/ManPowers/GetCityList", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "GetCitiesbyState", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string ChangePassword(ChangePasswordModel cpm)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(cpm);
                string jsr = GetjsonInfo("/Signin/ChangePassword", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "ChangePassword", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string ForgotPasswordSendLink(ChangePasswordModel cpm)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(cpm);
                string jsr = GetjsonInfo("/Signin/ForgetPassword", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "ForgotPasswordSendLink", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string ValidateForgotPwdCode(ChangePasswordModel cpm)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(cpm);
                string jsr = GetjsonInfo("/Signin/CheckForgetLink", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "ForgotPasswordSendLink", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }

        public string UpdatePassword(ChangePasswordModel cpm)
        {
            var res = "";
            try
            {
                string inputJson = (new JavaScriptSerializer()).Serialize(cpm);
                string jsr = GetjsonInfo("/Signin/UpdatePassword", inputJson);
                return jsr;
            }
            catch (Exception ex)
            {
                ErrorWriter.WriteLog(ex.GetType().ToString(), ex.GetType().Name.ToString(), ex.InnerException.ToString(), "ForgotPasswordSendLink", "MainRepository");
                res = ex.Message.ToString();
                return res;
            }
        }
    }
}