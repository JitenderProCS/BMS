using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Response;
using BMS_New.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BMS_New.Models.BMS.Repository
{
    public class AdminUserRepository : IRequiresSessionState
    {
        private AdminUserResponse _userResponse;
        private string connectionString = SQLHelper.GetConnString();

        

        /****Add By Jitender******/
        public AdminUserResponse AddUser(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@USER_EMAIL", objUser.emailId));
                        cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objUser.LoginId));
                        cmd.Parameters.Add(new SqlParameter("@USER_AUTHENTICATION", objUser.authentication));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                        cmd.ExecuteNonQuery();
                        Int32 obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (obj == 0)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@USER_NM", objUser.userName));
                            cmd.Parameters.Add(new SqlParameter("@USER_EMAIL", objUser.emailId));
                            //cmd.Parameters.Add(new SqlParameter("@USER_SALUTATION", objUser.salutation));
                            cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objUser.LoginId));
                            cmd.Parameters.Add(new SqlParameter("@USER_MOBILE", objUser.phone));
                            cmd.Parameters.Add(new SqlParameter("@USER_AUTHENTICATION", objUser.authentication));
                            cmd.Parameters.Add(new SqlParameter("@CREATE_BY", objUser.CREATED_BY));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@STATUS", "Active"));
                            cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                            objUser.ID = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);

                            /*********Add By Jitender************/
                            DataTable dtCompanyMapping = new DataTable();
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE_COMP_MAP", "COMPANY_MAPPING_INSERT"));
                            {

                                dtCompanyMapping.Columns.Add("companyId", typeof(int));
                                dtCompanyMapping.Columns.Add("CompanyName", typeof(string));
                                dtCompanyMapping.Columns.Add("moduleId", typeof(int));
                                dtCompanyMapping.Columns.Add("moduleName", typeof(string));
                                dtCompanyMapping.Columns.Add("Role_Admin", typeof(string));
                                foreach (CompanyAccess Cmap in objUser.CompanyMapping)
                                {
                                    DataRow dr = dtCompanyMapping.NewRow();
                                    dr["companyId"] = Cmap.CompanyId;
                                    dr["CompanyName"] = Cmap.CompanyName;
                                    dr["moduleId"] = Cmap.moduleId;
                                    dr["moduleName"] = Cmap.moduleName;
                                    dr["Role_Admin"] = Cmap.Role_Admin;
                                    dtCompanyMapping.Rows.Add(dr);
                                }
                            }
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_MAPPING", dtCompanyMapping));
                            cmd.ExecuteNonQuery();
                            /***************End*****************/
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "User has been saved successfully !";
                            _userResponse.User = objUser;
                        }
                        else
                        {
                            _userResponse.StatusFl = false;
                            _userResponse.Msg = "User with same email id already exist for Company !";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            }
            return _userResponse;
        }
        public AdminUserResponse GetUserList(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_User_List"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        //cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objUser.LoginId));
                       // cmd.Parameters.Add(new SqlParameter("@USER_AUTHENTICATION", (objUser.authentication == "0" ? objUser.authentication : null)));
                        DataSet ds = new DataSet();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds);
                        }
                        DataTable dt = ds.Tables[0];
                        DataTable dtCompMap = ds.Tables[1];
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                List<AdminUser> lstuser = new List<AdminUser>();
                                foreach (DataRow dr in dt.Rows)
                                {
                                    AdminUser o = new AdminUser();
                                    o.ID = Convert.ToInt32(dr["ID"]);
                                    o.userName = Convert.ToString(dr["USER_NM"]);
                                    o.emailId = Convert.ToString(dr["USER_EMAIL"]);
                                    o.phone = Convert.ToString(dr["USER_MOBILE"]);
                                    o.LoginId = Convert.ToString(dr["LOGIN_ID"]);
                                    o.authentication = Convert.ToString(dr["USER_AUTHENTICATION"]);




                                    if (dtCompMap.Rows.Count > 0)
                                    {

                                        List<CompanyAccess> CompanyMapping = new List<CompanyAccess>();
                                        string userLoginValue = dr["LOGIN_ID"].ToString();
                                        DataRow[] drKeywords = dtCompMap.Select("LOGIN_ID = '" + userLoginValue + "'");
                                        foreach (DataRow item in drKeywords)
                                        {
                                            CompanyAccess obj = new CompanyAccess();
                                            obj.ID = Convert.ToInt32(item["ID"]);
                                            obj.LoginId = Convert.ToString(item["LOGIN_ID"]);
                                            obj.CompanyId = Convert.ToInt32(item["COMPANY_ID"]);
                                            obj.CompanyName = Convert.ToString(item["COMPANY_NM"]);
                                            obj.moduleId = Convert.ToInt32(item["MODULE_ID"]);
                                            obj.moduleName = Convert.ToString(item["MODULE_NM"]);
                                            obj.Role_Admin = Convert.ToString(item["ROLE_ADMIN"]);
                                            CompanyMapping.Add(obj);
                                        }
                                        o.CompanyMapping = CompanyMapping;
                                    }
                                    lstuser.Add(o);

                                }

                                _userResponse.UserList = lstuser;
                                _userResponse.StatusFl = true;
                                _userResponse.Msg = "Success";
                            }
                        }
                        else
                        {
                            _userResponse.StatusFl = false;
                            _userResponse.Msg = "No data found !";
                        }
                        return _userResponse;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public AdminUserResponse UpdateUser(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@USER_EMAIL", objUser.emailId));
                        cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objUser.LoginId));
                        cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                        cmd.ExecuteNonQuery();
                        Int32 obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (obj == 1)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                            //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@USER_NM", objUser.userName));
                            cmd.Parameters.Add(new SqlParameter("@USER_EMAIL", objUser.emailId));
                            //cmd.Parameters.Add(new SqlParameter("@USER_SALUTATION", objUser.salutation));
                            cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objUser.LoginId));
                            cmd.Parameters.Add(new SqlParameter("@USER_MOBILE", objUser.phone));
                            cmd.Parameters.Add(new SqlParameter("@USER_AUTHENTICATION", objUser.authentication));
                            cmd.Parameters.Add(new SqlParameter("@CREATE_BY", objUser.CREATED_BY));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@STATUS", "Active"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE_COMP_MAP", "COMPANY_MAPPING_UPDATE"));
                            {
                                DataTable dtCompanyMapping = new DataTable();
                                dtCompanyMapping.Columns.Add("companyId", typeof(int));
                                dtCompanyMapping.Columns.Add("CompanyName", typeof(string));
                                dtCompanyMapping.Columns.Add("moduleId", typeof(int));
                                dtCompanyMapping.Columns.Add("moduleName", typeof(string));
                                dtCompanyMapping.Columns.Add("Role_Admin", typeof(string));
                                foreach (CompanyAccess Cmap in objUser.CompanyMapping)
                                {
                                    DataRow dr = dtCompanyMapping.NewRow();
                                    dr["companyId"] = Cmap.CompanyId;
                                    dr["CompanyName"] = Cmap.CompanyName;
                                    dr["moduleId"] = Cmap.moduleId;
                                    dr["moduleName"] = Cmap.moduleName;
                                    dr["Role_Admin"] = Cmap.Role_Admin;
                                    dtCompanyMapping.Rows.Add(dr);
                                }
                                cmd.Parameters.Add(new SqlParameter("@COMPANY_MAPPING", dtCompanyMapping));
                            }
                            cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                            cmd.ExecuteNonQuery();

                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "User has been updated successfully !";
                            _userResponse.User = objUser;
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }
        /**********End***********/

        public AdminUserResponse DeleteUser(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "DELETE_USER"));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                        cmd.ExecuteNonQuery();
                        _userResponse.StatusFl = true;
                        _userResponse.Msg = "User has been deleted successfully !";
                        _userResponse.User = objUser;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public AdminUserResponse GetModuleList(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_MODULE_SETUP", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_MODULE_List"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                        //cmd.Parameters.Add(new SqlParameter("@USER_AUTHENTICATION", (objUser.authentication == "0" ? objUser.authentication : null)));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                AdminUser obj = new AdminUser();
                                obj.moduleId = Convert.ToInt32(rdr["MODULE_ID"]);
                                obj.moduleName = (!String.IsNullOrEmpty(Convert.ToString(rdr["MODULE_NM"]))) ? Convert.ToString(rdr["MODULE_NM"]) : String.Empty;


                                _userResponse.AddObject(obj);
                            }
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }


        public AdminUserResponse GetAllUsersRole(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "Get_All_Users_Role"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                AdminUser obj = new AdminUser();
                                //obj.ID = Convert.ToInt32(rdr.GetValue(0));
                                //obj.role = new Role
                                //{
                                //    Id = Convert.ToInt32(rdr.GetValue(0)),
                                //    role = Convert.ToString(rdr.GetValue(1))
                                //};
                                //obj.ROLE_NAME = Convert.ToString(rdr.GetValue(1));
                                _userResponse.AddObject(obj);
                            }
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public AdminUserResponse GetEmailList(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_EMAIL_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@term", objUser.emailId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                AdminUser obj = new AdminUser();
                                obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty;
                                _userResponse.AddObject(obj);
                            }
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been fetched successfully !";

                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public AdminUserResponse GetUserDetails(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_DETAILS"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objUser.LoginId));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                AdminUser obj = new AdminUser();
                                obj.userName = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["USER_NM"])) ? Convert.ToString(dt.Rows[0]["USER_NM"]) : String.Empty;
                                //obj.CompanyName = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["COMPANY_NM"])) ? Convert.ToString(dt.Rows[0]["COMPANY_NM"]) : String.Empty;
                                obj.emailId = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["USER_EMAIL"])) ? Convert.ToString(dt.Rows[0]["USER_EMAIL"]) : String.Empty;
                                obj.phone = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["USER_MOBILE"])) ? Convert.ToString(dt.Rows[0]["USER_MOBILE"]) : String.Empty;
                                _userResponse.User = obj;
                                _userResponse.StatusFl = true;
                                _userResponse.Msg = "Data has been fetched successfully !";
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }


        public AdminUserResponse GetUserNameByLoginId(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    //using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER", conn))
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_NAME_BY_LOGIN"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.LoginId));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                AdminUser obj = new AdminUser();
                                obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty;
                                _userResponse.User = obj;
                            }
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public AdminUserResponse GetUserEmailById(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    //using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER", conn))
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_EMAIL_BY_ID"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                AdminUser obj = new AdminUser();
                                obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty;
                                _userResponse.User = obj;
                            }
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public AdminUserResponse GetUsersForCommitteeSuperAdmin(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_FOR_COMMITTEE_SUPER_ADMIN"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
                        cmd.Parameters.Add(new SqlParameter("@NAME", objUser.userName));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                AdminUser obj = new AdminUser();
                                obj.ID = Convert.ToInt32(rdr["ID"]);
                                obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["NAME"]))) ? Convert.ToString(rdr["NAME"]) : String.Empty;
                                obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["EMAIL_ID"]))) ? Convert.ToString(rdr["EMAIL_ID"]) : String.Empty;
                                _userResponse.AddObject(obj);
                            }
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public AdminUserResponse FillUserDetails(AdminUser objUser)
        {
            _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "FILL_USER_AUTOCOMPLETE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@EMAIL_ID", objUser.emailId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            _userResponse.User = new AdminUser();
                            while (rdr.Read())
                            {
                                _userResponse.User.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty;
                                _userResponse.User.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty;
                                _userResponse.User.LoginId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_LOGIN"]))) ? Convert.ToString(rdr["USER_LOGIN"]) : String.Empty;
                                //_userResponse.User.password = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_PWD"]))) ? CryptorEngine.Decrypt(Convert.ToString(rdr["USER_PWD"]), true) : String.Empty;
                                //_userResponse.User.role = new Role
                                //{
                                //    Id = Convert.ToInt32(rdr["ROLE_ID"]),
                                //    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE_NAME"]))) ? Convert.ToString(rdr["ROLE_NAME"]) : String.Empty
                                //};
                                _userResponse.User.authentication = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_AUTHENTICATION"]))) ? Convert.ToString(rdr["USER_AUTHENTICATION"]) : String.Empty;
                            }
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }
        /*********Add By Jitender**********/
        public AdminUserResponse GetUserCompanyList(AdminUser objUser)
        {
            AdminUserResponse _userResponse = new AdminUserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_USER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_COMPANY_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objUser.LoginId));

                        // Remove the SqlDataAdapter, as it's not needed
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                List<CompanyAccess> CompanyMapping = new List<CompanyAccess>();

                                while (reader.Read())
                                {
                                    CompanyAccess Cmap = new CompanyAccess();
                                    Cmap.CompanyId = Convert.ToInt32( reader["COMPANY_ID"]);
                                    Cmap.CompanyCode = reader["COMPANY_CODE"].ToString();
                                    Cmap.CompanyName = reader["COMPANY_NM"].ToString();
                                    Cmap.LoginId = reader["LOGIN_ID"].ToString();
                                    Cmap.ModuleDataBase = reader["BMS_DB_NAME"].ToString();
                                    Cmap.modulefolder = reader["MODULE_FOLDER"].ToString();
                                    Cmap.moduleName = reader["MODULE_NM"].ToString();
                                    Cmap.moduleId = Convert.ToInt32(reader["MODULE_ID"]);
                                    Cmap.Mobile = reader["USER_MOBILE"].ToString();
                                    Cmap.logo = reader["LOGO"].ToString();
                                    // Populate other properties if needed
                                    CompanyMapping.Add(Cmap);
                                }

                                objUser.CompanyMapping = CompanyMapping;
                                _userResponse.User = objUser;
                                _userResponse.StatusFl = true;
                                _userResponse.Msg = "Data has been fetched successfully!";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _userResponse = new AdminUserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        /*************End**********/
        #region "Date Conversion"

        private DateTime ConvertDate(String date)
        {
            String str = String.Empty;
            try
            {
                if (date.Contains("/"))
                {
                    str = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
                }
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }

            return Convert.ToDateTime(str);
        }

        #endregion

    }
}