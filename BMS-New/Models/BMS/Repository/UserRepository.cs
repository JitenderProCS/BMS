
using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Response;
using BMS_New.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Repository
{
    public class UserRepository : IRequiresSessionState
    {
        private UserResponse _userResponse;
        private string connectionString = SQLHelper.GetConnString();

        //SAVE THE NEW USERS OF USER MASTER HERE 9-oct
        public UserResponse AddUser(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@EMAIL_ID", objUser.emailId));
                        cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.userLogin));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
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
                            cmd.Parameters.Add(new SqlParameter("@USER_SALUTATION", objUser.salutation));
                            cmd.Parameters.Add(new SqlParameter("@ROLE", objUser.role.Id));
                            cmd.Parameters.Add(new SqlParameter("@USER_PROFILE", objUser.profile));
                            cmd.Parameters.Add(new SqlParameter("@MOBILE_NO", objUser.phone));
                            cmd.Parameters.Add(new SqlParameter("@USER_FIRST_NAME", objUser.userFirstName));
                            cmd.Parameters.Add(new SqlParameter("@USER_MIDDLE_NAME", objUser.userMiddleName));
                            cmd.Parameters.Add(new SqlParameter("@USER_LAST_NAME", objUser.userLastName));
                            if (!String.IsNullOrEmpty(Convert.ToString(objUser.tenureStartDate)))
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_START", DateTime.Parse(objUser.tenureStartDate)));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_START", null));
                            }
                            if (!String.IsNullOrEmpty(Convert.ToString(objUser.tenureEndDate)))
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_END", DateTime.Parse(objUser.tenureEndDate)));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_END", null));
                            }
                            cmd.Parameters.Add(new SqlParameter("@EMAIL_ID", objUser.emailId));
                            cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.userLogin));
                            cmd.Parameters.Add(new SqlParameter("@STATUS", objUser.status));
                            cmd.Parameters.Add(new SqlParameter("@SHAREHOLDING", objUser.shareHolding));
                            cmd.Parameters.Add(new SqlParameter("@SHAREHOLDING_PERCENTAGE", objUser.shareHolding_percentage));
                            cmd.Parameters.Add(new SqlParameter("@RESOLUTION_OF_LODR", objUser.txtdate));
                            cmd.Parameters.Add(new SqlParameter("@pan_no", objUser.txtdp_pan));
                            cmd.Parameters.Add(new SqlParameter("@pan_remark", objUser.panremark));
                            cmd.Parameters.Add(new SqlParameter("@OCCUPATION_AREA", objUser.occupation_Area));
                            cmd.Parameters.Add(new SqlParameter("@no_of_directorship", objUser.no_of_directorship));
                            cmd.Parameters.Add(new SqlParameter("@no_of_independent", objUser.no_of_independent));
                            cmd.Parameters.Add(new SqlParameter("@no_of_membership", objUser.no_of_membership));
                            cmd.Parameters.Add(new SqlParameter("@no_of_post_of_chairperson", objUser.no_of_post_of_chairperson));
                            cmd.Parameters.Add(new SqlParameter("@NATIONALITY", objUser.nationality));
                            cmd.Parameters.Add(new SqlParameter("@MEMBERSHIP_NUM_SECRETARIAL_USER", objUser.membership_Num_Secretarial_User));
                            cmd.Parameters.Add(new SqlParameter("@GENDER", objUser.gender));
                            cmd.Parameters.Add(new SqlParameter("@EXPERIENCE", objUser.experience));
                            cmd.Parameters.Add(new SqlParameter("@EDUCATIONAL_QUALIFICATION", objUser.educational_Qualification));
                            cmd.Parameters.Add(new SqlParameter("@din_no", objUser.txtdin_pan));
                            cmd.Parameters.Add(new SqlParameter("@din_remark", objUser.din_remark));
                            cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", objUser.department.departmentId));
                            cmd.Parameters.Add(new SqlParameter("@DESIGNATION_ID", objUser.designation.ID));
                            //cmd.Parameters.Add(new SqlParameter("@CATEGORY_ID", objUser.category.ID));
                            cmd.Parameters.Add(new SqlParameter("@DATE_OF_RESOLUTION", objUser.txtdate));
                            if (!String.IsNullOrEmpty(Convert.ToString(objUser.dateOfBirth)))
                            {
                                cmd.Parameters.Add(new SqlParameter("@DATE_OF_BIRTH", DateTime.Parse(objUser.dateOfBirth)));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@DATE_OF_BIRTH", null));
                            }
                            cmd.Parameters.Add(new SqlParameter("@CREATED_BY", objUser.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@APPOINTED_SECTION", objUser.appointed_Section));
                            cmd.Parameters.Add(new SqlParameter("@ADDRESS", objUser.address));
                            cmd.Parameters.Add(new SqlParameter("@AADHAR_NUMBER", objUser.aadhar_Number));
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEES_ALREADY_DIRECTOR", objUser.committees_Already_director));
                            cmd.Parameters.Add(new SqlParameter("@CATEGORY_NAME", objUser.category));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE_COMP", "MULTICOMPANY_INSERT"));
                            {
                                DataTable dt = new DataTable();
                                dt.Columns.Add("OTHER_DIRECTOR_COMPANIES", typeof(string));
                                //DataRow dr = dt.NewRow();
                                foreach (var compname in objUser.multi_Companies)
                                {
                                    DataRow dr = dt.NewRow();
                                    dr["OTHER_DIRECTOR_COMPANIES"] = compname;
                                    //dr["OTHER_DIRECTOR_COMPANIES"] = compname.Companies;
                                    dt.Rows.Add(dr);
                                }
                                cmd.Parameters.Add(new SqlParameter("@OTHER_COMPANIES", dt));
                            }
                            //cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.LoginId));
                            cmd.Parameters.Add(new SqlParameter("@UPLOAD_AVATAR", objUser.uploadAvatar));
                            cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                            cmd.Parameters.Add(new SqlParameter("@MODULE_ID", objUser.moduleId));
                             cmd.ExecuteNonQuery();
                            objUser.ID = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        //UPDATE EXISTING USER OF USER MASTER HERE
        public UserResponse UpdateUser(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@EMAIL_ID", objUser.emailId));
                        cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.userLogin));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        cmd.ExecuteNonQuery();
                        Int32 obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (obj == 1)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@USER_SALUTATION", objUser.salutation));
                            cmd.Parameters.Add(new SqlParameter("@ROLE", objUser.role.Id));
                            cmd.Parameters.Add(new SqlParameter("@USER_PROFILE", objUser.profile));
                            cmd.Parameters.Add(new SqlParameter("@MOBILE_NO", objUser.phone));
                            cmd.Parameters.Add(new SqlParameter("@USER_FIRST_NAME", objUser.userFirstName));
                            cmd.Parameters.Add(new SqlParameter("@USER_MIDDLE_NAME", objUser.userMiddleName));
                            cmd.Parameters.Add(new SqlParameter("@USER_LAST_NAME", objUser.userLastName));
                            if (!String.IsNullOrEmpty(Convert.ToString(objUser.tenureStartDate)))
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_START", DateTime.Parse(objUser.tenureStartDate)));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_START", null));
                            }
                            if (!String.IsNullOrEmpty(Convert.ToString(objUser.tenureEndDate)))
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_END", DateTime.Parse(objUser.tenureEndDate)));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@TENURE_END", null));
                            }
                            cmd.Parameters.Add(new SqlParameter("@EMAIL_ID", objUser.emailId));
                            cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.userLogin));
                            cmd.Parameters.Add(new SqlParameter("@STATUS", objUser.status));
                            cmd.Parameters.Add(new SqlParameter("@SHAREHOLDING", objUser.shareHolding));
                            cmd.Parameters.Add(new SqlParameter("@SHAREHOLDING_PERCENTAGE", objUser.shareHolding_percentage));
                            cmd.Parameters.Add(new SqlParameter("@RESOLUTION_OF_LODR", objUser.txtdate));
                            cmd.Parameters.Add(new SqlParameter("@pan_no", objUser.txtdp_pan));
                            cmd.Parameters.Add(new SqlParameter("@pan_remark", objUser.panremark));
                            cmd.Parameters.Add(new SqlParameter("@OCCUPATION_AREA", objUser.occupation_Area));
                            cmd.Parameters.Add(new SqlParameter("@no_of_directorship", objUser.no_of_directorship));
                            cmd.Parameters.Add(new SqlParameter("@no_of_independent", objUser.no_of_independent));
                            cmd.Parameters.Add(new SqlParameter("@no_of_membership", objUser.no_of_membership));
                            cmd.Parameters.Add(new SqlParameter("@no_of_post_of_chairperson", objUser.no_of_post_of_chairperson));
                            cmd.Parameters.Add(new SqlParameter("@NATIONALITY", objUser.nationality));
                            cmd.Parameters.Add(new SqlParameter("@GENDER", objUser.gender));
                            cmd.Parameters.Add(new SqlParameter("@EXPERIENCE", objUser.experience));
                            cmd.Parameters.Add(new SqlParameter("@EDUCATIONAL_QUALIFICATION", objUser.educational_Qualification));
                            cmd.Parameters.Add(new SqlParameter("@din_no", objUser.txtdin_pan));
                            cmd.Parameters.Add(new SqlParameter("@din_remark", objUser.din_remark));
                            cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", objUser.department.departmentId));
                            cmd.Parameters.Add(new SqlParameter("@DESIGNATION_ID", objUser.designation.ID));
                            //cmd.Parameters.Add(new SqlParameter("@CATEGORY_ID", objUser.category.ID));
                            cmd.Parameters.Add(new SqlParameter("@DATE_OF_RESOLUTION", objUser.txtdate));
                            if (!String.IsNullOrEmpty(Convert.ToString(objUser.dateOfBirth)))
                            {
                                cmd.Parameters.Add(new SqlParameter("@DATE_OF_BIRTH", DateTime.Parse(objUser.dateOfBirth)));
                            }
                            else
                            {
                                cmd.Parameters.Add(new SqlParameter("@DATE_OF_BIRTH", null));
                            }
                            cmd.Parameters.Add(new SqlParameter("@CREATED_BY", objUser.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@APPOINTED_SECTION", objUser.appointed_Section));
                            cmd.Parameters.Add(new SqlParameter("@ADDRESS", objUser.address));
                            cmd.Parameters.Add(new SqlParameter("@AADHAR_NUMBER", objUser.aadhar_Number));
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEES_ALREADY_DIRECTOR", objUser.committees_Already_director));
                            cmd.Parameters.Add(new SqlParameter("@CATEGORY_NAME", objUser.category));

                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE_COMP", "MULTICOMPANY_UPDATE"));
                            {
                                DataTable dt = new DataTable();
                                dt.Columns.Add("OTHER_DIRECTOR_COMPANIES", typeof(string));
                                //DataRow dr = dt.NewRow();
                                foreach (var compname in objUser.multi_Companies)
                                {
                                    DataRow dr = dt.NewRow();
                                    dr["OTHER_DIRECTOR_COMPANIES"] = compname;
                                    //dr["OTHER_DIRECTOR_COMPANIES"] = compname.Companies;
                                    dt.Rows.Add(dr);
                                }
                                cmd.Parameters.Add(new SqlParameter("@OTHER_COMPANIES", dt));
                            }
                            cmd.Parameters.Add(new SqlParameter("@MEMBERSHIP_NUM_SECRETARIAL_USER", objUser.membership_Num_Secretarial_User));

                            //add parameter for director close

                          
                            //cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.LoginId));
                           // cmd.Parameters.Add(new SqlParameter("@PASSWORD", CryptoEngine.Encrypt(objUser.password, true)));
                            cmd.Parameters.Add(new SqlParameter("@UPLOAD_AVATAR", objUser.uploadAvatar));
                            //cmd.Parameters.Add(new SqlParameter("@CATEGORY_ID", objUser.category.ID));
                            cmd.Parameters.Add(new SqlParameter("@MODIFIED_BY", objUser.createdBy));
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public UserResponse DeleteUser(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "DELETE_USER"));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public UserResponse GetUserList(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        //cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.LoginId));
                        //cmd.Parameters.Add(new SqlParameter("@STATUS", (objUser.status != "0" ? objUser.status : null)));
                        DataSet ds = new DataSet();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds);
                        }
                        DataTable dt = ds.Tables[0];
                        DataTable dtCompaniesList = ds.Tables[1];
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                List<User> lstuser = new List<User>();
                                foreach (DataRow dr in dt.Rows)
                                {
                                    User obj = new User();
                                    obj.ID = Convert.ToInt32(dr["ID"]);
                                    obj.salutation = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_SALUTATION"]))) ? Convert.ToString(dr["USER_SALUTATION"]) : String.Empty;
                                    obj.userFirstName = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_FIRST_NAME"]))) ? Convert.ToString(dr["USER_FIRST_NAME"]) : String.Empty;
                                    obj.userMiddleName = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_MIDDLE_NAME"]))) ? Convert.ToString(dr["USER_MIDDLE_NAME"]) : String.Empty;
                                    obj.userLastName = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_LAST_NAME"]))) ? Convert.ToString(dr["USER_LAST_NAME"]) : String.Empty;
                                    obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_EMAIL"]))) ? Convert.ToString(dr["USER_EMAIL"]) : String.Empty;
                                    obj.role = new Role
                                    {
                                        Id = Convert.ToInt32(dr["USER_ROLE"]),
                                        role = (!String.IsNullOrEmpty(Convert.ToString(dr["ROLE"]))) ? Convert.ToString(dr["ROLE"]) : String.Empty
                                    };
                                   // obj.role = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_ROLE1"]))) ? Convert.ToString(dr["USER_ROLE1"]) : String.Empty;
                                    obj.phone = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_MOBILE"]))) ? Convert.ToString(dr["USER_MOBILE"]) : String.Empty;
                                    obj.address = (!String.IsNullOrEmpty(Convert.ToString(dr["ADDRESS"]))) ? Convert.ToString(dr["ADDRESS"]) : String.Empty;
                                    //obj.designation = (!String.IsNullOrEmpty(Convert.ToString(dr["DESIGNATION_NAME"]))) ? Convert.ToString(dr["DESIGNATION_NAME"]) : String.Empty;
                                    //obj.department = (!String.IsNullOrEmpty(Convert.ToString(dr["DEPARTMENT_NAME"]))) ? Convert.ToString(dr["DEPARTMENT_NAME"]) : String.Empty;
                                    obj.department = new Department
                                    {
                                        departmentId = Convert.ToInt32(dr["DEPARTMENT_ID"]),
                                        departmentName = (!String.IsNullOrEmpty(Convert.ToString(dr["DEPARTMENT_NM"]))) ? Convert.ToString(dr["DEPARTMENT_NM"]) : String.Empty
                                    };
                                    obj.designation = new Designation
                                    {
                                        ID = Convert.ToInt32(dr["DESIGNATION_ID"]),
                                        designationName = (!String.IsNullOrEmpty(Convert.ToString(dr["DESIGNATION_NAME"]))) ? Convert.ToString(dr["DESIGNATION_NAME"]) : String.Empty
                                    };
                                    obj.category = (!String.IsNullOrEmpty(Convert.ToString(dr["CATEGORY_NM"]))) ? Convert.ToString(dr["CATEGORY_NM"]) : String.Empty;
                                    //obj.tenureStartDate = (!String.IsNullOrEmpty(Convert.ToString(dr["TENURE_START"]))) ? Convert.ToString(dr["TENURE_START"]) : String.Empty;
                                    //obj.tenureEndDate = (!String.IsNullOrEmpty(Convert.ToString(dr["TENURE_END"]))) ? Convert.ToString(dr["TENURE_END"]) : String.Empty;
                                    //obj.dateOfBirth = (!String.IsNullOrEmpty(Convert.ToString(dr["DATE_OF_BIRTH"]))) ? Convert.ToString(dr["DATE_OF_BIRTH"]) : String.Empty;
                                    obj.tenureStartDate = (!String.IsNullOrEmpty(Convert.ToString(dr["TENURE_START"]))) ? Convert.ToString(dr["TENURE_START"]) : String.Empty;
                                    obj.tenureEndDate = (!String.IsNullOrEmpty(Convert.ToString(dr["TENURE_END"]))) ? Convert.ToString(dr["TENURE_END"]) : String.Empty;
                                    obj.dateOfBirth = (!String.IsNullOrEmpty(Convert.ToString(dr["DATE_OF_BIRTH"]))) ? Convert.ToString(dr["DATE_OF_BIRTH"]) : String.Empty;
                                    obj.nationality = (!String.IsNullOrEmpty(Convert.ToString(dr["NATIONALITY"]))) ? Convert.ToString(dr["NATIONALITY"]) : String.Empty;
                                    obj.userLogin = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_LOGIN"]))) ? Convert.ToString(dr["USER_LOGIN"]) : String.Empty;
                                    //obj.password = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_PWD"]))) ? Convert.ToString(dr["USER_PWD"]) : String.Empty;
                                    obj.password = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_PWD"]))) ? CryptoEngine.Decrypt(Convert.ToString(dr["USER_PWD"]), true) : String.Empty;
                                    obj.status = (!String.IsNullOrEmpty(Convert.ToString(dr["STATUS"]))) ? Convert.ToString(dr["STATUS"]) : String.Empty;
                                    obj.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(dr["UPLOAD_AVATAR"]))) ? Convert.ToString(dr["UPLOAD_AVATAR"]) : String.Empty;
                                    obj.profile = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_PROFILE"]))) ? Convert.ToString(dr["USER_PROFILE"]) : String.Empty;
                                    obj.txtdp_pan = (!String.IsNullOrEmpty(Convert.ToString(dr["pan_no"]))) ? Convert.ToString(dr["pan_no"]) : String.Empty;
                                    obj.panremark = (!String.IsNullOrEmpty(Convert.ToString(dr["pan_remark"]))) ? Convert.ToString(dr["pan_remark"]) : String.Empty;
                                    obj.txtdin_pan = (!String.IsNullOrEmpty(Convert.ToString(dr["din_no"]))) ? Convert.ToString(dr["din_no"]) : String.Empty;
                                    obj.din_remark = (!String.IsNullOrEmpty(Convert.ToString(dr["din_remark"]))) ? Convert.ToString(dr["din_remark"]) : String.Empty;
                                    //obj.ddl17A = (!String.IsNullOrEmpty(Convert.ToString(dr["Listing17_1_A"]))) ? Convert.ToString(dr["Listing17_1_A"]) : String.Empty;
                                   // obj.txtdate = (!String.IsNullOrEmpty(Convert.ToString(dr["date_of_passing"]))) ? Convert.ToString(dr["date_of_passing"]) : String.Empty;
                                    obj.no_of_directorship = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_directorship"]))) ? Convert.ToString(dr["no_of_directorship"]) : String.Empty;
                                    obj.no_of_independent = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_independent"]))) ? Convert.ToString(dr["no_of_independent"]) : String.Empty;
                                    obj.no_of_membership = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_membership"]))) ? Convert.ToString(dr["no_of_membership"]) : String.Empty;
                                    obj.no_of_post_of_chairperson = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_post_of_chairperson"]))) ? Convert.ToString(dr["no_of_post_of_chairperson"]) : String.Empty;
                                    obj.occupation_Area = (!String.IsNullOrEmpty(Convert.ToString(dr["OCCUPATION_AREA"]))) ? Convert.ToString(dr["OCCUPATION_AREA"]) : String.Empty;
                                    obj.educational_Qualification = (!String.IsNullOrEmpty(Convert.ToString(dr["EDUCATIONAL_QUALIFICATION"]))) ? Convert.ToString(dr["EDUCATIONAL_QUALIFICATION"]) : String.Empty;
                                    obj.experience = (!String.IsNullOrEmpty(Convert.ToString(dr["EXPERIENCE"]))) ? Convert.ToString(dr["EXPERIENCE"]) : String.Empty;
                                    obj.gender = (!String.IsNullOrEmpty(Convert.ToString(dr["GENDER"]))) ? Convert.ToString(dr["GENDER"]) : String.Empty;
                                    obj.aadhar_Number = (!String.IsNullOrEmpty(Convert.ToString(dr["AADHAR_NUMBER"]))) ? Convert.ToString(dr["AADHAR_NUMBER"]) : String.Empty;
                                    obj.shareHolding = (!String.IsNullOrEmpty(Convert.ToString(dr["SHAREHOLDING"]))) ? Convert.ToString(dr["SHAREHOLDING"]) : String.Empty;
                                    obj.shareHolding_percentage = (!String.IsNullOrEmpty(Convert.ToString(dr["SHAREHOLDING_PERCENTAGE"]))) ? Convert.ToString(dr["SHAREHOLDING_PERCENTAGE"]) : String.Empty;
                                    obj.appointed_Section = (!String.IsNullOrEmpty(Convert.ToString(dr["APPOINTED_SECTION"]))) ? Convert.ToString(dr["APPOINTED_SECTION"]) : String.Empty;
                                    obj.committees_Already_director = (!String.IsNullOrEmpty(Convert.ToString(dr["COMMITTEES_ALREADY_DIRECTOR"]))) ? Convert.ToString(dr["COMMITTEES_ALREADY_DIRECTOR"]) : String.Empty;
                                    obj.membership_Num_Secretarial_User = (!String.IsNullOrEmpty(Convert.ToString(dr["MEMBERSHIP_NUM_SECRETARIAL_USER"]))) ? Convert.ToString(dr["MEMBERSHIP_NUM_SECRETARIAL_USER"]) : String.Empty;


                                    if (dtCompaniesList.Rows.Count > 0)
                                    {
                                        List<string> lstCompaniesList = new List<string>();
                                        string userLoginValue = dr["USER_LOGIN"].ToString();
                                        DataRow[] drKeywords = dtCompaniesList.Select("USER_LOGIN = '" + userLoginValue + "'");
                                        foreach (DataRow item in drKeywords)
                                        {
                                            string objcomp = item["OTHER_COMPANIES"].ToString();
                                            lstCompaniesList.Add(objcomp);
                                        }
                                        obj.multi_Companies = lstCompaniesList;
                                    }
                                    lstuser.Add(obj);

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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        //public UserResponse GetUserList(User objUser)
        //{
        //    _userResponse = new UserResponse();
        //    _userResponse.StatusFl = false;
        //    _userResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(objUser.moduleDatabase);
        //            SqlParameter[] parameters = new SqlParameter[3];
        //        parameters[0] = new SqlParameter("@Mode", "GET_USER_LIST");
        //        parameters[1] = new SqlParameter("@SET_COUNT", SqlDbType.Int);
        //        parameters[1].Direction = ParameterDirection.Output;
        //        parameters[2] = new SqlParameter("@COMPANY_ID", objUser.companyId);
        //        //parameters[3] = new SqlParameter("@CREATED_BY", objUser.createdBy);
        //        //parameters[3] = new SqlParameter("@STATUS", (objUser.status != "0" ? objUser.status : null));

        //        //SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.GetConnString(), CommandType.StoredProcedure, "SP_PROCS_INSIDER_USER_PERSONAL_MASTER", objUser.MODULE_DATABASE, parameters);

        //        DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.GetConnString(), CommandType.StoredProcedure, "SP_PROCS_BMS_USER_MASTER", parameters);
        //        DataTable dt = ds.Tables[1];
        //        DataTable dtCompaniesList = ds.Tables[1];
        //        //UserResponse oUser = new UserResponse();
        //        if (dt != null)
        //        {
        //            if (dt.Rows.Count > 0)
        //            {
        //                List<User> lstuser = new List<User>();
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    User obj = new User();
        //                    obj.ID = Convert.ToInt32(dr["ID"]);
        //                    obj.salutation = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_SALUTATION"]))) ? Convert.ToString(dr["USER_SALUTATION"]) : String.Empty;
        //                    obj.userFirstName = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_FIRST_NAME"]))) ? Convert.ToString(dr["USER_FIRST_NAME"]) : String.Empty;
        //                    obj.userMiddleName = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_MIDDLE_NAME"]))) ? Convert.ToString(dr["USER_MIDDLE_NAME"]) : String.Empty;
        //                    obj.userLastName = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_LAST_NAME"]))) ? Convert.ToString(dr["USER_LAST_NAME"]) : String.Empty;
        //                    obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_EMAIL"]))) ? Convert.ToString(dr["USER_EMAIL"]) : String.Empty;
        //                    //obj.ROLE_NAME = (!String.IsNullOrEmpty(Convert.ToString(dr["ROLE"]))) ? Convert.ToString(dr["ROLE"]) : String.Empty;
        //                    //obj.role = new Role
        //                    //{
        //                    //    Id = Convert.ToInt32(dr["USER_ROLE"]),
        //                    //    role = (!String.IsNullOrEmpty(Convert.ToString(dr["ROLE"]))) ? Convert.ToString(dr["ROLE"]) : String.Empty
        //                    //};
        //                    obj.role = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_ROLE"]))) ? Convert.ToString(dr["USER_ROLE"]) : String.Empty;
        //                    obj.phone = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_MOBILE"]))) ? Convert.ToString(dr["USER_MOBILE"]) : String.Empty;
        //                    obj.address = (!String.IsNullOrEmpty(Convert.ToString(dr["ADDRESS"]))) ? Convert.ToString(dr["ADDRESS"]) : String.Empty;
        //                    obj.designation = (!String.IsNullOrEmpty(Convert.ToString(dr["DESIGNATION_NAME"]))) ? Convert.ToString(dr["DESIGNATION_NAME"]) : String.Empty;
        //                    obj.department = (!String.IsNullOrEmpty(Convert.ToString(dr["DEPARTMENT_NAME"]))) ? Convert.ToString(dr["DEPARTMENT_NAME"]) : String.Empty;
        //                    obj.category = (!String.IsNullOrEmpty(Convert.ToString(dr["CATEGORY_NAME"]))) ? Convert.ToString(dr["CATEGORY_NAME"]) : String.Empty;
        //                    obj.tenureStartDate = (!String.IsNullOrEmpty(Convert.ToString(dr["TENURE_START"]))) ? Convert.ToString(dr["TENURE_START"]) : String.Empty;
        //                    obj.tenureEndDate = (!String.IsNullOrEmpty(Convert.ToString(dr["TENURE_END"]))) ? Convert.ToString(dr["TENURE_END"]) : String.Empty;
        //                    obj.dateOfBirth = (!String.IsNullOrEmpty(Convert.ToString(dr["DATE_OF_BIRTH"]))) ? Convert.ToString(dr["DATE_OF_BIRTH"]) : String.Empty;
        //                    obj.nationality = (!String.IsNullOrEmpty(Convert.ToString(dr["NATIONALITY"]))) ? Convert.ToString(dr["NATIONALITY"]) : String.Empty;
        //                    obj.userLogin = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_LOGIN"]))) ? Convert.ToString(dr["USER_LOGIN"]) : String.Empty;
        //                    //obj.password = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_PWD"]))) ? Convert.ToString(dr["USER_PWD"]) : String.Empty;
        //                     obj.password = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_PWD"]))) ? CryptoEngine.Decrypt(Convert.ToString(dr["USER_PWD"]), true) : String.Empty;
        //                    obj.status = (!String.IsNullOrEmpty(Convert.ToString(dr["STATUS"]))) ? Convert.ToString(dr["STATUS"]) : String.Empty;
        //                    obj.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(dr["UPLOAD_AVATAR"]))) ? Convert.ToString(dr["UPLOAD_AVATAR"]) : String.Empty;
        //                    obj.profile = (!String.IsNullOrEmpty(Convert.ToString(dr["USER_PROFILE"]))) ? Convert.ToString(dr["USER_PROFILE"]) : String.Empty;
        //                   // obj.companyId = Convert.ToInt32(dr["COMPANY_ID"]);
        //                    //obj.department = new Department
        //                    //{
        //                    //    departmentId = Convert.ToInt32(dr["DEPARTMENT_ID"]),
        //                    //    departmentName = (!String.IsNullOrEmpty(Convert.ToString(dr["DEPARTMENT_NM"]))) ? Convert.ToString(dr["DEPARTMENT_NM"]) : String.Empty
        //                    //};
        //                    //obj.designation = new Designation
        //                    //{
        //                    //    ID = Convert.ToInt32(dr["DESIGNATION_ID"]),
        //                    //    designationName = (!String.IsNullOrEmpty(Convert.ToString(dr["DESIGNATION_NAME"]))) ? Convert.ToString(dr["DESIGNATION_NAME"]) : String.Empty
        //                    //};
        //                    //obj.category = new Category
        //                    //{
        //                    //    ID = Convert.ToInt32(dr["CATEGORY_ID"]),
        //                    //    categoryName = (!String.IsNullOrEmpty(Convert.ToString(dr["CATEGORY_NAME"]))) ? Convert.ToString(dr["CATEGORY_NAME"]) : String.Empty
        //                    //};
        //                    //for director open

        //                    obj.txtdp_pan = (!String.IsNullOrEmpty(Convert.ToString(dr["pan_no"]))) ? Convert.ToString(dr["pan_no"]) : String.Empty;
        //                    obj.panremark = (!String.IsNullOrEmpty(Convert.ToString(dr["pan_remark"]))) ? Convert.ToString(dr["pan_remark"]) : String.Empty;
        //                    obj.txtdin_pan = (!String.IsNullOrEmpty(Convert.ToString(dr["din_no"]))) ? Convert.ToString(dr["din_no"]) : String.Empty;
        //                    obj.din_remark = (!String.IsNullOrEmpty(Convert.ToString(dr["din_remark"]))) ? Convert.ToString(dr["din_remark"]) : String.Empty;
        //                    obj.ddlcat1 = (!String.IsNullOrEmpty(Convert.ToString(dr["cat1"]))) ? Convert.ToString(dr["cat1"]) : String.Empty;
        //                    obj.ddlcat2 = (!String.IsNullOrEmpty(Convert.ToString(dr["cat2"]))) ? Convert.ToString(dr["cat2"]) : String.Empty;
        //                    obj.ddlcat3 = (!String.IsNullOrEmpty(Convert.ToString(dr["cat3"]))) ? Convert.ToString(dr["cat3"]) : String.Empty;
        //                    obj.ddl17A = (!String.IsNullOrEmpty(Convert.ToString(dr["Listing17_1_A"]))) ? Convert.ToString(dr["Listing17_1_A"]) : String.Empty;
        //                    obj.txtdate = (!String.IsNullOrEmpty(Convert.ToString(dr["date_of_passing"]))) ? Convert.ToString(dr["date_of_passing"]) : String.Empty;
        //                    obj.no_of_directorship = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_directorship"]))) ? Convert.ToString(dr["no_of_directorship"]) : String.Empty;
        //                    obj.no_of_independent = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_independent"]))) ? Convert.ToString(dr["no_of_independent"]) : String.Empty;
        //                    obj.no_of_membership = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_membership"]))) ? Convert.ToString(dr["no_of_membership"]) : String.Empty;
        //                    obj.no_of_post_of_chairperson = (!String.IsNullOrEmpty(Convert.ToString(dr["no_of_post_of_chairperson"]))) ? Convert.ToString(dr["no_of_post_of_chairperson"]) : String.Empty;
        //                    obj.occupation_Area = (!String.IsNullOrEmpty(Convert.ToString(dr["OCCUPATION_AREA"]))) ? Convert.ToString(dr["OCCUPATION_AREA"]) : String.Empty;
        //                    obj.educational_Qualification = (!String.IsNullOrEmpty(Convert.ToString(dr["EDUCATIONAL_QUALIFICATION"]))) ? Convert.ToString(dr["EDUCATIONAL_QUALIFICATION"]) : String.Empty;
        //                    obj.experience = (!String.IsNullOrEmpty(Convert.ToString(dr["EXPERIENCE"]))) ? Convert.ToString(dr["EXPERIENCE"]) : String.Empty;
        //                    obj.gender = (!String.IsNullOrEmpty(Convert.ToString(dr["GENDER"]))) ? Convert.ToString(dr["GENDER"]) : String.Empty;
        //                    obj.aadhar_Number = (!String.IsNullOrEmpty(Convert.ToString(dr["AADHAR_NUMBER"]))) ? Convert.ToString(dr["AADHAR_NUMBER"]) : String.Empty;
        //                    obj.shareHolding = (!String.IsNullOrEmpty(Convert.ToString(dr["SHAREHOLDING"]))) ? Convert.ToString(dr["SHAREHOLDING"]) : String.Empty;
        //                    obj.shareHolding_percentage = (!String.IsNullOrEmpty(Convert.ToString(dr["SHAREHOLDING_PERCENTAGE"]))) ? Convert.ToString(dr["SHAREHOLDING_PERCENTAGE"]) : String.Empty;
        //                    //obj.currency_Symbol = (!String.IsNullOrEmpty(Convert.ToString(dr["CURRENCY_SYMBOL"]))) ? Convert.ToString(dr["CURRENCY_SYMBOL"]) : String.Empty;
        //                    //obj.sitting_Amount = (!String.IsNullOrEmpty(Convert.ToString(dr["SITTING_AMOUNT"]))) ? Convert.ToString(dr["SITTING_AMOUNT"]) : String.Empty;
        //                    //obj.payment_mode = (!String.IsNullOrEmpty(Convert.ToString(dr["PAYMENT_MODE"]))) ? Convert.ToString(dr["PAYMENT_MODE"]) : String.Empty;
        //                    //obj.remuneration_Amount = (!String.IsNullOrEmpty(Convert.ToString(dr["REMUNERATION_AMOUNT"]))) ? Convert.ToString(dr["REMUNERATION_AMOUNT"]) : String.Empty;
        //                    obj.appointed_Section = (!String.IsNullOrEmpty(Convert.ToString(dr["APPOINTED_SECTION"]))) ? Convert.ToString(dr["APPOINTED_SECTION"]) : String.Empty;
        //                    //obj.multi_Companies = (!String.IsNullOrEmpty(Convert.ToString(dr["OTHER_COMPANIES"]))) ? Convert.ToString(dr["OTHER_COMPANIES"]) : String.Empty;
        //                    obj.committees_Already_director = (!String.IsNullOrEmpty(Convert.ToString(dr["COMMITTEES_ALREADY_DIRECTOR"]))) ? Convert.ToString(dr["COMMITTEES_ALREADY_DIRECTOR"]) : String.Empty;
        //                    obj.membership_Num_Secretarial_User = (!String.IsNullOrEmpty(Convert.ToString(dr["MEMBERSHIP_NUM_SECRETARIAL_USER"]))) ? Convert.ToString(dr["MEMBERSHIP_NUM_SECRETARIAL_USER"]) : String.Empty;


        //                    if (dtCompaniesList.Rows.Count > 0)
        //                    {
        //                        //if (o.LOGIN_ID == Convert.ToString(dtCompaniesList.Rows[0][0]))
        //                        //{
        //                        List<string> lstCompaniesList = new List<string>();
        //                        string userLoginValue = dr["USER_LOGIN"].ToString();
        //                        DataRow[] drKeywords = dtCompaniesList.Select("USER_LOGIN = '" + userLoginValue + "'");
        //                        foreach (DataRow item in drKeywords)
        //                        {
        //                            string objcomp = item["OTHER_COMPANIES"].ToString();
        //                            lstCompaniesList.Add(objcomp);
        //                        }
        //                        obj.multi_Companies = lstCompaniesList;
        //                        //}
        //                    }
        //                    lstuser.Add(obj);

        //                }

        //                _userResponse.UserList = lstuser;
        //                _userResponse.StatusFl = true;
        //                _userResponse.Msg = "Data has been fetched successfully !";
        //            }
        //        }
        //        else
        //        {
        //            _userResponse.StatusFl = false;
        //            _userResponse.Msg = "No data found !";
        //        }
        //            conn.Close();
        //            return _userResponse;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _userResponse = new UserResponse();
        //        _userResponse.StatusFl = false;
        //        _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _userResponse;
        //}

        public UserResponse GetAllUsersRole(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
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
                                User obj = new User();
                                //obj.ID = Convert.ToInt32(rdr.GetValue(0));
                                obj.role = new Role
                                {
                                    Id = Convert.ToInt32(rdr.GetValue(0)),
                                    role = Convert.ToString(rdr.GetValue(1))
                                };
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        //public UserResponse GetAllUsersRole(User objUser)
        //{
        //    _userResponse = new UserResponse
        //    {
        //        StatusFl = false,
        //        Msg = "No Data Found!"
        //    };

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(objUser.moduleDatabase);

        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.AddWithValue("@Mode", "Get_All_Users_Role");
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                DataSet ds = new DataSet();

        //                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //                {
        //                    adapter.Fill(ds);
        //                }
        //                DataTable dt = ds.Tables[0];
        //                using (SqlDataReader rdr = cmd.ExecuteReader())
        //                {
        //                    if (rdr.HasRows)
        //                    {
        //                        List<User> lstuser = new List<User>();

        //                        while (rdr.Read())
        //                        {
        //                            Role obj = new Role
        //                            {
        //                                Id = Convert.ToInt32(rdr["ID"]),
        //                                role = rdr["ROLE"] != DBNull.Value ? Convert.ToString(rdr["ROLE"]) : string.Empty
        //                            };
        //                            lstuser.Add(obj);
        //                        }

        //                        objUser.role = lstuser;
        //                        _userResponse.AddObject(objUser);
        //                        _userResponse.StatusFl = true;
        //                        _userResponse.Msg = "Data has been fetched successfully!";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception if needed
        //        // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));

        //        // Update the response message
        //        _userResponse.Msg = "Something went wrong. Please try again or contact support!";
        //    }

        //    return _userResponse;
        //}




        public UserResponse GetEmailList(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
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
                                User obj = new User();
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public UserResponse GetUserDetails(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_DETAILS"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.LoginId));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                User obj = new User();
                                obj.uploadAvatar = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["UPLOAD_AVATAR"])) ? Convert.ToString(dt.Rows[0]["UPLOAD_AVATAR"]) : String.Empty;
                                obj.userFirstName = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["USER_FIRST_NAME"])) ? Convert.ToString(dt.Rows[0]["USER_FIRST_NAME"]) : String.Empty;
                                obj.userMiddleName = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["USER_MIDDLE_NAME"])) ? Convert.ToString(dt.Rows[0]["USER_MIDDLE_NAME"]) : String.Empty;
                                obj.userLastName = !String.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["USER_LAST_NAME"])) ? Convert.ToString(dt.Rows[0]["USER_LAST_NAME"]) : String.Empty;
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public UserResponse GetUsersForComposition(User objUser)
        {
            _userResponse = new UserResponse();
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_FOR_COMPOSITION"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        cmd.Parameters.Add(new SqlParameter("@NAME", objUser.userName));
                        //cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objUser.committee.ID));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                User obj = new User();
                                obj.ID = Convert.ToInt32(rdr["ID"]);
                                obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty;
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        //public UserResponse GetUserforCompositionAllUser(User objUser)
        //{
        //    _userResponse = new UserResponse();
        //    _userResponse.StatusFl = false;
        //    _userResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            //conn.ChangeDatabase(objUser.moduleDatabase);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_FOR_COMPOSITION_ALL_USER"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@NAME", objUser.userName));
        //                //cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objUser.committee.ID));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        User obj = new User();
        //                        obj.ID = Convert.ToInt32(rdr["ID"]);
        //                        obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty;
        //                        obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty;
        //                        _userResponse.AddObject(obj);
        //                    }
        //                    _userResponse.StatusFl = true;
        //                    _userResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _userResponse = new UserResponse();
        //        _userResponse.StatusFl = false;
        //        _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _userResponse;
        //}

        //public UserResponse GetUsersForMeeting(User objUser)
        //{
        //    _userResponse = new UserResponse();
        //    _userResponse.StatusFl = false;
        //    _userResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            //conn.ChangeDatabase(objUser.moduleDatabase);
        //            //using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER", conn))
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USERS_FOR_MEETING"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@NAME", objUser.userName));
        //                //cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objUser.committee.ID));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        User obj = new User();
        //                        obj.ID = Convert.ToInt32(rdr["ID"]);
        //                        obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["NAME"]))) ? Convert.ToString(rdr["NAME"]) : String.Empty;
        //                        obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["EMAIL_ID"]))) ? Convert.ToString(rdr["EMAIL_ID"]) : String.Empty;
        //                        //obj.role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty;
        //                        //obj.role = new Role
        //                        //{
        //                        //    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty
        //                        //};
        //                        obj.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(rdr["UPLOAD_AVATAR"]))) ? Convert.ToString(rdr["UPLOAD_AVATAR"]) : String.Empty;
        //                        _userResponse.AddObject(obj);
        //                    }
        //                    _userResponse.StatusFl = true;
        //                    _userResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _userResponse = new UserResponse();
        //        _userResponse.StatusFl = false;
        //        _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _userResponse;
        //}

        public UserResponse AddTemporaryUser(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    //using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER", conn))
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT_TEMPORARY_INVITEE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@EMAIL_ID", objUser.emailId));
                        cmd.ExecuteNonQuery();
                        var obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if ((Int32)obj == 0)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT_TEMPORARY_INVITEE"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@NAME", objUser.userName));
                            cmd.Parameters.Add(new SqlParameter("@EMAIL_ID", objUser.emailId));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                            cmd.ExecuteNonQuery();
                            objUser.ID = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);

                            //parameters[0] = new SqlParameter("@MODE", "GET_TEMPORARY_USER_ID_BY_EMAIL");                            
                            //parameters[1] = new SqlParameter("@ACTION_TYPE", "INSERT_TEMPORARY_INVITEE");
                            //parameters[2] = new SqlParameter("@SET_COUNT", SqlDbType.Int);
                            //parameters[3] = new SqlParameter("@NAME", objUser.userName);
                            //parameters[4] = new SqlParameter("@EMAIL_ID", objUser.emailId);
                            //parameters[5] = new SqlParameter("@COMPANY_ID", objUser.companyId);
                            //parameters[6] = new SqlParameter("@ID", objUser.ID);
                            //var userId = SQLHelper.ExecuteScalar(SQLHelper.GetConnString(), CommandType.StoredProcedure, "SP_PROCS_BMS_USER", objUser.moduleDatabase, parameters);
                            //objUser.ID = (Int32)userId;

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "GET_TEMPORARY_USERS_FOR_MEETING"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                            SqlDataReader rdr = cmd.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    User objuser = new User();
                                    objuser.ID = Convert.ToInt32(rdr["ID"]);
                                    objuser.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["NAME"]))) ? Convert.ToString(rdr["NAME"]) : String.Empty;
                                    objuser.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["EMAIL_ID"]))) ? Convert.ToString(rdr["EMAIL_ID"]) : String.Empty;
                                    //objuser.role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty;
                                    //objuser.role = new Role
                                    //{
                                    //    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty
                                    //};
                                    objuser.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(rdr["UPLOAD_AVATAR"]))) ? Convert.ToString(rdr["UPLOAD_AVATAR"]) : String.Empty;
                                    _userResponse.AddObject(objuser);
                                }
                            }
                            rdr.Close();
                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been saved successfully !";
                            _userResponse.User = objUser;
                        }
                        else
                        {
                            _userResponse.StatusFl = false;
                            _userResponse.Msg = "User Email aleady exists !";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public UserResponse GetUserNameByLoginId(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    //using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER", conn))
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_NAME_BY_LOGIN"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objUser.LoginId));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                User obj = new User();
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public UserResponse GetUserEmailById(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    //using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER", conn))
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_USER_MASTER", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_EMAIL_BY_ID"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@ID", objUser.ID));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                User obj = new User();
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        public UserResponse GetUsersForCommitteeSuperAdmin(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_FOR_COMMITTEE_SUPER_ADMIN"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));
                        cmd.Parameters.Add(new SqlParameter("@NAME", objUser.userName));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                User obj = new User();
                                obj.ID = Convert.ToInt32(rdr["ID"]);
                                obj.userLogin = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_LOGIN"]))) ? Convert.ToString(rdr["USER_LOGIN"]) : String.Empty;
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }


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


        //changes for BOD report by gaurav
        public UserResponse SaveAffiramation(User objUser)
        {
            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                var year = objUser.year;
                List<string> allpara = new List<string>();
                //allpara.Add(objUser.year);
                allpara.Add(objUser.first);
                allpara.Add(objUser.first1);
                allpara.Add(objUser.first2);
                allpara.Add(objUser.first3);
                allpara.Add(objUser.first4);
                allpara.Add(objUser.first5);
                allpara.Add(objUser.first6);
                allpara.Add(objUser.first7);
                allpara.Add(objUser.first8);

                for (int i = 0; i < allpara.Count; i++)
                {
                    var query = "insert into BMS_Affirmations(year,status) Values ('" + year + "','" + allpara[i] + "')";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        //conn.ChangeDatabase(objUser.moduleDatabase);
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();

                            _userResponse.StatusFl = true;
                            _userResponse.Msg = "Data has been saved successfully !";
                            _userResponse.User = objUser;

                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }

        //close


        public UserResponse GetAllUserByCompany(User objUser)
        {

            _userResponse = new UserResponse();
            _userResponse.StatusFl = false;
            _userResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_GETUSERATTENDANCE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_ALL_USER_BY_COMPANY"));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objUser.CompanyId));

                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                User obj = new User();
                                obj.ID = Convert.ToInt32(rdr["ID"]);
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
                _userResponse = new UserResponse();
                _userResponse.StatusFl = false;
                _userResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _userResponse;
        }
    }
}