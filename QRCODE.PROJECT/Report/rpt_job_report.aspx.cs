using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QRCODE.PROJECT.Report
{
    public partial class rpt_job_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            genReport();

        }

        private bool genReport()
        {

            DataTable dtMap = new DataTable("job_report");  //*** DataTable Map DataSet.xsd ***//
            DataTable m_dt = (DataTable)Session["DATATABLE"];

            DataRow dr = null;
            dtMap.Columns.Add(new DataColumn("job_id", typeof(string)));
            dtMap.Columns.Add(new DataColumn("job_name", typeof(string)));
            dtMap.Columns.Add(new DataColumn("job_date", typeof(string)));
     

            dtMap.Columns.Add(new DataColumn("timestamp1", typeof(string)));
            dtMap.Columns.Add(new DataColumn("timestamp2", typeof(string)));
            dtMap.Columns.Add(new DataColumn("timestamp3", typeof(string)));
            dtMap.Columns.Add(new DataColumn("timestamp4", typeof(string)));
           


      


            for (int i = 0; i < (m_dt.Rows.Count); i++)
            {
                dr = dtMap.NewRow();
                dr["job_id"] = m_dt.Rows[i]["job_id"];
                dr["job_name"] = m_dt.Rows[i]["job_name"];
                dr["job_date"] = m_dt.Rows[i]["job_date"];
                dr["timestamp1"] = m_dt.Rows[i]["timestamp1"];
                dr["timestamp2"] = m_dt.Rows[i]["timestamp2"];
                dr["timestamp3"] = m_dt.Rows[i]["timestamp3"];
                dr["timestamp4"] = m_dt.Rows[i]["timestamp4"];
               

                dtMap.Rows.Add(dr);
            }


            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Report/job_report.rpt"));

            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in rpt.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = crTable.LogOnInfo;
                object connectionInfo = tableLogOnInfo.ConnectionInfo;
                crTable.ApplyLogOnInfo(tableLogOnInfo);
            }

            rpt.SetDataSource(dtMap);
            crVw.ReportSource = rpt;
       

            return true;
        }
    }
}