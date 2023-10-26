using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BMS_New
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////string login = HttpContext.Current.Session["EmployeeId"].ToString();
            //BMS_New.Models.BMS.Model.AdminUser user = new BMS_New.Models.BMS.Model.AdminUser();
            //user.userLogin = Convert.ToString(Session["EmployeeId"]);
            //user.moduleDatabase = Convert.ToString(Session["ModuleDatabase"]);
            //user.companyId = Convert.ToInt32(Session["CompanyId"]);
            //AdminUserRequest objUser = new AdminUserRequest(user);
            //AdminUserResponse objResponse = objUser.GetUserDetails();
            //if (objResponse.StatusFl)
            //{

            //    //SpComapnyName.InnerHtml = objResponse.User.userName;
            //    SpComapnyName.InnerHtml = objResponse.User.CompanyName;
            //}
            SpComapnyName.InnerText = Session["CompanyName"].ToString();

        }
    }
}