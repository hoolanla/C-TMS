using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QRCODE.PROJECT
{
    public partial class Stamp2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                BindGrid();
            }

        }


        private void BindGrid()
        {
            Class.clsDB DB = new Class.clsDB();
            string sql = "select job_id,job_name,create_by,create_date,print_barcode,timestamp1,timestamp2,timestamp3,timestamp4 From job_trailer order by job_id desc";
            DataTable dt;
            dt = DB.ExecuteDataTable(sql);
            grid.DataSource = dt;
            // grid.DataKeyNames = "doc_id";
            grid.DataBind();

        }



    
        private static DataTable GetData(string sql)
        {
            Class.clsDB DB = new Class.clsDB();
            DataTable dt;
            dt = DB.ExecuteDataTable(sql);
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
                gvOrders.DataSource = GetData(string.Format("select * from job_trailer_detail where job_id={0}", job_id));
                gvOrders.DataBind();
            }




            ImageButton myImageButton = e.Row.FindControl("print_barcode") as ImageButton;
            if (myImageButton != null)
            {
                if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "print_barcode")))
                {
                    myImageButton.ImageUrl = "Images/check.png";
                }
                else
                {
                    myImageButton.ImageUrl = "Images/wait.png";
                }
            }


            ImageButton myImageButton1 = e.Row.FindControl("timestamp1") as ImageButton;
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

        }

        protected void grid_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

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
                    Response.Redirect("/Report/rpt_Job.aspx");
          
            }



            if (e.CommandName == "timestamp2")
            {


                Timer1.Enabled = false;
                
                txtTime.Text = DateTime.Now.ToString("hh:mm:ss");
                this.ModalPopupExtender1.Show();
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none","<script>alert('test');</script>", false);

        

            }



        }

      

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;



        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
        }

        
    }
}