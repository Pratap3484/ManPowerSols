using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManPowerSols.Core.Models
{
    public class UserModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string emailid { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
        public string devicetype { get; set; }
        public string branch { get; set; }
        public string ipaddress { get; set; }
       public string regtype { get; set; }
        public string Country { get; set; }
        public string State{ get; set; }
        public string City { get; set; }


    }
    public class GetUserProfileModel
    {
        public string UserID { get; set; }
    }
        public class UserProfileModel
    {
        public string Rec_ID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string zipcode { get; set; }
        public string Designation { get; set; }
        public string YearsOfExp { get; set; }
        public string Experience { get; set; }
        public string PresentCompanyName { get; set; }
        public string PeriodOfWorking { get; set; }
        public string Work_Sector { get; set; }
        public string Last_Salary { get; set; }
        public string Altenative_mobile { get; set; }
        public string AboutMe { get; set; }
        public string Resume { get; set; }
        public string UserType { get; set; }
        public string CurrencyType { get; set; }
        public string ImgPath { get; set; }

    }
}