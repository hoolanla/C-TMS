using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace QRCODE.PROJECT.Report
{
    public partial class rpt_Job : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            genReport();


        }


        private bool genReport()
         {

            DataTable dtMap = new DataTable("job");  //*** DataTable Map DataSet.xsd ***//
            DataTable m_dt = (DataTable)Session["DATATABLE"];

            DataRow dr = null;
            dtMap.Columns.Add(new DataColumn("job_id", typeof(string)));
            dtMap.Columns.Add(new DataColumn("job_name", typeof(string)));
            dtMap.Columns.Add(new DataColumn("job_date", typeof(string)));
            dtMap.Columns.Add(new DataColumn("place_get_job", typeof(string)));
            dtMap.Columns.Add(new DataColumn("container_type", typeof(string)));
            dtMap.Columns.Add(new DataColumn("container_dim", typeof(string)));
            dtMap.Columns.Add(new DataColumn("cust_dest", typeof(string)));
            dtMap.Columns.Add(new DataColumn("code_name", typeof(string)));
            dtMap.Columns.Add(new DataColumn("appointed_time", typeof(string)));
            dtMap.Columns.Add(new DataColumn("doc_no", typeof(string)));
            dtMap.Columns.Add(new DataColumn("place_send_job", typeof(string)));
            dtMap.Columns.Add(new DataColumn("send_company", typeof(string)));
            dtMap.Columns.Add(new DataColumn("remark", typeof(string)));
            dtMap.Columns.Add(new DataColumn("barcode", typeof(System.Byte[])));


            FileStream fiStream = new FileStream(Server.MapPath("~/Barcode/" + m_dt.Rows[0]["job_id"].ToString() + ".jpeg"), FileMode.Open,FileAccess.Read);
            BinaryReader binReader = new BinaryReader(fiStream);
            byte[] pic1 = { };
            pic1 = binReader.ReadBytes((int)fiStream.Length);

            fiStream.Close();
            binReader.Close();


            for (int i = 0; i < (m_dt.Rows.Count ); i++)
            {
                dr = dtMap.NewRow();
                dr["job_id"] = m_dt.Rows[i]["job_id"];
                dr["job_name"] = m_dt.Rows[i]["job_name"];
                dr["job_date"] = m_dt.Rows[i]["job_date"];
                dr["place_get_job"] = m_dt.Rows[i]["place_get_job"];
                dr["container_type"] = m_dt.Rows[i]["container_type"];
                dr["container_dim"] = m_dt.Rows[i]["container_dim"];
                dr["cust_dest"] = m_dt.Rows[i]["cust_dest"];
                dr["code_name"] = m_dt.Rows[i]["code_name"];
                dr["appointed_time"] = m_dt.Rows[i]["appointed_time"];
                dr["doc_no"] = m_dt.Rows[i]["doc_no"];
                dr["place_send_job"] = m_dt.Rows[i]["place_send_job"];
                dr["send_company"] = m_dt.Rows[i]["send_company"];
                dr["remark"] = m_dt.Rows[i]["remark"];
                dr["Barcode"] = pic1;

                dtMap.Rows.Add(dr);
            }


            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Report/job.rpt"));

            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in rpt.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = crTable.LogOnInfo;
                object connectionInfo = tableLogOnInfo.ConnectionInfo;
                crTable.ApplyLogOnInfo(tableLogOnInfo);
            }

              rpt.SetDataSource(dtMap);
              crVw.ReportSource = rpt;
            //  crVw.RefreshReport();
        
            return true;
        }
    }
}