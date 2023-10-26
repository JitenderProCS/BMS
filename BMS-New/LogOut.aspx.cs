using BMS_New.Models.Login.Service.Request;
using BMS_New.Models.Login.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BMS_New
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BMS_New.Models.Login.Model.Login login = new BMS_New.Models.Login.Model.Login();
            LoginRequest objlogin = new LoginRequest(login);
            LoginResponse objResponse = objlogin.SetSessionStatus();
            if (objResponse.StatusFl)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            Response.Redirect("Login.aspx");
        }
    }
}