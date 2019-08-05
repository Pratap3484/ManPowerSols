using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManPowerSols.Core.Models
{
    public class MainModel
    {
        public string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }
    }

    public class JobDetailsModel
    {
        public string Rec_ID { get; set; }
    }
    public class DeleteJobModel
    {
        public string Rec_ID { get; set; }
        public string Recd_status { get; set; }
    }
    public class StatesModel
    {
        public string CountryID { get; set; }
    }
    public class CitiesModel
    {
        public string StateID { get; set; }
    }

    public class ChangePasswordModel
    {
        public string userid { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
        public string newpassword { get; set; }
        public string UUID { get; set; }

    }
    public class ChangePasswordResult
    {
        public string ResponseCode;
        public string ResponseMessage;
        public string ResponseList;
    }
}