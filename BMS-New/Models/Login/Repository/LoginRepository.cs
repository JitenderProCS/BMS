using BMS_New.Models.Infrastructure;
using BMS_New.Models.Login.Service.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BMS_New.Models.Login.Modal;

namespace BMS_New.Models.Login.Repository
{
    public class LoginRepository
    {
        //private static String connectionString = SQLHelper.GetConnString();
        // private static String dataBaseName = SQLHelper.GetDBName();

        //public LoginResponse ValidateUser(BMS_New.Models.Login.Model.Login objUsr)
        //{
        //    LoginResponse oRes = new LoginResponse();
        //    try
        //    {
        //        string sConStr = CryptoEngine.Decrypt(Convert.ToString(ConfigurationManager.AppSettings["ConnectionString"]), true);
        //        using (SqlConnection sCon = new SqlConnection(sConStr))
        //        {
        //            sCon.Open();
        //            using (SqlCommand cmd = new SqlCommand("SP_BMS_USER_OPERATION", sCon))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.AddWithValue("@LoginId", objUsr.LoginId);
        //                //cmd.Parameters.AddWithValue("@Password", objUsr.Password);
        //                cmd.Parameters.AddWithValue("@Mode", "ValidateUser");
        //                DataTable dtCnt = new DataTable();
        //                SqlDataAdapter daCnt = new SqlDataAdapter(cmd);
        //                daCnt.Fill(dtCnt);

        //                if (dtCnt.Rows.Count > 0)
        //                {
        //                    string salt = Convert.ToString(HttpContext.Current.Session["salt"]);
        //                    string moreSalts = Convert.ToString(HttpContext.Current.Session["moreSalt"]);
        //                    var dbPassword = Convert.ToString(dtCnt.Rows[0]["USER_PWD"]);

        //                    var hash = hashcodegenerate.GetSHA512(hashcodegenerate.GetSHA512(dbPassword + salt) + salt);
        //                    var fff = hashcodegenerate.GetSHA512(hash + moreSalts);

        //                    if (fff == objUsr.Password)
        //                    {
        //                       // objUsr.DepartmentId = Convert.ToInt32(dtCnt.Rows[0]["DEPARTMENT_ID"]);
        //                        //objUsr.DepartmentNm = Convert.ToString(dtCnt.Rows[0]["DEPARTMENT_NM"]);
        //                        //objUsr.DepartmentId = Convert.ToInt32(dtCnt.Rows[0]["DESIGNATION_ID"]);
        //                        //objUsr.DesignationNm = Convert.ToString(dtCnt.Rows[0]["DESIGNATION_NM"]);
        //                        objUsr.Email = Convert.ToString(dtCnt.Rows[0]["USER_EMAIL"]);
        //                        objUsr.Mobile = Convert.ToString(dtCnt.Rows[0]["USER_MOBILE"]);
        //                        //objUsr.RoleId = Convert.ToInt32(dtCnt.Rows[0]["ROLE_ID"]);
        //                       // objUsr.RoleNm = Convert.ToString(dtCnt.Rows[0]["ROLE_NM"]);
        //                        objUsr.UserName = Convert.ToString(dtCnt.Rows[0]["USER_NM"]);
        //                        objUsr.ModuleDataBase = Convert.ToString(dtCnt.Rows[0]["DATABASE_NAME"]);

        //                        oRes.Msg = "Success";
        //                        oRes.StatusFl = true;
        //                        oRes.Usr = objUsr;
        //                    }
        //                    else
        //                    {
        //                        oRes.Msg = "No Data Found";
        //                        oRes.StatusFl = false;
        //                    }
        //                }
        //                else
        //                {
        //                    oRes.Msg = "No Data Found";
        //                    oRes.StatusFl = false;
        //                }
        //            }
        //            sCon.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oRes.Msg = "Processing failed because of system error !";
        //        oRes.StatusFl = false;
        //    }
        //    return oRes;
        //}


        /***Add By Jitender************/
        public LoginResponse ValidateUser(BMS_New.Models.Login.Model.Login objUsr)
        {
            LoginResponse oRes = new LoginResponse();
            try
            {
                string sConStr = CryptoEngine.Decrypt(ConfigurationManager.AppSettings["ConnectionString"], true);

                using (SqlConnection sCon = new SqlConnection(sConStr))
                {
                    sCon.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_BMS_USER_OPERATION", sCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@LoginId", objUsr.LoginId);
                        cmd.Parameters.AddWithValue("@Mode", "ValidateUser");

                        DataTable dtCnt = new DataTable();
                        SqlDataAdapter daCnt = new SqlDataAdapter(cmd);
                        daCnt.Fill(dtCnt);



                        string salt = Convert.ToString(HttpContext.Current.Session["salt"]);
                        string moreSalts = Convert.ToString(HttpContext.Current.Session["moreSalt"]);
                        var dbPassword = Convert.ToString(dtCnt.Rows[0]["USER_PWD"]);
                        var hash = hashcodegenerate.GetSHA512(hashcodegenerate.GetSHA512(dbPassword + salt) + salt);
                        var fff = hashcodegenerate.GetSHA512(hash + moreSalts);

                        if (Convert.ToString(dtCnt.Rows[0]["USER_PWD"]) == CryptoEngine.Encrypt(objUsr.Password, true))
                        {
                            if (dtCnt.Rows.Count > 0 && Convert.ToInt32(dtCnt.Rows[0][0]) > 0)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@LoginId", objUsr.LoginId);
                                cmd.Parameters.AddWithValue("@Mode", "ACCESS");
                                DataTable dtAccess = new DataTable();
                                SqlDataAdapter daAccess = new SqlDataAdapter(cmd);
                                daAccess.Fill(dtAccess);

                                if (dtAccess.Rows.Count > 0)
                                {
                                    List<UserAccess> lstAccess = new List<UserAccess>();

                                    foreach (DataRow drAccess in dtAccess.Rows)
                                    {
                                        UserAccess obj = new UserAccess();
                                        obj.CompanyId = Convert.ToInt32(drAccess["COMPANY_ID"]);
                                        obj.CompanyLogo = Convert.ToString(drAccess["COMPANY_LOGO"]);
                                        obj.CompanyNm = Convert.ToString(drAccess["COMPANY_NM"]);
                                        obj.GroupId = Convert.ToInt32(drAccess["GROUP_ID"]);
                                        obj.GroupLogo = Convert.ToString(drAccess["GROUP_LOGO"]);
                                        obj.GroupNm = Convert.ToString(drAccess["GROUP_NM"]);
                                        obj.ModuleId = Convert.ToInt32(drAccess["MODULE_ID"]);
                                        obj.ModuleLogo = Convert.ToString(drAccess["MODULE_LOGO"]);
                                        obj.ModuleNm = Convert.ToString(drAccess["MODULE_NM"]);
                                        obj.ModuleFolder = Convert.ToString(drAccess["MODULE_FOLDER"]);
                                        obj.ModuleDataBase = Convert.ToString(drAccess["DATABASE_NAME"]);
                                        obj.Mobile = Convert.ToString(drAccess["USER_MOBILE"]);
                                        lstAccess.Add(obj);
                                    }

                                    objUsr.UAccess = lstAccess;
                                    oRes.Msg = "Success";
                                    oRes.StatusFl = true;
                                    oRes.Usr = objUsr;
                                }
                                else
                                {
                                    oRes.Msg = "No Data Found";
                                    oRes.StatusFl = false;
                                }
                            }
                            else
                            {
                                oRes.Msg = "No Data Found";
                                oRes.StatusFl = false;
                            }
                        }
                        else
                        {
                            oRes.Msg = "User not validate";
                            oRes.StatusFl = false;

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                oRes.Msg = "Processing failed because of a system error!";
                oRes.StatusFl = false;
            }
            return oRes;
        }

        //public LoginResponse ValidateUser(BMS_New.Models.Login.Model.Login objUsr)
        //{
        //    LoginResponse oRes = new LoginResponse();
        //    try
        //    {
        //        string sConStr = CryptoEngine.Decrypt(Convert.ToString(ConfigurationManager.AppSettings["ConnectionString"]), true);
        //        using (SqlConnection sCon = new SqlConnection(sConStr))
        //        {
        //            sCon.Open();
        //            using (SqlCommand cmd = new SqlCommand("SP_BMS_USER_OPERATION", sCon))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.AddWithValue("@LoginId", objUsr.LoginId);
        //                //cmd.Parameters.AddWithValue("@UserPwd", objUsr.Password);
        //                cmd.Parameters.AddWithValue("@Mode", "ValidateUser");

        //                DataTable dtCnt = new DataTable();
        //                SqlDataAdapter daCnt = new SqlDataAdapter(cmd);
        //                daCnt.Fill(dtCnt);
        //                if (dtCnt.Rows.Count > 0)
        //                {
        //                    if (dtCnt.Rows.Count > 0 && Convert.ToInt32(dtCnt.Rows[0][0]) > 0)
        //                    {
        //                        cmd.CommandType = CommandType.StoredProcedure;
        //                        cmd.CommandTimeout = 0;
        //                        cmd.Parameters.Clear();
        //                        cmd.Parameters.AddWithValue("@LoginId", objUsr.LoginId);
        //                        //cmd.Parameters.AddWithValue("@Password", objUsr.Password);
        //                        cmd.Parameters.AddWithValue("@Mode", "ACCESS");
        //                        DataTable dtAccess = new DataTable();
        //                        SqlDataAdapter daAccess = new SqlDataAdapter(cmd);
        //                        daAccess.Fill(dtAccess);

        //                        if (dtAccess.Rows.Count > 0)
        //                        {
        //                            List<UserAccess> lstAccess = new List<UserAccess>();

        //                            foreach (DataRow drAccess in dtAccess.Rows)
        //                            {
        //                                UserAccess obj = new UserAccess();
        //                                obj.CompanyId = Convert.ToInt32(drAccess["COMPANY_ID"]);
        //                                obj.CompanyLogo = Convert.ToString(drAccess["COMPANY_LOGO"]);
        //                                obj.CompanyNm = Convert.ToString(drAccess["COMPANY_NM"]);
        //                                obj.GroupId = Convert.ToInt32(drAccess["GROUP_ID"]);
        //                                obj.GroupLogo = Convert.ToString(drAccess["GROUP_LOGO"]);
        //                                obj.GroupNm = Convert.ToString(drAccess["GROUP_NM"]);
        //                                obj.ModuleId = Convert.ToInt32(drAccess["MODULE_ID"]);
        //                                obj.ModuleLogo = Convert.ToString(drAccess["MODULE_LOGO"]);
        //                                obj.ModuleNm = Convert.ToString(drAccess["MODULE_NM"]);
        //                                obj.ModuleFolder = Convert.ToString(drAccess["MODULE_FOLDER"]);
        //                                obj.ModuleDataBase = Convert.ToString(drAccess["DATABASE_NAME"]);
        //                                obj.Mobile = Convert.ToString(drAccess["USER_MOBILE"]);
        //                                lstAccess.Add(obj);
        //                            }
        //                            objUsr.UAccess = lstAccess;
        //                            oRes.Msg = "Success";
        //                            oRes.StatusFl = true;
        //                            oRes.Usr = objUsr;
        //                        }
        //                        else
        //                        {
        //                            oRes.Msg = "No Data Found";
        //                            oRes.StatusFl = false;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    oRes.Msg = "No Data Found";
        //                    oRes.StatusFl = false;
        //                }
        //            }
        //            sCon.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oRes.Msg = "Processing failed because of system error !";
        //        oRes.StatusFl = false;
        //    }
        //    return oRes;
        //}
        /*************End*****************/

        public LoginResponse ChangePassword(BMS_New.Models.Login.Model.Login objUsr)
        {
             LoginResponse oRes = new LoginResponse();
           //oRes = new LoginResponse();
           // oRes.StatusFl = false;
           // oRes.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                string sConStr = CryptoEngine.Decrypt(ConfigurationManager.AppSettings["ConnectionString"], true);
                using (SqlConnection sCon = new SqlConnection(sConStr))
                {
                    sCon.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_BMS_USER_OPERATION", sCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@LoginId", objUsr.LoginId);
                        cmd.Parameters.Add(new SqlParameter("@UserPwd", CryptoEngine.Encrypt(objUsr.Password, true)));
                        //cmd.Parameters.AddWithValue("@Password", objUsr.Password);
                        cmd.Parameters.AddWithValue("@Mode", "CHANGE_PASSWORD_BY_LOGIN_ID");
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                        cmd.ExecuteNonQuery();
                        sCon.Close();
                       // oRes.StatusFl = true;
                       // oRes.Msg = "Success";
                    }
                    }
                    
                }
            catch (Exception ex)
            {
                oRes.Msg = "Processing failed because of a system error!";
                oRes.StatusFl = false;
                // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, "ChangePassword", "Reset Password Page", 1, 0);
            }
            return oRes;
        }

        #region  "Set Session Status"
        public LoginResponse SetSessionStatus(BMS_New.Models.Login.Model.Login objLogin)
        {
            LoginResponse res = new LoginResponse();

            //res = new LoginResponse();
            //res.Msg = "No Data Found";
            //res.StatusFl = false;
            //try
            //{
            //    using (SqlConnection sCon = new SqlConnection(connectionString))
            //    {
            //        string s = Convert.ToString(System.Web.HttpContext.Current.Session["EmployeeId"]);
            //        sCon.Open();
            //        string query = "update [dbo].[PROCS_SESSION_MAINTAIN] set END_SESSION=GETDATE(),STATUS='CLOSE'   where LOGIN_ID='" + s + "'";
            //        using (SqlCommand sCmd = new SqlCommand(query, sCon))
            //        {
            //            sCmd.ExecuteNonQuery();
            //            sCon.Close();
            //            res.StatusFl = true;
            //            res.Msg = "Success";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    res = new LoginResponse();
            //    res.StatusFl = false;
            //    res.Msg = "Something went wrong. Please try again or Contact Support!";
            //    //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, "SetSessionStatus", "Set Session Status", 0, 0);
            //}
            return res;
        }
        #endregion
    }
}