using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace QRCODE.PROJECT
{
    public partial class StationA : System.Web.UI.Page
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


            string today = DateTime.Now.Date.ToString("yyyy-MM-dd");

            Class.clsDB DB = new Class.clsDB();
            string sql = "select job_id,job_name,date_format(job_date,'%d/%m/%Y') as job_date,date_format(create_date,'%d/%m/%Y') as create_date,";
            sql += "create_by,print_barcode,date_format(timestamp1,'%H:%m:%s') as timestamp1,date_format(timestamp2,'%H:%m:%s') as timestamp2,";
            sql += "date_format(timestamp3,'%H:%m:%s') as timestamp3,date_format(timestamp4,'%H:%m:%s') as timestamp4 From job_trailer";
            sql += " WHERE place_type='A' AND show_=1 AND job_date ='" + today + "' ORDER by job_id desc";
            DataTable dt;
            dt = DB.ExecuteDataTable(sql);

            grid.DataSource = dt;

            grid.DataBind();
            DB.Close();
            DB.Dispose();

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
        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string job_id = grid.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("grid_nested") as GridView;
                gvOrders.DataSource = GetData(string.Format("select * from job_trailer_detail where show_=1 and job_id='{0}'", job_id));
                gvOrders.DataBind();
            }




            //ImageButton myImageButton = e.Row.FindControl("print_barcode") as ImageButton;
            //if (myImageButton != null)
            //{
            //    if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "print_barcode")))
            //    {
            //        myImageButton.ImageUrl = "Images/check.png";
            //    }
            //    else
            //    {
            //        myImageButton.ImageUrl = "Images/wait.png";
            //    }
            //}


            ImageButton myImageButton1 = e.Row.FindControl("timestamp1") as ImageButton;
            if (myImageButton1 != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "timestamp1").ToString() != "")
                {
                    myImageButton1.ImageUrl = "Images/check.png";
                    myImageButton1.ID = "check";
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
            if (myImageButton1 != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "timestamp1").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "timestamp2").ToString() == "")
                {
                    myImageButtonSound.ImageUrl = "Images/sound.png";
                    System.Media.SystemSounds.Asterisk.Play();

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

            if (e.CommandName == "timestamp2")
            {

                int idx = Convert.ToInt32(e.CommandArgument);
                GridViewRow Row = grid.Rows[idx];

                string job_id;
                job_id = Row.Cells[1].Text;

                ImageButton myImageButton1 = grid.Rows[idx].FindControl("timestamp1") as ImageButton;

            //    Timer1.Enabled = false;
                lbl_job_id.Text = job_id;
                Session["JOB_ID"] = job_id;

                //   DateTime dt = DateTime.Parse("12:35 PM");
                DateTime dt = DateTime.Now;
                MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
                if (dt.ToString("tt") == "AM")
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                }
                else
                {
                    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
                }
           //     TimeSelector1.SetTime(dt.Hour, dt.Minute, am_pm);

             //   if (myImageButton1.ImageUrl == "Images/check.png")
             //   {
                    this.ModalPopupExtender1.Show();

            //    }

            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {


            string date_ = DateTime.Now.ToString("yyyy-MM-dd");
         //   string AmPm = TimeSelector1.AmPm.ToString();
            string H = "00";

            //if (AmPm == "AM")
            //{
            //    switch (TimeSelector1.Hour)
            //    {
            //        case 1:
            //            H = "01";
            //            break;
            //        case 2:
            //            H = "02";
            //            break;
            //        case 3:
            //            H = "03";
            //            break;
            //        case 4:
            //            H = "04";
            //            break;
            //        case 5:
            //            H = "05";
            //            break;
            //        case 6:
            //            H = "06";
            //            break;
            //        case 7:
            //            H = "07";
            //            break;
            //        case 8:
            //            H = "08";
            //            break;
            //        case 9:
            //            H = "09";
            //            break;
            //        case 10:
            //            H = "10";
            //            break;
            //        case 11:
            //            H = "11";
            //            break;
            //        case 12:
            //            H = "12";
            //            break;
            //    }
            //}
            //if (AmPm == "PM")
            //{
            //    switch (TimeSelector1.Hour)
            //    {
            //        case 1:
            //            H = "13";
            //            break;
            //        case 2:
            //            H = "14";
            //            break;
            //        case 3:
            //            H = "15";
            //            break;
            //        case 4:
            //            H = "16";
            //            break;
            //        case 5:
            //            H = "17";
            //            break;
            //        case 6:
            //            H = "18";
            //            break;
            //        case 7:
            //            H = "19";
            //            break;
            //        case 8:
            //            H = "20";
            //            break;
            //        case 9:
            //            H = "21";
            //            break;
            //        case 10:
            //            H = "22";
            //            break;
            //        case 11:
            //            H = "23";
            //            break;
            //    }
            //}


         //   string strTime = date_ + " " + H + ":" + TimeSelector1.Minute + ":00";
            BLL.job _BLL = new BLL.job();
            if (lbl_job_id.Text == "")
            {
                lbl_job_id.Text = Session["JOB_ID"].ToString();
            }
        //    _BLL.Update_stamp2(strTime, lbl_job_id.Text);



         //   Timer1.Enabled = true;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {


//Timer1.Enabled = true;
        }
    }
}