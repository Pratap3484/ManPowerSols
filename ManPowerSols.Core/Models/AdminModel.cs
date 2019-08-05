using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManPowerSols.Core.Models
{
    public class AdminModel
    {

    }
    public class ApproveUser
    {
        public string emailid { get; set; }
        public string usertype { get; set; }
        public string Status { get; set; }
    }
    public class UpdateAccess
    {
        public string Rec_ID { get; set; }
        public string UserID { get; set; }
        public string RecordType { get; set; }
        public string Access_status { get; set; }
    }
}