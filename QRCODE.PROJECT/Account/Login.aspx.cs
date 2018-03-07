using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using QRCODE.PROJECT.Models;
using System.Data;


namespace QRCODE.PROJECT.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {

                String _userName, _password;
                _userName = UserName.Text.ToString();
                _password = Password.Text.ToString();
                String sql;
                DataTable dt;
                sql = "Select * from account where username='" + _userName + "' AND password='" + _password + "'";

                Class.clsDB conn = new Class.clsDB();
                dt = conn.ExecuteDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    Session["TITLE"] = dt.Rows[0]["title"].ToString();
                    Session["NAME"] = dt.Rows[0]["name"].ToString();
                    Session["SURNAME"] = dt.Rows[0]["surname"].ToString();
                    Session["LEVEL"] = dt.Rows[0]["level"].ToString();
                    Session["EMAIL"] = dt.Rows[0]["email"].ToString();
                    Session["PLACE_TYPE"] = dt.Rows[0]["place_type"].ToString();

                    string place_type = dt.Rows[0]["place_type"].ToString();
                    string Lev = dt.Rows[0]["level"].ToString();

                    Class.ClsModule obj = new Class.ClsModule();

                    string IP = obj.GetIPAddress();
                    string page = obj.getPageName();


                    MODEL.Log L = new MODEL.Log();
                    Helper.Utility Log = new Helper.Utility();

                    L.content = "Log in success.";
                    L.create_by = Session["EMAIL"].ToString();
                    L.ip = IP;
                    L.page = page;
                    Log.WriteLog(L);

                    
                    switch(place_type)
                    {
                        case "A" :
                            Response.Redirect("~/PlaceA.aspx");
                            break;
                        case "B":
                            Response.Redirect("~/PlaceB.aspx");
                            break;
                        case "C":
                            Response.Redirect("~/PlaceC.aspx");
                            break;
                        case "Z":
                            Response.Redirect("~/PlaceZ.aspx");
                            break;

                    }








                    Response.Redirect("../Default.aspx");
                }
            }
        }
    }
}