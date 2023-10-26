
using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BMS_New.Models.BMS.Model;
using BMS_New.Models.Infrastructure;
using System.Text;

namespace BMS_New
{
    public partial class BMSMaster : System.Web.UI.MasterPage
    {
        StringBuilder sb = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserDetails();
            GetUserCompanyList();
        }
        /****Add By Jitender******/
        //private void GetUserDetails()
        //{
        //    try
        //    {
        //        if (String.IsNullOrEmpty(Convert.ToString(Session["EmployeeId"])) || String.IsNullOrEmpty(Convert.ToString(Session["ModuleDatabase"])))
        //        {
        //            Response.Redirect("../Login.aspx");
        //        }
        //        User user = new User();
        //        user.userLogin = Convert.ToString(Session["EmployeeId"]);
        //        user.moduleDatabase = Convert.ToString(Session["ModuleDatabase"]);
        //        user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
        //        UserRequest objUser = new UserRequest(user);
        //        UserResponse objResponse = objUser.GetUserDetails();
        //        if (objResponse.StatusFl)
        //        {
        //            //ImgUserUploadedImageHeader.Attributes["src"] = "images/user/" + objResponse.User.uploadAvatar;
        //            SpUserNameHeader.InnerHtml = objResponse.User.userName;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(Session["EmployeeId"]), Convert.ToInt32(Session["ModuleId"]), Convert.ToInt32(Session["CompanyId"]));
        //    }

        //}
        /*********End*************/
        private void GetUserDetails()
        {
            try
            {
                if (String.IsNullOrEmpty(Convert.ToString(Session["EmployeeId"])) || String.IsNullOrEmpty(Convert.ToString(Session["ModuleDatabase"])))
                {
                    Response.Redirect("/LogOut.aspx");
                }
                BMS_New.Models.BMS.Model.AdminUser user = new BMS_New.Models.BMS.Model.AdminUser();
                user.userLogin = Convert.ToString(Session["EmployeeId"]);
                user.moduleDatabase = Convert.ToString(Session["ModuleDatabase"]);
                user.companyId = Convert.ToInt32(Session["CompanyId"]);
                AdminUserRequest objUser = new AdminUserRequest(user);
                AdminUserResponse objResponse = objUser.GetUserDetails();
                if (objResponse.StatusFl)
                {

                    SpUserNameHeader.InnerHtml = objResponse.User.userName;
                    //SpComapnyName.InnerHtml = objResponse.User.CompanyName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void GetUserCompanyList()
        {
            try
            {
                if (String.IsNullOrEmpty(Convert.ToString(Session["EmployeeId"])) || String.IsNullOrEmpty(Convert.ToString(Session["ModuleDatabase"])))
                {
                    Response.Redirect("/LogOut.aspx");
                }
                BMS_New.Models.BMS.Model.AdminUser user = new BMS_New.Models.BMS.Model.AdminUser();
                user.userLogin = Convert.ToString(Session["EmployeeId"]);
                AdminUserRequest objUser = new AdminUserRequest(user);
                AdminUserResponse objResponse = objUser.GetUserCompanyList();
                if (objResponse.StatusFl)
                {
                    sb.Append("<select>");
                    sb.Append("<option value='0'>-------Select Company------</option>");
                    foreach (var item in objResponse.User.CompanyMapping)
                    {
                        sb.Append("<option value='" + item.companyId + "'>" + item.CompanyName + "</option>");
                    }
                    sb.Append("</select>");

                    CompanyList.InnerHtml = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}