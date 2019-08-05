using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ManPowerSols.Core
{
    public class ErrorWriter
    {
        public static void WriteLog(string ErrType, string ErrDesc, string innerexp, string ErrLocation, string servicename)
        {
            StreamWriter errFile;
            StringBuilder sbError;
            if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile"))
            {
                System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile");
            }
            errFile = File.AppendText(System.AppDomain.CurrentDomain.BaseDirectory + "\\LogFile\\Error_" + DateTime.Now.ToString("ddd yyyy") + ".log");
            sbError = new StringBuilder("");
            sbError.Append("Err Date:" + ('\t' + (DateTime.Now + "\r\n")));
            sbError.Append("Err Message:" + ("\t" + (ErrDesc + "\r\n")));
            sbError.Append("Err Type:" + ("\t" + (ErrType + "\r\n")));
            sbError.Append("Err Inner Exception:" + ("\t" + (innerexp + "\r\n")));
            sbError.Append("Err Location:" + ("\t" + (ErrLocation + "\r\n")));
            sbError.Append("Method Info:" + ('\t' + (servicename + ('\t' + "\r\n"))));
            sbError.Append("****************************************************************************************************************" + ("\r\n" + "\r\n"));
            errFile.WriteLine(sbError.ToString());
            errFile.Close();
            if (errFile == null)
            {
                errFile.Close();
                errFile = null;
            }
        }
    }
}