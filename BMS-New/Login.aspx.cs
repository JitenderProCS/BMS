
using BMS_New.Models.Infrastructure;
using BMS_New.Models.Login.Modal;
using BMS_New.Models.Login.Service.Request;
using BMS_New.Models.Login.Service.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BMS_New
{
    public partial class Login : System.Web.UI.Page
    {
        Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!Page.IsPostBack)
            {
                Session["salt"] = "SoftEra";
                Session["moreSalt"] = random.Next(59999, 199999).ToString();
                txtMSalt.Text = Session["moreSalt"].ToString();
                txtSalt.Text = "SoftEra";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                BMS_New.Models.Login.Model.Login login = new BMS_New.Models.Login.Model.Login();
                login.LoginId = txtLoginId.Text;
                //login.Password = CryptorEngine.Encrypt(txtPwd.Text, true);
                login.Password = txtPwd.Text;

                LoginRequest objlogin = new LoginRequest(login);
                LoginResponse objResponse = objlogin.ValidateUser();
                if (objResponse.StatusFl)
                {
                    if (objResponse.Msg == "Success")
                    {
                        //Session.Clear();
                        Session["EmployeeId"] = Convert.ToString(login.LoginId);
                        Session["CompanyId"] = Convert.ToInt32(objResponse.Usr.UAccess[0].CompanyId);
                        Session["ModuleDatabase"] = Convert.ToString(objResponse.Usr.UAccess[0].ModuleDataBase);
                        StringBuilder sb = new StringBuilder();
                        HashSet<Int32> companyIds = new HashSet<Int32>();
                        foreach (UserAccess usr in objResponse.Usr.UAccess)
                        {
                            companyIds.Add(usr.CompanyId);
                        }

                        foreach (Int32 companyId in companyIds)
                        {

                            var matchedObj = objResponse.Usr.UAccess.Where(p => p.CompanyId == companyId).ToList();
                            if (companyIds.Count == 1 && matchedObj.Count == 1)
                            {
                                Session["CompanyId"] = matchedObj[0].CompanyId;
                                Session["CompanyName"] = matchedObj[0].CompanyNm;
                                Session["ModuleId"] = matchedObj[0].ModuleId;
                                Session["ModuleName"] = matchedObj[0].ModuleNm;
                                Session["ModuleFolder"] = matchedObj[0].ModuleFolder;
                                Session["ModuleDatabase"] = matchedObj[0].ModuleDataBase;
                               // Session["UserMobile"] = matchedObj[0].Mobile;
                                bool TwoFactorAuth = Convert.ToBoolean(ConfigurationManager.AppSettings["TwoFactorAuthentication"]);
                                if (TwoFactorAuth == true)
                                {
                                   // SendSMS();
                                }
                                else
                                {
                                    Session["IsVerified"] = "True";
                                    Response.StatusCode = 200;
                                    Response.Redirect("/Dashboard.aspx");
                                    //Response.Redirect(Session["ModuleFolder"] + "/" + "Dashboard.aspx");
                                    //Server.Transfer(Session["ModuleFolder"] + "/" + "Dashboard.aspx");
                                }

                                //string ConnectionString = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ConnectionString"].ToString(), true);
                                //using (SqlConnection con = new SqlConnection(ConnectionString))
                                //{
                                //    con.Open();
                                //    var old_database = con.Database;
                                //    var databaseName = Session["ModuleDataBase"].ToString();
                                //    con.ChangeDatabase(databaseName);
                                //    var new_database = con.Database;
                                //    String FilePath = Server.MapPath("Config.txt");
                                //    var configDetail = CryptorEngine.Decrypt(File.ReadAllText(@FilePath), true);
                                //    string[] readConfig = configDetail.Split(';');
                                //    string dataSource = String.Empty, userId = String.Empty, password = String.Empty;
                                //    foreach (string str in readConfig)
                                //    {
                                //        string[] Kvp = str.Split('=');
                                //        if (Kvp[0] == "dataSource")
                                //        {
                                //            dataSource = Kvp[1];
                                //        }
                                //        if (Kvp[0] == "userId")
                                //        {
                                //            userId = Kvp[1];
                                //        }
                                //        if (Kvp[0] == "password")
                                //        {
                                //            password = Kvp[1];
                                //        }
                                //    }
                                //    var newConnectionString = "Data Source=" + dataSource + ";Initial Catalog=" + new_database + ";User ID=" + userId + ";Password=" + password;
                                //    ConfigurationManager.AppSettings["ConnectionString"] = CryptorEngine.Encrypt(newConnectionString, true);
                                //}
                                //Response.Redirect(Session["ModuleFolder"] + "/" + "Dashboard.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){openModal();},1000);", true);
                                sb.Append("<div class='row'>");
                                int count = 0;
                                foreach (UserAccess usr in objResponse.Usr.UAccess)
                                {
                                    if (usr.CompanyId == companyId)
                                    {
                                        if (count == 0)
                                        {
                                            sb.Append("<img style='height:80px; width: 150px; padding-left:20px;padding-right:30px;' src='BoardMeeting/images/CompanyLogo/" + usr.CompanyLogo + "' alt='" + usr.CompanyNm + "'/>");
                                        }
                                        sb.Append("<a runat='server' href=\"javascript:GoToDashBoard('" + companyId + "','" + usr.CompanyNm + "','" + usr.CompanyLogo + "'," + usr.ModuleId + ",'" + usr.ModuleNm + "','" + usr.ModuleFolder + "','" + usr.ModuleDataBase + "', '" + Convert.ToString(login.LoginId) + "','" + usr.Mobile + "')\"><img style='height:126px;padding-right:10px;' src='BoardMeeting/images/CompanyGroupLogo/" + usr.ModuleLogo + "' alt='" + usr.ModuleNm + "' /></a>");
                                        count++;
                                    }
                                }
                                sb.Append("</div>");
                                sb.Append("</br>");
                            }
                        }
                        ShowListing.InnerHtml = sb.ToString();
                        
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){unValidCredential('" + objResponse.Msg + " Salt=PROCS MoreSalt=" + Convert.ToString(Session["moreSalt"]) + "');},1000);", true);
                }
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "Login", "Login", Convert.ToString("superadmin"), Convert.ToInt32(1), 1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){unValidCredential();},1000);", true);
            }

        }

        //public void Login1()

        //{
        //    ProcsDLL.Models.Login.Modal.Login login = new ProcsDLL.Models.Login.Modal.Login();
        //    login.LoginId = UserName.Text;
        //    login.Password = CryptorEngine.Encrypt(Password.Text, true);

        //    LoginRequest objlogin = new LoginRequest(login);

        //    LoginResponse objResponse = objlogin.ValidateUser();
        //    if (objResponse.StatusFl)
        //    {
        //        if (objResponse.Msg == "Success")
        //        {
        //            Session["EmployeeId"] = Convert.ToString(login.LoginId);

        //            //CHECK SESSION FOR USER LOGGED IN
        //            //LoginResponse objResponseSession = objlogin.CheckSession();
        //            //if (!objResponseSession.StatusFl)
        //            //{
        //            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User already logged in!!....');window.location ='Login.aspx';", true);
        //            //    return;
        //            //}
        //            StringBuilder sb = new StringBuilder();
        //            HashSet<Int32> companyIds = new HashSet<Int32>();
        //            foreach (UserAccess usr in objResponse.User.UAccess)
        //            {
        //                companyIds.Add(usr.CompanyId);
        //            }

        //            foreach (Int32 companyId in companyIds)
        //            {

        //                var matchedObj = objResponse.User.UAccess.Where(p => p.CompanyId == companyId).ToList();
        //                if (companyIds.Count == 1 && matchedObj.Count == 1)
        //                {
        //                    Session["CompanyId"] = matchedObj[0].CompanyId;
        //                    Session["CompanyName"] = matchedObj[0].CompanyNm;
        //                    Session["ModuleId"] = matchedObj[0].ModuleId;
        //                    Session["ModuleName"] = matchedObj[0].ModuleNm;
        //                    Session["ModuleFolder"] = matchedObj[0].ModuleFolder;
        //                    Session["ModuleDatabase"] = matchedObj[0].ModuleDataBase;
        //                    Session["UserMobile"] = matchedObj[0].Mobile;
        //                    bool TwoFactorAuth = Convert.ToBoolean(ConfigurationManager.AppSettings["TwoFactorAuthentication"]);
        //                    if (TwoFactorAuth == true)
        //                    {
        //                        SendSMS();
        //                    }
        //                    else
        //                    {
        //                        Session["IsVerified"] = "True";
        //                        Response.StatusCode = 200;
        //                        Response.Redirect(Session["ModuleFolder"] + "/" + "Dashboard.aspx");
        //                        //Server.Transfer(Session["ModuleFolder"] + "/" + "Dashboard.aspx");
        //                    }

        //                    //string ConnectionString = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ConnectionString"].ToString(), true);
        //                    //using (SqlConnection con = new SqlConnection(ConnectionString))
        //                    //{
        //                    //    con.Open();
        //                    //    var old_database = con.Database;
        //                    //    var databaseName = Session["ModuleDataBase"].ToString();
        //                    //    con.ChangeDatabase(databaseName);
        //                    //    var new_database = con.Database;
        //                    //    String FilePath = Server.MapPath("Config.txt");
        //                    //    var configDetail = CryptorEngine.Decrypt(File.ReadAllText(@FilePath), true);
        //                    //    string[] readConfig = configDetail.Split(';');
        //                    //    string dataSource = String.Empty, userId = String.Empty, password = String.Empty;
        //                    //    foreach (string str in readConfig)
        //                    //    {
        //                    //        string[] Kvp = str.Split('=');
        //                    //        if (Kvp[0] == "dataSource")
        //                    //        {
        //                    //            dataSource = Kvp[1];
        //                    //        }
        //                    //        if (Kvp[0] == "userId")
        //                    //        {
        //                    //            userId = Kvp[1];
        //                    //        }
        //                    //        if (Kvp[0] == "password")
        //                    //        {
        //                    //            password = Kvp[1];
        //                    //        }
        //                    //    }
        //                    //    var newConnectionString = "Data Source=" + dataSource + ";Initial Catalog=" + new_database + ";User ID=" + userId + ";Password=" + password;
        //                    //    ConfigurationManager.AppSettings["ConnectionString"] = CryptorEngine.Encrypt(newConnectionString, true);
        //                    //}
        //                    //Response.Redirect(Session["ModuleFolder"] + "/" + "Dashboard.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){openModal();},1000);", true);
        //                    sb.Append("<div class='row'>");
        //                    int count = 0;
        //                    foreach (UserAccess usr in objResponse.User.UAccess)
        //                    {
        //                        if (usr.CompanyId == companyId)
        //                        {
        //                            if (count == 0)
        //                            {
        //                                sb.Append("<img style='height:126px;padding-left:20px;padding-right:30px;' src='assets/logos/Company/" + usr.CompanyLogo + "' alt='" + usr.CompanyNm + "'/>");
        //                            }
        //                            sb.Append("<a runat='server' href=\"javascript:GoToDashBoard('" + companyId + "','" + usr.CompanyNm + "'," + usr.ModuleId + ",'" + usr.ModuleNm + "','" + usr.ModuleFolder + "','" + usr.ModuleDataBase + "', '" + Convert.ToString(login.LoginId) + "','" + usr.Mobile + "')\"><img style='height:126px;padding-right:10px;' src='assets/logos/Module/" + usr.ModuleLogo + "' alt='" + usr.ModuleNm + "' /></a>");
        //                            count++;
        //                        }
        //                    }
        //                    sb.Append("</div>");
        //                    sb.Append("</br>");
        //                }
        //            }
        //            ShowListing.InnerHtml = sb.ToString();

        //        }



        //    }
        //    //else
        //    //{
        //    //    //lbPassInCorrect.Visible = true;
        //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){unValidCredential();},1000);", true);
        //    //}

        //    else
        //    {
        //        //lbPassInCorrect.Visible = true;
        //        UCount++;

        //        if (UCount > 3)
        //        {
        //            // CHECK USER LOGIN ATTEMPT
        //            LoginResponse objResponse1 = objlogin.checkUserAttempt();
        //            if (objResponse1.StatusFl == false)
        //            {

        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){unBlockAttempt();},1000);", true);
        //                return;
        //            }
        //            else
        //            {
        //                objResponse = objlogin.addUserAttempt();
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){unValidCredential();},1000);", true);

        //            }
        //            // END
        //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){unBlockAttempt();},1000);", true);
        //        }
        //        else
        //        {

        //            objResponse = objlogin.addUserAttempt();
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "setTimeout(function(){unValidCredential();},1000);", true);
        //        }
        //    }

        //}
    }
}