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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {
            txtLoginId.Value = HttpContext.Current.Session["EmployeeId"].ToString();
        }
        protected void GoToLogin(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void SaveChangedPassword(object sender, EventArgs e)
        {
            BMS_New.Models.Login.Model.Login login = new BMS_New.Models.Login.Model.Login();
            login.LoginId = txtLoginId.Value;
            //login.Password = CryptorEngine.Encrypt(txtOldPassword.Value, true);
            login.Password = txtOldPassword.Value;

            LoginRequest objlogin = new LoginRequest(login);
            LoginResponse objResponse = objlogin.ValidateUser();
            if (objResponse.StatusFl)
            {
                if (objResponse.Msg == "Success")
                {
                    login.Password = txtNewPassword.Value;
                    //login.Password = CryptorEngine.Encrypt(txtNewPassword.Value, true);
                    objlogin = new LoginRequest(login);
                    objResponse = objlogin.ChangePassword();
                    if (objResponse.StatusFl)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "setTimeout(function(){alert('Password Changed Successfully.');},1000);", true);
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "setTimeout(function(){alert('Something went wrong.');},1000);", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "setTimeout(function(){alert('Not a valid user.Please verify your login id and password.');},1000);", true);
            }
        }
    }
}