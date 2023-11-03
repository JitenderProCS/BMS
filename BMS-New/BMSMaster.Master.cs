
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
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace BMS_New
{
    public partial class BMSMaster : System.Web.UI.MasterPage
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sb1 = new StringBuilder();
        protected string ltrMenu { get; set; }
        string strGrpName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetUserDetails();
            GetUserCompanyList();
            try
            {
                if (String.IsNullOrEmpty(Convert.ToString(Session["ModuleDatabase"])))
                {
                    Response.Redirect("../Login.aspx");
                }
                string sConStr = CryptoEngine.Decrypt(ConfigurationManager.AppSettings["ConnectionString"], true);
                //String sConnectionString = CryptorEngine.Decrypt(Convert.ToString(ConfigurationManager.AppSettings["ConnectionString"]), true);
                using (SqlConnection sCon = new SqlConnection(sConStr))
                {
                    try
                    {
                        sCon.Open();
                        var database = Convert.ToString(Session["ModuleDatabase"]);
                        sCon.ChangeDatabase(database);
                        SqlCommand sCmd = new SqlCommand();
                        sCmd.Connection = sCon;
                        sCmd.CommandText = "BMS_ADMIN_MENU";
                        sCmd.CommandType = CommandType.StoredProcedure;
                        sCmd.CommandTimeout = 0;
                        sCmd.Parameters.Clear();
                        sCmd.Parameters.AddWithValue("@LOGIN_ID", Convert.ToString(Session["EmployeeId"]));
                        //sCmd.Parameters.AddWithValue("@Username", Convert.ToString(Session["Username"]));
                        //sCmd.Parameters.AddWithValue("@UserRole", Convert.ToString(Session["RoleName"]));
                        //sCmd.Parameters.AddWithValue("@RoleId", Convert.ToInt32(Session["RoleId"]));
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(sCmd);
                        da.Fill(ds);
                        DataTable dt = new DataTable();
                        dt = ds.Tables[0];
                        DataTable dt1 = new DataTable();
                        dt1 = ds.Tables[1];
                        sb1.Append("<ul class='menu-nav'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow[] dr = dt1.Select("GRP_ID=" + Convert.ToString(dt.Rows[i]["GRP_ID"]));

                            if (Convert.ToString(dt.Rows[i]["GRP_ID"]) != "0")
                            {
                                sb1.Append("<li class='menu-item menu-item-submenu menu-item-rel menu-item-active' data-menu-toggle='click' aria-haspopup='false'>");
                                strGrpName = Convert.ToString(dt.Rows[i]["GRP_NM"]);
                                sb1.Append("<a href='javascript:;' class='menu-link menu-toggle'>");
                                sb1.Append(" <span class='svg-icon svg-icon-primary svg-icon-2x'></span>");
                                sb1.Append(" <span class='menu - text'>" + strGrpName + "</span>");
                                //sb1.Append(" <span class='title'>" + strGrpName + "</span>");
                                sb1.Append("<i class='arrow'></i></a>");
                                getMenuItems(dr, strGrpName, dt1);
                            }
                        }
                        sb1.Append("</li>");
                        sb1.Append("</ul>");
                        ltrMenu = Convert.ToString(sb1);
                        //BMS_New.Models.Login.Model.Login login = new BMS_New.Models.Login.Model.Login();
                        //LoginRequest objlogin = new LoginRequest(login);
                        //LoginResponse objResponse = objlogin.SetSessionLastAccessTime();
                    }
                    catch (Exception ex)
                    {
                        new LogHelper().AddExceptionLogs(Convert.ToString(ex.Message), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(Session["EmployeeId"]), Convert.ToInt32(Session["ModuleId"]), Convert.ToInt32(Session["CompanyId"]));
                        String Message = ex.Message;
                        Message = Message.Replace("\r", " ").Replace("\n", " ").Replace("'", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + Message + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(Session["EmployeeId"]), Convert.ToInt32(Session["ModuleId"]), Convert.ToInt32(Session["CompanyId"]));
            }
        }
        private void getMenuItems(DataRow[] dr1, string strGrpName, DataTable dt1)
        {
            try
            {
                ArrayList arrlist = new ArrayList();
                foreach (DataRow ddrow in dr1)
                    arrlist.Add(ddrow["MENU_ID"]);
                sb1.Append("<div class='menu-submenu menu-submenu-classic menu-submenu-left'>");
                sb1.Append("<ul class='menu-subnav'>");
                foreach (var modId in arrlist)
                {
                    DataRow[] mRow = dt1.Select("MENU_ID=" + modId);
                    foreach (DataRow modname in mRow)
                    {
                        DataRow[] newRow = dt1.Select("MENU_ID=" + modId);
                        if (newRow.Length != 0)
                        {
                            sb1.Append("<li class='menu-item'>");
                            //  HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/" +
                            sb1.Append("<a href='" + ResolveUrl(modname["MENU_URL"].ToString()) + "' class='menu-link'>");
                            sb1.Append("<span class='svg - icon svg - icon - primary svg - icon - 2x'>");
                            sb1.Append(@"<svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                               <rect x=""0"" y=""0"" width=""24"" height=""24""></rect>
                       <path d=""M2.56066017,10.6819805 L4.68198052,8.56066017 C5.26776695,7.97487373 6.21751442,7.97487373 6.80330086,8.56066017 L8.9246212,10.6819805 C9.51040764,11.267767 9.51040764,12.2175144 8.9246212,12.8033009 L6.80330086,14.9246212 C6.21751442,15.5104076 5.26776695,15.5104076 4.68198052,14.9246212 L2.56066017,12.8033009 C1.97487373,12.2175144 1.97487373,11.267767 2.56066017,10.6819805 Z M14.5606602,10.6819805 L16.6819805,8.56066017 C17.267767,7.97487373 18.2175144,7.97487373 18.8033009,8.56066017 L20.9246212,10.6819805 C21.5104076,11.267767 21.5104076,12.2175144 20.9246212,12.8033009 L18.8033009,14.9246212 C18.2175144,15.5104076 17.267767,15.5104076 16.6819805,14.9246212 L14.5606602,12.8033009 C13.9748737,12.2175144 13.9748737,11.267767 14.5606602,10.6819805 Z"" fill=""#000000"" opacity=""0.3""></path>
                        <path d=""M8.56066017,16.6819805 L10.6819805,14.5606602 C11.267767,13.9748737 12.2175144,13.9748737 12.8033009,14.5606602 L14.9246212,16.6819805 C15.5104076,17.267767 15.5104076,18.2175144 14.9246212,18.8033009 L12.8033009,20.9246212 C12.2175144,21.5104076 11.267767,21.5104076 10.6819805,20.9246212 L8.56066017,18.8033009 C7.97487373,18.2175144 7.97487373,17.267767 8.56066017,16.6819805 Z M8.56066017,4.68198052 L10.6819805,2.56066017 C11.267767,1.97487373 12.2175144,1.97487373 12.8033009,2.56066017 L14.9246212,4.68198052 C15.5104076,5.26776695 15.5104076,6.21751442 14.9246212,6.80330086 L12.8033009,8.9246212 C12.2175144,9.51040764 11.267767,9.51040764 10.6819805,8.9246212 L8.56066017,6.80330086 C7.97487373,6.21751442 7.97487373,5.26776695 8.56066017,4.68198052 Z"" fill=""#000000""></path>
                              </g>
                             </svg>");
                            sb1.Append("</span>");
                            sb1.Append("&nbsp;");
                            sb1.Append("<span class='menu-text'>" + modname["MENU_DISPLAY"] + "</span></a></li>");
                        }
                    }
                }
                sb1.Append("</li></ul>");
                sb1.Append("</div>");
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(Session["EmployeeId"]), Convert.ToInt32(Session["ModuleId"]), Convert.ToInt32(Session["CompanyId"]));
            }
        }
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
                    sb.Append("<select style='width: 230px; margin-inline: 20px; height: 30px;'>");
                    sb.Append("<option value='" + Session["CompanyId"] + "'>" + Session["CompanyName"] + "</option>");
                    foreach (var item in objResponse.User.CompanyMapping)
                    {
                        sb.Append("<option value='" + item.companyId + "'>" + item.CompanyName + "</option>");
                        //sb.Append("<option value='" + item.companyId + "' onclick='SwitchDashBoard(" + item.companyId + ")'>" + item.CompanyName + "</option>");

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