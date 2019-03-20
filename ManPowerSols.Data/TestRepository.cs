using ManPowerSols.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManPowerSols.Data
{
    public class TestRepository
    {
        public string TestRep(TestModel tm)
        {
           return tm.fname + "  "+tm.lname ;
        }
    }
}