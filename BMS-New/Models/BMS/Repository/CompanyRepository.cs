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
    public class CompanyRepository : IRequiresSessionState
    {
        private CompanyResponse _companyResponse;
        private string connectionString = SQLHelper.GetConnString();

        public CompanyResponse AddCompnay(Company _company)
        {
            _companyResponse = new CompanyResponse();          
            _companyResponse.StatusFl = false;
            _companyResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                   // conn.ChangeDatabase(_company.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_Company", conn))
                    {
                       
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _company.companyId));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_GROUP_ID", _company.CompanyGroupId));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_TYPE_ID", _company.CompanyTypeId));
                            cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", _company.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_NM", _company.CompanyName));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_LOGO", _company.uploadAvatar));
                            cmd.ExecuteNonQuery();

                        _company.companyId = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        _companyResponse.StatusFl = true;
                        _companyResponse.Msg = "Data has been saved successfully !";
                       // _companyResponse.companys = _company;
                        }
                        
                    
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companyResponse = new CompanyResponse();
                _companyResponse.StatusFl = false;
                _companyResponse.Msg = "Something went wrong. Please try again or Contact Support!";
              //  new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companyResponse;
        }

        public CompanyResponse UpdateCompany(Company _company)
        {
            _companyResponse = new CompanyResponse();
            _companyResponse.StatusFl = false;
            _companyResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // conn.ChangeDatabase(_company.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_Company", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _company.companyId));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_TYPE_ID", _company.CompanyTypeId));
                        cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", _company.createdBy));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_NM", _company.CompanyName));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_LOGO", _company.uploadAvatar));
                        cmd.ExecuteNonQuery();

                        _company.companyId = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        _companyResponse.StatusFl = true;
                        _companyResponse.Msg = "Data has been saved successfully !";
                       // _companyResponse.Department = _company;
                    }


                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companyResponse = new CompanyResponse();
                _companyResponse.StatusFl = false;
                _companyResponse.Msg = "Something went wrong. Please try again or Contact Support!";
               /// new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companyResponse;
        }

        public CompanyResponse GetCompanyList(Company objCompany)
        {
            _companyResponse = new CompanyResponse();
            _companyResponse.StatusFl = false;
            _companyResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_Company", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMPANIES"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCompany.companyId));
                       // cmd.Parameters.Add(new SqlParameter("@STATUS", (objCompany.status != "0" ? objUser.status : null)));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Company obj = new Company();

                                obj.companyId = Convert.ToInt32(rdr["COMPANY_ID"]);
                                obj.CompanyTypeId = Convert.ToInt32(rdr["COMPANY_TYPE_ID"]);
                                obj.CompanyGroupId = Convert.ToInt32(rdr["GROUP_ID"]);
                                obj.CompanyName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMPANY_NM"]))) ? Convert.ToString(rdr["COMPANY_NM"]) : String.Empty;
                                obj.CompanyGroupName = (!String.IsNullOrEmpty(Convert.ToString(rdr["GROUP_NM"]))) ? Convert.ToString(rdr["GROUP_NM"]) : String.Empty;
                                obj.CompanyTypeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMPANY_TYPE_NM"]))) ? Convert.ToString(rdr["COMPANY_TYPE_NM"]) : String.Empty;


                                obj.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(rdr["LOGO"]))) ? Convert.ToString(rdr["LOGO"]) : String.Empty;

                                _companyResponse.AddCompany(obj);
                            }
                            _companyResponse.StatusFl = true;
                            _companyResponse.Msg = "Data has been fetched successfully !";
                           // _companyResponse.companys = _company;
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companyResponse = new CompanyResponse();
                _companyResponse.StatusFl = false;
                _companyResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companyResponse;
        }

        //For Super Admin
        public CompanyResponse GetCompanyForAdminUserList(Company objCompany)
        {
            _companyResponse = new CompanyResponse();
            _companyResponse.StatusFl = false;
            _companyResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_Company", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMPANIES"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCompany.companyId));
                        // cmd.Parameters.Add(new SqlParameter("@STATUS", (objCompany.status != "0" ? objUser.status : null)));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Company obj = new Company();

                                obj.companyId = Convert.ToInt32(rdr["COMPANY_ID"]);
                                obj.CompanyTypeId = Convert.ToInt32(rdr["COMPANY_TYPE_ID"]);
                                obj.CompanyGroupId = Convert.ToInt32(rdr["GROUP_ID"]);
                                obj.CompanyName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMPANY_NM"]))) ? Convert.ToString(rdr["COMPANY_NM"]) : String.Empty;
                                obj.CompanyGroupName = (!String.IsNullOrEmpty(Convert.ToString(rdr["GROUP_NM"]))) ? Convert.ToString(rdr["GROUP_NM"]) : String.Empty;
                                obj.CompanyTypeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMPANY_TYPE_NM"]))) ? Convert.ToString(rdr["COMPANY_TYPE_NM"]) : String.Empty;


                                obj.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(rdr["LOGO"]))) ? Convert.ToString(rdr["LOGO"]) : String.Empty;

                                _companyResponse.AddCompany(obj);
                            }
                            _companyResponse.StatusFl = true;
                            _companyResponse.Msg = "Data has been fetched successfully !";
                            // _companyResponse.companys = _company;
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companyResponse = new CompanyResponse();
                _companyResponse.StatusFl = false;
                _companyResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companyResponse;
        }
        public CompanyResponse GetCompanyTypeList(Company objCompany)
        {
            _companyResponse = new CompanyResponse();
            _companyResponse.StatusFl = false;
            _companyResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //conn.ChangeDatabase(objUser.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_Company", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMPANY_TYPE_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCompany.companyId));
                        // cmd.Parameters.Add(new SqlParameter("@STATUS", (objCompany.status != "0" ? objUser.status : null)));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Company obj = new Company();
                                obj.CompanyTypeId = Convert.ToInt32(rdr["COMPANY_TYPE_ID"]);
                                obj.CompanyTypeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMPANY_TYPE_NM"]))) ? Convert.ToString(rdr["COMPANY_TYPE_NM"]) : String.Empty;

                         

                                _companyResponse.AddCompany(obj);
                            }
                            _companyResponse.StatusFl = true;
                            _companyResponse.Msg = "Data has been fetched successfully !";
                            // _companyResponse.companys = _company;
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companyResponse = new CompanyResponse();
                _companyResponse.StatusFl = false;
                _companyResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companyResponse;
        }
    }
}