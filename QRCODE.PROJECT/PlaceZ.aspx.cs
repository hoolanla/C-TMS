using QRCODE.PROJECT.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using Spire.Barcode;
using System.Drawing;
using System.Data;
using System.Threading;

namespace QRCODE.PROJECT
{
    public partial class PlaceZ : Page
    {


        MODEL.Criteria.jobDetail JOB = new MODEL.Criteria.jobDetail();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["PLACE_TYPE"] != null)
            {
                if (Session["PLACE_TYPE"].ToString() != "Z" && Session["LEVEL"].ToString() != "3")
                {
                    Response.Redirect("~/Authorize.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Authorize.aspx");

            }



            if (!IsPostBack)
            {
                BindGrid();
            }
        }


        private void BindGrid()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            Class.clsDB DB = new Class.clsDB();
            string sql = "select job_id,job_name,place_type,date_format(job_date,'%d/%m/%Y') as job_date,date_format(create_date,'%d/%m/%Y') as create_date,";
            sql += "create_by,print_barcode,date_format(timestamp1,'%H:%i:%s') as timestamp1,date_format(timestamp2,'%H:%i:%s') as timestamp2,";
            sql += "date_format(timestamp3,'%H:%i:%s') as timestamp3,date_format(timestamp4,'%H:%i:%s') as timestamp4";
            sql += " From job_trailer WHERE show_=1 and job_date = '" + today + "' order by job_id desc";
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

            ImageButton myImageButtonSound = e.Row.FindControl("SOUND") as ImageButton;
            if (myImageButton2 != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "timestamp2").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "timestamp3").ToString() == "")
                {
                    myImageButtonSound.ImageUrl = "Images/sound.png";

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "uKey", "PlaySound_Warning();", true);
                    

                    e.Row.BackColor = Color.Red;
                    e.Row.ForeColor = Color.Yellow;
                }
                else
                {
                    myImageButtonSound.ImageUrl = "Images/wait.png";
                }
            }
        }

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {


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

       
        protected void txtBarcode_TextChanged(object sender, EventArgs e)
        {

            
            
            string barcode = txtBarcode.Text;
            


            //GET STATUS BARCODE IF STATUS 1 CALL Stamp1 
            //STATUS 2 (stamp1 && stamp2 = true) CALL stamp3
            //STATUS 3 CALL stamp4

            int retStatus;

            BLL.job _BLL = new BLL.job();
            retStatus = _BLL.GetStatus_Barcode(barcode);

            switch(retStatus)
            {
                case 1:
                    _BLL.Update_stamp1(barcode);
                    break;
                case 2:
                    _BLL.Update_stamp3(barcode);

                    Session["TIME"] = DateTime.Now;
             

                  
                    break;
                case 3:
                   

                    if (Session["TIME"] != null)
                    {
                        DateTime dt2 = (DateTime)Session["TIME"];
                        DateTime dt3 = DateTime.Now;
                        TimeSpan span;
                        span = dt3.Subtract(dt2);

                        if (span.Minutes > 1)
                        {
                            _BLL.Update_stamp4(barcode);
                        }
                    }
                    else
                    {
                        _BLL.Update_stamp4(barcode);
                    }
                    break;
            }

            txtBarcode.Text = "";
            BindGrid();
          
           // string sql = "Select * from job_trailer where job_id = " + barcode;
           // DataTable dt;
           //dt =  GetData(sql);
           //grid.DataSource = dt;
           //grid.DataBind();
            
        }





        protected void Timer1_Tick1(object sender, EventArgs e)
        {

            lblresult.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            BindGrid();



        }

     


    }
}