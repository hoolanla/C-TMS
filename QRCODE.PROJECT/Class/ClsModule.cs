using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;

namespace QRCODE.PROJECT.Class
{
    public class ClsModule
    {

        public string getRuningNoDoc()
        {
            //Format yyyyMMdd-01   2018011501

            clsDB db = new clsDB();
            string sql = null;
            string curDate;
            curDate = DateTime.Now.ToString("yyyyMMdd");
            sql = "Select job_id From job_trailer where job_id like '" + curDate + "%'";
            object MyScalar = null;
            DataTable dt;

            dt = db.ExecuteDataTable(sql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    sql = "Select Max(job_id) + 1 From job_trailer";
                    MyScalar = db.ExecuteScalar(sql);
                    return MyScalar.ToString();
                }
                else
                {

                    return curDate.ToString() + "01";
                }


            }


            if (MyScalar != null)
            {

            }
            else
            {


            }


            return curDate;
        }


        public string getPageName()
        {
            string filename = Path.GetFileName(HttpContext.Current.Request.Path);
            return filename;
        }

        public string GetIPAddress()
        {
            string ipaddress;
            ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return ipaddress;
        }

    }
}