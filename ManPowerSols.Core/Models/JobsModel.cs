using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManPowerSols.Core.Models
{
    public class JobsModel
    {
    }
    public class JobApplyModel
    {
        public int RecID { get; set; }
        public string JobID { get; set; }
        public string NoOfEmp { get; set; }
        public string UserID { get; set; }
        public string post_comments { get; set; }
        public string UserType { get; set; }
        public string Other { get; set; }
        public string Access_status { get; set; }
    }
}