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
    public class DesignationRepository : IRequiresSessionState
    {
        private DesignationResponse _designationResponse;
        private string connectionString = SQLHelper.GetConnString();

        public DesignationResponse AddDesignation(Designation objDesignation)
        {
            _designationResponse = new DesignationResponse();
            _designationResponse.StatusFl = false;
            _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objDesignation.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_DESIGNATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "INSERT"));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", 1));
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
                            //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", 1));
                            cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", objDesignation.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@DESIGNATION_NAME", objDesignation.designationName));
                            cmd.ExecuteNonQuery();
                            objDesignation.ID = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                            _designationResponse.StatusFl = true;
                            _designationResponse.Msg = "Data has been saved successfully !";
                            _designationResponse.Designation = objDesignation;
                        }
                        else
                        {
                            _designationResponse.StatusFl = false;
                            _designationResponse.Msg = "Designation Name aleady exists !";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _designationResponse = new DesignationResponse();
                _designationResponse.StatusFl = false;
                _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
               // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _designationResponse;
        }

        public DesignationResponse UpdateDesignation(Designation objDesignation)
        {
            _designationResponse = new DesignationResponse();
            _designationResponse.StatusFl = false;
            _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objDesignation.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_DESIGNATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@Mode", "CHECK"));
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", 1));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@DESIGNATION_NAME", objDesignation.designationName));
                        cmd.Parameters.Add(new SqlParameter("@ID", objDesignation.ID));
                        cmd.ExecuteNonQuery();
                        Int32 obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (obj == 0)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "INSERT_UPDATE"));
                            cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "UPDATE"));
                            //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", 1));
                            cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", objDesignation.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@DESIGNATION_NAME", objDesignation.designationName));
                            cmd.Parameters.Add(new SqlParameter("@ID", objDesignation.ID));
                            cmd.ExecuteNonQuery();
                            objDesignation.ID = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                            _designationResponse.StatusFl = true;
                            _designationResponse.Msg = "Data has been updated successfully !";
                            _designationResponse.Designation = objDesignation;
                        }
                        else
                        {
                            _designationResponse.StatusFl = false;
                            _designationResponse.Msg = "Designation Name aleady exists !";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _designationResponse = new DesignationResponse();
                _designationResponse.StatusFl = false;
                _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
               // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _designationResponse;
        }

        //public DesignationResponse DeleteDesignation(Designation objDesignation)
        //{
        //    _designationResponse = new DesignationResponse();
        //    _designationResponse.StatusFl = false;
        //    _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(objDesignation.moduleDatabase);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_DESIGNATION", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@Mode", "DELETE_DESIGNATION"));
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@ID", objDesignation.ID));
        //                cmd.ExecuteNonQuery();
        //                _designationResponse.StatusFl = true;
        //                _designationResponse.Msg = "Data has been deleted successfully !";
        //                _designationResponse.Designation = objDesignation;
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _designationResponse = new DesignationResponse();
        //        _designationResponse.StatusFl = false;
        //        _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _designationResponse;
        //}

        public DesignationResponse GetDesignationList(Designation objDesignation)
        {
            _designationResponse = new DesignationResponse();
            _designationResponse.StatusFl = false;
            _designationResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
             
                    conn.ChangeDatabase(objDesignation.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_DESIGNATION", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_DESIGNATION_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID",1));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Designation obj = new Designation();
                                obj.ID = Convert.ToInt32(rdr["ID"]);
                                obj.designationName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DESIGNATION_NAME"]))) ? Convert.ToString(rdr["DESIGNATION_NAME"]) : String.Empty;
                                obj.createdBy = Convert.ToString(rdr["CREATE_BY"]);
                                obj.createdOn = Convert.ToString(rdr["CREATED_ON"]);
                                obj.companyId = Convert.ToInt32(rdr["COMPANY_ID"]);
                                _designationResponse.AddObject(obj);
                            }
                            _designationResponse.StatusFl = true;
                            _designationResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _designationResponse = new DesignationResponse();
                _designationResponse.StatusFl = false;
                _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
               // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _designationResponse;
        }

        //public DesignationResponse GetDesignation(Designation objDesignation)
        //{
        //    _designationResponse = new DesignationResponse();
        //    _designationResponse.StatusFl = false;
        //    _designationResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            //conn.ChangeDatabase(objDesignation.moduleDatabase);
        //            conn.ChangeDatabase("PROCS_BOARD_MEETING");

        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_DESIGNATION", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_DESIGNATION_FOR_USER_MASTER"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        Designation obj = new Designation();
        //                        obj.ID = Convert.ToInt32(rdr["ID"]);
        //                        obj.designationName = Convert.ToString(rdr["DESIGNATION_NAME"]);
        //                        _designationResponse.AddObject(obj);
        //                    }
        //                    _designationResponse.StatusFl = true;
        //                    _designationResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _designationResponse = new DesignationResponse();
        //        _designationResponse.StatusFl = false;
        //        _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //       // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _designationResponse;
        //}

        //public DesignationResponse GetCategory(Category objCategory)
        //{
        //    _designationResponse = new DesignationResponse();
        //    _designationResponse.StatusFl = false;
        //    _designationResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(objCategory.moduleDatabase);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_DESIGNATION", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_CATEGORY_FOR_USER_MASTER"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCategory.companyId));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    Category obj = null;
        //                    List<Category> lstCategory = new List<Category>();
        //                    while (rdr.Read())
        //                    {
        //                        obj = new Category();
        //                        obj.ID = Convert.ToInt32(rdr["CATEGORY_ID"]);
        //                        obj.categoryName = Convert.ToString(rdr["CATEGORY_NAME"]);
        //                        lstCategory.Add(obj);
        //                    }
        //                    _designationResponse.CategoryList = new List<Category>();
        //                    _designationResponse.CategoryList = lstCategory;
        //                    _designationResponse.StatusFl = true;
        //                    _designationResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _designationResponse = new DesignationResponse();
        //        _designationResponse.StatusFl = false;
        //        _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _designationResponse;
        //}

        #region "Date Conversion"

        //private DateTime ConvertDate(String date)
        //{
        //    String str = String.Empty;
        //    try
        //    {
        //        if (date.Contains("/"))
        //        {
        //            str = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }

        //    return Convert.ToDateTime(str);
        //}

        #endregion
        //public DesignationResponse getDesignationAuditRecord(Designation objDesignation)
        //{
        //    _designationResponse = new DesignationResponse();
        //    _designationResponse.StatusFl = false;
        //    _designationResponse.Msg = "No Data Found!";
        //    List<Designation> lstDesignation = new List<Designation>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(objDesignation.moduleDatabase);
        //            using (SqlCommand cmd = new SqlCommand("USP_BMS_AUDIT_REPORT_ALL", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "DESIGNATION"));
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objDesignation.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@FROMDATE", ConvertDate(objDesignation.fromDate)));
        //                cmd.Parameters.Add(new SqlParameter("@TODATE", ConvertDate(objDesignation.toDate)));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        Designation obj = new Designation();
        //                        obj.ID = Convert.ToInt32(rdr["ID"]);
        //                        obj.designationName = Convert.ToString(rdr["DESIGNATION_NAME"]);
        //                        obj.createdBy = Convert.ToString(rdr["CREATE_BY"]);
        //                        obj.createdOn = Convert.ToString(rdr["CREATEDON"]);
        //                        obj.modifiedBy = Convert.ToString(rdr["UPDATED_BY"]);
        //                        obj.modifiedOn = Convert.ToString(rdr["UPDATEDON"]);
        //                        obj.operation = Convert.ToString(rdr["OPERATION"]);
        //                        obj.operation_Dt = Convert.ToString(rdr["OPERATIONDT"]);
        //                        lstDesignation.Add(obj);
        //                    }
        //                    _designationResponse.DesignationList = lstDesignation;
        //                    _designationResponse.StatusFl = true;
        //                    _designationResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _designationResponse = new DesignationResponse();
        //        _designationResponse.StatusFl = false;
        //        _designationResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _designationResponse;
        //}
    }
}