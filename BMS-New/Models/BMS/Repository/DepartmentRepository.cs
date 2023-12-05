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
    public class DepartmentRepository: IRequiresSessionState
    {
        private DepartmentResponse _departmentResponse;
        private string connectionString = SQLHelper.GetConnString();

        public DepartmentResponse AddDepartment(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_DEPARTMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        Int32 obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (obj == 0)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", _department.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_NM", _department.departmentName));
                            cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_HEAD", _department.departmentHead));
                            cmd.ExecuteNonQuery();

                            _department.departmentId = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been saved successfully !";
                            _departmentResponse.Department = _department;
                        }
                        else
                        {
                            _departmentResponse.StatusFl = false;
                            _departmentResponse.Msg = "Department Name aleady exists !";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse = new DepartmentResponse();
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }

        public DepartmentResponse UpdateDepartment(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_DEPARTMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_NM", _department.departmentName));
                        cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_HEAD", _department.departmentHead));
                        cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", _department.departmentId));
                        cmd.ExecuteNonQuery();
                        Int32 obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (obj != 0)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", _department.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_NM", _department.departmentName));
                            cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_HEAD", _department.departmentHead));
                            cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", _department.departmentId));
                            cmd.ExecuteNonQuery();

                            _department.departmentId = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been updated successfully !";
                            _departmentResponse.Department = _department;
                        }
                        else
                        {
                            _departmentResponse.StatusFl = false;
                            _departmentResponse.Msg = "Department Name aleady exists !";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse = new DepartmentResponse();
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }

        public DepartmentResponse DeleteDepartment(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_DEPARTMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "DELETE_DEPARTMENT"));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@DEPARTMENT_ID", _department.departmentId));
                        cmd.ExecuteNonQuery();
                        _departmentResponse.StatusFl = true;
                        _departmentResponse.Msg = "Data has been deleted successfully !";
                        _departmentResponse.Department = _department;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse = new DepartmentResponse();
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }

        public DepartmentResponse GetDepartmentList(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_DEPARTMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_DEPARTMENT_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Department objDepartment;
                            while (rdr.Read())
                            {
                                objDepartment = new Department();
                                objDepartment.departmentId = Convert.ToInt32(rdr["DEPARTMENT_ID"]);
                                objDepartment.departmentName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_NM"]))) ? Convert.ToString(rdr["DEPARTMENT_NM"]) : String.Empty;
                                objDepartment.departmentHead = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_HEAD"]))) ? Convert.ToString(rdr["DEPARTMENT_HEAD"]) : String.Empty;
                                //obj.createdBy = Convert.ToString(rdr["CREATE_BY"]);
                                //obj.createdOn = Convert.ToString(rdr["CREATED_ON"]);
                                //obj.CompanyId = Convert.ToInt32(rdr["COMPANY_ID"]);
                                _departmentResponse.AddObject(objDepartment);
                            }
                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }

        public DepartmentResponse GetDepartmentsForUser(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_DEPARTMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_DEPARTMENT_FOR_USERS"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Department objDepartment;
                            while (rdr.Read())
                            {
                                objDepartment = new Department();
                                objDepartment.departmentId = Convert.ToInt32(rdr["DEPARTMENT_ID"]);
                                objDepartment.departmentName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_NM"]))) ? Convert.ToString(rdr["DEPARTMENT_NM"]) : String.Empty;
                                _departmentResponse.AddObject(objDepartment);
                            }
                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }

        public DepartmentResponse GetDepartmentForWorkFlow(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_DEPARTMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_DEPARTEMENT_FOR_WORKFLOW"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Department objDepartment;
                            while (rdr.Read())
                            {
                                objDepartment = new Department();
                                objDepartment.departmentId = Convert.ToInt32(rdr["DEPARTMENT_ID"]);
                                objDepartment.departmentName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_NM"]))) ? Convert.ToString(rdr["DEPARTMENT_NM"]) : String.Empty;
                                _departmentResponse.AddObject(objDepartment);
                            }
                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }

        public DepartmentResponse GetDepartmentForAgenda(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_DEPARTMENT", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_DEPARTEMENT_FOR_AGENDA"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Department objDepartment;
                            while (rdr.Read())
                            {
                                objDepartment = new Department();
                                objDepartment.departmentId = Convert.ToInt32(rdr["DEPARTMENT_ID"]);
                                objDepartment.departmentName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_NM"]))) ? Convert.ToString(rdr["DEPARTMENT_NM"]) : String.Empty;
                                _departmentResponse.AddObject(objDepartment);
                            }
                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
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
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }

            return Convert.ToDateTime(str);
        }

        #endregion
        public DepartmentResponse getDepartmentAuditRecord(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "No Data Found!";
            List<Department> lstDepartment = new List<Department>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_BMS_AUDIT_REPORT_ALL", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "DEPARTMENT"));
                        cmd.Parameters.Add(new SqlParameter("@FROMDATE", ConvertDate(_department.fromDate)));
                        cmd.Parameters.Add(new SqlParameter("@TODATE", ConvertDate(_department.toDate)));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Department objDepartment;
                            while (rdr.Read())
                            {
                                objDepartment = new Department();
                                objDepartment.departmentId = Convert.ToInt32(rdr["DEPARTMENT_ID"]);
                                objDepartment.departmentName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_NM"]))) ? Convert.ToString(rdr["DEPARTMENT_NM"]) : String.Empty;
                                objDepartment.departmentHead = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_HEAD"]))) ? Convert.ToString(rdr["DEPARTMENT_HEAD"]) : String.Empty;
                                objDepartment.createdBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATED_BY"]))) ? Convert.ToString(rdr["CREATED_BY"]) : String.Empty;
                                objDepartment.createdOn = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATEDON"]))) ? Convert.ToString(rdr["CREATEDON"]) : String.Empty;
                                // objDepartment = (!String.IsNullOrEmpty(Convert.ToString(rdr["DEPARTMENT_HEAD"]))) ? Convert.ToString(rdr["DEPARTMENT_HEAD"]) : String.Empty;
                                objDepartment.modifiedBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["MODIFIED_BY"]))) ? Convert.ToString(rdr["MODIFIED_BY"]) : String.Empty;
                                objDepartment.modifiedBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["MODIFIEDON"]))) ? Convert.ToString(rdr["MODIFIEDON"]) : String.Empty;
                                objDepartment.operation = (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATION"]))) ? Convert.ToString(rdr["OPERATION"]) : String.Empty;
                                objDepartment.operation_Dt = (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATIONDT"]))) ? Convert.ToString(rdr["OPERATIONDT"]) : String.Empty;
                                lstDepartment.Add(objDepartment);
                            }
                            _departmentResponse.DepartmentList = lstDepartment;
                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }

        public DepartmentResponse GetUserDepartmentId(Department _department)
        {
            _departmentResponse = new DepartmentResponse();
            _departmentResponse.StatusFl = false;
            _departmentResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(_department.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_USER_DEPARTMENT_ID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_DEPARMENT_ID"));
                        cmd.Parameters.Add(new SqlParameter("@LOGIN_ID", _department.createdBy));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", _department.CompanyId));
                        // cmd.Parameters.Add(new SqlParameter("@CHECK", ""));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Department objDepartment;
                            while (rdr.Read())
                            {
                                objDepartment = new Department();
                                objDepartment.departmentId = Convert.ToInt32(rdr["DEPARTMENT_ID"]);
                                _departmentResponse.AddObject(objDepartment);
                            }

                            _departmentResponse.StatusFl = true;
                            _departmentResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _departmentResponse.StatusFl = false;
                _departmentResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentResponse;
        }
    }
}