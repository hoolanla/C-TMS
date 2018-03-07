using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QRCODE.PROJECT
{
    public partial class DataJob : System.Web.UI.Page
    {

        MODEL.Criteria.job obj = new MODEL.Criteria.job();


        protected void Page_Load(object sender, EventArgs e)
        {


            //Class.ClsModule obj = new Class.ClsModule();
            //string pageName,ip;
            //pageName = obj.getPageName();
            //ip = obj.GetIPAddress();


            //Response.Write(pageName);
            //Response.Write(ip);


            if (Session["NAME"] != null)
            {
              
            }
            else
            {
                Response.Redirect("~/Authorize.aspx");

            }





            if (!IsPostBack)
            {
                BindGrid();
            }
            else
            {
             //   BindgridSearch();
            }

        }


        private void BindGrid()
        {
            Class.clsDB DB = new Class.clsDB();
            string sql = "select job_id,job_name,place_type,create_by,date_format(job_date,'%d/%m/%Y') as job_date,";
            sql += " date_format(create_date,'%d/%m/%Y') as create_date,print_barcode,date_format(timestamp1,'%H:%m:%s') as timestamp1,";
            sql += "date_format(timestamp2,'%H:%m:%s') as timestamp2,";
            sql += "date_format(timestamp3,'%H:%m:%s') as timestamp3,date_format(timestamp4,'%H:%m:%s') as timestamp4 From job_trailer where show_=1 order by job_id desc";
            DataTable dt;
            dt = DB.ExecuteDataTable(sql);
            DB.Close();
            DB.Dispose();
            Session["DATATABLE"] = dt;
            grid.DataSource = dt;
            // grid.DataKeyNames = "doc_id";
            grid.DataBind();

        }


        private static DataTable GetData(string sql)
        {
            Class.clsDB DB = new Class.clsDB();
            DataTable dt;
            dt = DB.ExecuteDataTable(sql);
            DB.Close();
            DB.Dispose();
           return dt;
        
        }

        protected void Timer1_Tick(object sender, EventArgs e)
       {

           BindGrid();
       }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string job_id = grid.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("grid_nested") as GridView;
                gvOrders.DataSource = GetData(string.Format("select * from job_trailer_detail where show_=1 and job_id='{0}'", job_id));
                gvOrders.DataBind();
            }




            ImageButton myImageButton = e.Row.FindControl("print_barcode") as ImageButton;
            if (myImageButton != null)
            {
                if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "print_barcode")))
                {
                    myImageButton.ImageUrl = "Images/print.png";
                }
                else
                {
                    myImageButton.ImageUrl = "Images/print.png";
                }
            }


            ImageButton myImageButton1 = e.Row.FindControl("timestamp1") as ImageButton;


         //   e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Left;

            if (myImageButton1 != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "timestamp1").ToString() != "")
                {
                    myImageButton1.ImageUrl = "Images/check.png";
                }
                else
                {
                    myImageButton1.ImageUrl = "Images/wait.png";
                }
            }

            ImageButton myImageButton2 = e.Row.FindControl("timestamp2") as ImageButton;
            if (myImageButton2 != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "timestamp2").ToString() != "")
                {
                    myImageButton2.ImageUrl = "Images/check.png";
                }
                else
                {
                    myImageButton2.ImageUrl = "Images/wait.png";
                }
            }


            ImageButton myImageButton3 = e.Row.FindControl("timestamp3") as ImageButton;
            if (myImageButton3 != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "timestamp3").ToString() != "")
                {
                    myImageButton3.ImageUrl = "Images/check.png";
                }
                else
                {
                    myImageButton3.ImageUrl = "Images/wait.png";
                }
            }



            ImageButton myImageButton4 = e.Row.FindControl("timestamp4") as ImageButton;
            if (myImageButton4 != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "timestamp4").ToString() != "")
                {
                    myImageButton4.ImageUrl = "Images/check.png";
                }
                else
                {
                    myImageButton4.ImageUrl = "Images/wait.png";
                }
            }


            ImageButton myImageButtonReport = e.Row.FindControl("REPORT") as ImageButton;
            if (myImageButtonReport != null)
            {

                myImageButtonReport.ImageUrl = "Images/report.png";
             
            }




        }

        protected void grid_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid.PageIndex = e.NewPageIndex;

            BindGrid();
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "print_barcode")
            {
                int idx = Convert.ToInt32(e.CommandArgument);
                GridViewRow Row = grid.Rows[idx];

                    string job_id;
                    job_id = Row.Cells[1].Text;
                    DataTable dt;
                    BLL.job _BLL = new BLL.job();
                    dt = _BLL.getData_ReportJob(job_id);
                    Session["DATATABLE"] = dt;

                    //Model.Log L = new Model.Log();
                    //Helper.Utility Log = new Helper.Utility();
                    //L.content = "Go to SendMailApprove.aspx.";
                    //L.create_by = Session["EMAIL"].ToString();
                    //Log.WriteLog(L);
                    Response.Redirect("~/Report/rpt_Job.aspx");
          
            }


            if (e.CommandName == "REPORT")
            {
                int idx = Convert.ToInt32(e.CommandArgument);
                GridViewRow Row = grid.Rows[idx];

                string job_id;
                job_id = Row.Cells[1].Text;
                DataTable dt;
                BLL.job _BLL = new BLL.job();
                dt = _BLL.getData_ReportJobTimestamp(job_id);
                Session["DATATABLE"] = dt;

                //Model.Log L = new Model.Log();
                //Helper.Utility Log = new Helper.Utility();
                //L.content = "Go to SendMailApprove.aspx.";
                //L.create_by = Session["EMAIL"].ToString();
                //Log.WriteLog(L);
                Response.Redirect("~/Report/rpt_job_report.aspx");

            }



            if (e.CommandName == "DELETE")
            {
                int idx = Convert.ToInt32(e.CommandArgument);
                GridViewRow Row = grid.Rows[idx];

                string job_id;
                job_id = Row.Cells[1].Text;
     
                BLL.job _BLL = new BLL.job();
                _BLL.Delete_Job(job_id);
            
          

            }




        }



        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {

            BindgridSearch();

        }

        private void BindgridSearch()
        {

            grid.DataSource = null;
            Class.clsDB DB = new Class.clsDB();
            string sql = "select job_id,job_name,place_type,create_by,date_format(job_date,'%d/%m/%Y') as job_date,";
            sql += "date_format(create_date,'%d/%m/%Y') as create_date,print_barcode,date_format(timestamp1,'%H:%m:%s') as timestamp1,";
            sql += "date_format(timestamp2,'%H:%m:%s') as timestamp2,date_format(timestamp3,'%H:%m:%s') as timestamp3,";
            sql += "date_format(timestamp4,'%H:%m:%s') as timestamp4 From job_trailer";
            sql += " WHERE (job_id like '" + txtJob.Text + "%' OR job_name like '" + txtJob.Text + "%') AND show_=1";
            sql += " order by job_id desc";
            DataTable dt;
            dt = DB.ExecuteDataTable(sql);
            Session["DATATABLE"] = dt;
            grid.DataSource = dt;
            // grid.DataKeyNames = "doc_id";
            grid.DataBind();

           
           
        }

        private bool initDateSearch()
        {
            //if ((txtDate.Text.Length == 10) && (txtDateEnd.Text.Length == 10))
            //{


            //}
            //else
            //{


            //}

            return true;
        }

     


        protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


                int idx = Convert.ToInt32(e.RowIndex);
                GridViewRow Row = grid.Rows[idx];

                string job_id;
                job_id = Row.Cells[1].Text;

                BLL.job _BLL = new BLL.job();
                _BLL.Delete_Job(job_id);

                BindGrid();

        }

        protected void btnReportAll_Click(object sender, ImageClickEventArgs e)
        {


            BLL.job _BLL = new BLL.job();

            //Model.Log L = new Model.Log();
            //Helper.Utility Log = new Helper.Utility();
            //L.content = "Go to SendMailApprove.aspx.";
            //L.create_by = Session["EMAIL"].ToString();
            //Log.WriteLog(L);
            Response.Redirect("~/Report/rpt_job_report.aspx");


        }

        protected void txtJob_TextChanged(object sender, EventArgs e)
        {
            BindgridSearch();
        }

    }
}