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
    public class CompanyGroupRepository : IRequiresSessionState
    {
        private CompanyGroupResponse _companygroupResponse;
        private string connectionString = SQLHelper.GetConnString();
        public CompanyGroupResponse GetCompanyGroupList(CompanyGrooup objCompanygroup)
        {
            _companygroupResponse = new CompanyGroupResponse();
            _companygroupResponse.StatusFl = false;
            _companygroupResponse.Msg = "No Data Found!";
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMPANY_GROUP_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                      //  cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCompanygroup.CompanyGroupId));
                        // cmd.Parameters.Add(new SqlParameter("@STATUS", (objCompany.status != "0" ? objUser.status : null)));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                CompanyGrooup obj = new CompanyGrooup();
                                obj.CompanyGroupId = Convert.ToInt32(rdr["GROUP_ID"]);
                                obj.CompanyGroupName = (!String.IsNullOrEmpty(Convert.ToString(rdr["GROUP_NM"]))) ? Convert.ToString(rdr["GROUP_NM"]) : String.Empty;

                                obj.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(rdr["LOGO"]))) ? Convert.ToString(rdr["LOGO"]) : String.Empty;

                                _companygroupResponse.AddCompany(obj);
                            }
                            _companygroupResponse.StatusFl = true;
                            _companygroupResponse.Msg = "Data has been fetched successfully !";
                            // _companyResponse.companys = _company;
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companygroupResponse = new CompanyGroupResponse();
                _companygroupResponse.StatusFl = false;
                _companygroupResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companygroupResponse;
        }

        public CompanyGroupResponse AddCompnayGroup(CompanyGrooup _companygroup)
        {
            _companygroupResponse = new CompanyGroupResponse();
            _companygroupResponse.StatusFl = false;
            _companygroupResponse.Msg = "Something went wrong. Please try again or Contact Support!";
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE_COMPANY_GROUP"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
               
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_GROUP_ID", _companygroup.CompanyGroupId));

                        cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", _companygroup.createdBy));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_GROUP_NM", _companygroup.CompanyGroupName));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_LOGO", _companygroup.uploadAvatar));
                        cmd.ExecuteNonQuery();

                        _companygroup.CompanyGroupId = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        _companygroupResponse.StatusFl = true;
                        _companygroupResponse.Msg = "Data has been saved successfully !";
                        // _companyResponse.companys = _company;
                    }


                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companygroupResponse = new CompanyGroupResponse();
                _companygroupResponse.StatusFl = false;
                _companygroupResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                //  new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companygroupResponse;
        }

        public CompanyGroupResponse UpdateCompanyGroup(CompanyGrooup _companygroup)
        {
            _companygroupResponse = new CompanyGroupResponse();
            _companygroupResponse.StatusFl = false;
            _companygroupResponse.Msg = "Something went wrong. Please try again or Contact Support!";
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE_COMPANY_GROUP"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));

                        cmd.Parameters.Add(new SqlParameter("@COMPANY_GROUP_ID", _companygroup.CompanyGroupId));

                        cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", _companygroup.createdBy));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_GROUP_NM", _companygroup.CompanyGroupName));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_LOGO", _companygroup.uploadAvatar));
                        cmd.ExecuteNonQuery();

                        _companygroup.CompanyGroupId = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        _companygroupResponse.StatusFl = true;
                        _companygroupResponse.Msg = "Data has been saved successfully !";
                        // _companyResponse.Department = _company;
                    }


                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _companygroupResponse = new CompanyGroupResponse();
                _companygroupResponse.StatusFl = false;
                _companygroupResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                /// new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companygroupResponse;
        }

    }
}