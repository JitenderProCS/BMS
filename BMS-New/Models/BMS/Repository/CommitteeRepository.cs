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
    public class CommitteeRepository : IRequiresSessionState
    {
        private CommitteeResponse _committeeResponse;
        //private MeetingResponse _meetingResponse;
        private string connectionString = SQLHelper.GetConnString();
        private static String dataBaseName = SQLHelper.GetDBName();
        //private string database_name = "PROCS_BOARD_MEETING";

        //public CommitteeResponse SaveCommittee(Committee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(objCommittee.moduleDatabase);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "ADD_COMMITTEE_MEMBER1"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
        //                cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
        //                cmd.Parameters.Add(new SqlParameter("@COMMITTEE_NAME", objCommittee.committeeName));
        //                cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ABBR", objCommittee.committeeABRR));
        //                cmd.Parameters.Add(new SqlParameter("@NO_OF_MEMBER", objCommittee.NoOfMembers));
        //                cmd.Parameters.Add(new SqlParameter("@NO_OF_INDEPENDENT_DIRECTOR", objCommittee.NoOfIndependentDirector));
        //                cmd.Parameters.Add(new SqlParameter("@NO_OF_WOMEN_DIRECTOR", objCommittee.NoOfWomenDirector));
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
        //                cmd.ExecuteNonQuery();
        //                int obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
        //                if (obj == 0)
        //                {
        //                    _committeeResponse.StatusFl = false;
        //                    _committeeResponse.Msg = "Committee already exist !";
        //                    return _committeeResponse;
        //                }
        //                foreach (CommitteeMember objMember in objCommittee.committeeMembers)
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.CommandTimeout = 0;
        //                    cmd.Parameters.Clear();
        //                    cmd.Parameters.Add(new SqlParameter("@MODE", "ADD_COMMITTEE_MEMBERS"));
        //                    cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                    cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", obj));
        //                    cmd.Parameters.Add(new SqlParameter("@USER1_ID", objMember.UserLogin));
        //                    cmd.Parameters.Add(new SqlParameter("@SEQUENCE", objMember.Sequence));
        //                    cmd.Parameters.Add(new SqlParameter("@ROLE_ID", objMember.CommitteeRoleId));
        //                    cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
        //                    cmd.Parameters.Add(new SqlParameter("@SUPER_ADMIN_ID", objMember.CommitteeDesignationName));
        //                    cmd.ExecuteNonQuery();
        //                }
        //                _committeeResponse.StatusFl = true;
        //                _committeeResponse.Msg = "Data has been saved successfully !";
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _committeeResponse;
        //}

        public CommitteeResponse SaveCommittee(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "ADD_COMMITTEE_MEMBER1"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_NAME", objCommittee.committeeName));
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ABBR", objCommittee.committeeABRR));
                        cmd.Parameters.Add(new SqlParameter("@NO_OF_MEMBER", objCommittee.NoOfMembers));
                        cmd.Parameters.Add(new SqlParameter("@NO_OF_INDEPENDENT_DIRECTOR", objCommittee.NoOfIndependentDirector));
                        cmd.Parameters.Add(new SqlParameter("@NO_OF_WOMEN_DIRECTOR", objCommittee.NoOfWomenDirector));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        cmd.ExecuteNonQuery();
                        int obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (obj == 0)
                        {
                            _committeeResponse.StatusFl = false;
                            _committeeResponse.Msg = "Committee already exist !";
                            return _committeeResponse;
                        }
                        foreach (CommitteeMember objMember in objCommittee.committeeMembers)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "ADD_COMMITTEE_MEMBERS"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", Convert.ToInt32(obj)));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@USER1_ID", objMember.UserLogin));
                            cmd.Parameters.Add(new SqlParameter("@SEQUENCE", objMember.Sequence));
                            cmd.Parameters.Add(new SqlParameter("@ROLE_ID", objMember.CommitteeRoleId));
                            cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@SUPER_ADMIN_ID", objMember.CommitteeDesignationName));
                            cmd.ExecuteNonQuery();
                        }
                        _committeeResponse.StatusFl = true;
                        _committeeResponse.Msg = "Data has been saved successfully !";
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }




        public CommitteeResponse UpdateCommittee(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "UPDATE_COMMITTEE_MEMBER"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_NAME", objCommittee.committeeName));
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ABBR", objCommittee.committeeABRR));
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.Parameters.Add(new SqlParameter("@NO_OF_MEMBER", objCommittee.NoOfMembers));
                        cmd.Parameters.Add(new SqlParameter("@NO_OF_INDEPENDENT_DIRECTOR", objCommittee.NoOfIndependentDirector));
                        cmd.Parameters.Add(new SqlParameter("@NO_OF_WOMEN_DIRECTOR", objCommittee.NoOfWomenDirector));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        cmd.ExecuteNonQuery();
                        int obj = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        int admin = 0;
                        foreach (CommitteeMember objMember in objCommittee.committeeMembers)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "UPDATE_COMMITTEE_MEMBERS"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", obj));
                            cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@USER1_ID", objMember.UserLogin));
                            cmd.Parameters.Add(new SqlParameter("@SEQUENCE", objMember.Sequence));
                            cmd.Parameters.Add(new SqlParameter("@ROLE_ID", objMember.CommitteeRoleId));
                            cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@SUPER_ADMIN_ID", objMember.CommitteeDesignationName));
                            cmd.ExecuteNonQuery();
                            admin = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        }
                        if (obj > 0 && admin > 0)
                        {
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been updated successfully !";
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #region "Get Committee List" 

        public CommitteeResponse GetListCommittees(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);

                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEES_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        DataSet ds = new DataSet();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds);
                        }

                        DataTable dt = ds.Tables[0];
                        DataTable dtChairman = ds.Tables[1];
                        DataTable dtMembers = ds.Tables[2];
                        DataTable dtCoordinatorList = ds.Tables[3];
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                List<Committee> lstuser = new List<Committee>();
                                foreach (DataRow dr in dt.Rows)
                                {
                                    Committee o = new Committee();
                                    o.ID = Convert.ToInt32(dr["COMMITTEE_ID"]);
                                    o.committeeName = Convert.ToString(dr["COMMITTEE_NM"]);
                                    o.committeeABRR = Convert.ToString(dr["COMMITTEE_ABBR"]);
                                    o.NoOfMembers = Convert.ToInt32(dr["NO_OF_MEMBER"]);
                                    o.NoOfIndependentDirector = Convert.ToInt32(dr["NO_OF_INDEPENDENT_DIRECTOR"]);
                                    o.NoOfWomenDirector = Convert.ToInt32(dr["NO_OF_WOMEN_DIRECTOR"]);
                                    o.NoOfcommitteeMembers = Convert.ToString(dr["TotalMembers"]);
                                    o.CntIndependentDirector = Convert.ToString(dr["CNT_Independent_Director"]);
                                    o.CntWomenDirector = Convert.ToString(dr["CNT_WomenDirector"]);
                                    if (dtChairman.Rows.Count > 0)
                                    {
                                        List<CommitteeMember> committeeMembers = new List<CommitteeMember>();
                                        string committeeId = dr["COMMITTEE_ID"].ToString();
                                        DataRow[] chairmanRows = dtChairman.Select($"COMMITTEE_ID = {o.ID}");
                                        foreach (DataRow chairmanRow in chairmanRows)
                                        {
                                            CommitteeMember chairman = new CommitteeMember();
                                            chairman.ID = Convert.ToInt32(chairmanRow["COMMITTEE_ID"]);
                                            chairman.UserLogin = Convert.ToString(chairmanRow["USER_ID"]);
                                            chairman.UserNm = Convert.ToString(chairmanRow["USER_NM"]);
                                            chairman.UserEmail = Convert.ToString(chairmanRow["USER_EMAIL"]);
                                            chairman.Sequence = Convert.ToInt32(chairmanRow["Sequence"]);
                                            chairman.CommitteeRoleId = Convert.ToInt32(chairmanRow["COMMITTEE_ROLE_ID"]);
                                            chairman.CommitteeDesignationName = Convert.ToString(chairmanRow["COMMITTEE_ROLE"]);

                                            committeeMembers.Add(chairman);
                                        }

                                        //List<CommitteeMember> committeeMembers = new List<CommitteeMember>();
                                        //string committeeId = dr["COMMITTEE_ID"].ToString();

                                        // Add members from dtMembers
                                        DataRow[] membersRows = dtMembers.Select("COMMITTEE_ID = '" + committeeId + "'");
                                        foreach (DataRow memberRow in membersRows)
                                        {
                                            CommitteeMember member = new CommitteeMember();
                                            member.ID = Convert.ToInt32(memberRow["COMMITTEE_ID"]);
                                            member.UserLogin = Convert.ToString(memberRow["USER_ID"]);
                                            member.UserNm = Convert.ToString(memberRow["USER_NM"]);
                                            member.UserEmail = Convert.ToString(memberRow["USER_EMAIL"]);
                                            member.Sequence = Convert.ToInt32(memberRow["Sequence"]);
                                            member.CommitteeRoleId = Convert.ToInt32(memberRow["COMMITTEE_ROLE_ID"]);
                                            member.CommitteeDesignationName = Convert.ToString(memberRow["COMMITTEE_ROLE"]);
                                            committeeMembers.Add(member);
                                        }

                                        // Add members from dtCoordinatorList
                                        DataRow[] coordinatorRows = dtCoordinatorList.Select("COMMITTEE_ID = '" + committeeId + "'");
                                        foreach (DataRow coordinatorRow in coordinatorRows)
                                        {
                                            CommitteeMember coordinator = new CommitteeMember();
                                            coordinator.ID = Convert.ToInt32(coordinatorRow["COMMITTEE_ID"]);
                                            coordinator.UserLogin = Convert.ToString(coordinatorRow["USER_ID"]);
                                            coordinator.UserNm = Convert.ToString(coordinatorRow["USER_NM"]);
                                            coordinator.UserEmail = Convert.ToString(coordinatorRow["USER_EMAIL"]);
                                            coordinator.Sequence = Convert.ToInt32(coordinatorRow["Sequence"]);
                                            coordinator.CommitteeRoleId = Convert.ToInt32(coordinatorRow["COMMITTEE_ROLE_ID"]);
                                            coordinator.CommitteeDesignationName = Convert.ToString(coordinatorRow["COMMITTEE_ROLE"]);
                                            committeeMembers.Add(coordinator);
                                        }

                                        o.committeeMembers = committeeMembers;
                                    }
                                    lstuser.Add(o);

                                }

                                _committeeResponse.CommitteeList = lstuser;
                                _committeeResponse.StatusFl = true;
                                _committeeResponse.Msg = "Data has been fetched successfully !";
                            }
                        }
                        else
                        {
                            _committeeResponse.StatusFl = false;
                            _committeeResponse.Msg = "No data found !";
                        }

                        return _committeeResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }

            return _committeeResponse;
        }
        #endregion

        public CommitteeResponse GetCommittee(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEE_FOR_EDIT"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                       cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            Committee obj = new Committee();
                            while (rdr.Read())
                            {
                                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
                                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
                                obj.NoOfMembers = Convert.ToInt32(rdr["NO_OF_MEMBER"]);
                                obj.NoOfIndependentDirector = Convert.ToInt32(rdr["NO_OF_INDEPENDENT_DIRECTOR"]);
                                obj.NoOfWomenDirector = Convert.ToInt32(rdr["NO_OF_WOMEN_DIRECTOR"]);
                                //obj.committeeMembers = new CommitteeMember
                                //{
                                //    UserLogin = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_ID"]))) ? Convert.ToString(rdr["USER_ID"]) : String.Empty
                                //    UserNm = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty
                                //};
                                obj.CompanyId = objCommittee.CompanyId;
                                obj.moduleDatabase = objCommittee.moduleDatabase;
                                GetCommitteeMembers(obj);
                                _committeeResponse.AddObject(obj);
                            }
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        private Committee GetCommitteeMembers(Committee objCommittee)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "EDITUSER_COMMITTEES_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<User> lstUser = new List<User>();
                            while (rdr.Read())
                            {
                                User obj = new User();
                                //obj.ID = Convert.ToInt32(rdr["ID"]);
                                obj.userLogin = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_LOGIN"]))) ? Convert.ToString(rdr["USER_LOGIN"]) : String.Empty;
                                obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty;
                                obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty;
                                obj.role = new Role
                                {
                                    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty
                                };
                                obj.CHECKED = Convert.ToInt32(rdr["CHECKED"]);
                                lstUser.Add(obj);
                            }
                            objCommittee.committeeAdmins = lstUser;
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
            return objCommittee;
        }

        public CommitteeResponse DeleteCommittee(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "DELETE_COMMITTEE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        cmd.ExecuteNonQuery();
                        //int idd = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        //if (idd > 0)
                        //{
                        _committeeResponse.StatusFl = true;
                        _committeeResponse.Msg = "Data has been deleted successfully !";
                        //}
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }


        public CommitteeResponse GetCommitteesMembers(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITEE_MEMBERS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_MEMBERS_FOR_MEETING"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<User> lstUser = new List<User>();
                            while (rdr.Read())
                            {
                                User obj = new User();
                                obj.ID = Convert.ToInt32(rdr["USER_ID"]);
                                obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["NAME"]))) ? Convert.ToString(rdr["NAME"]) : String.Empty;
                                obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["EMAIL_ID"]))) ? Convert.ToString(rdr["EMAIL_ID"]) : String.Empty;
                                obj.uploadAvatar = (!String.IsNullOrEmpty(Convert.ToString(rdr["UPLOAD_AVATAR"]))) ? Convert.ToString(rdr["UPLOAD_AVATAR"]) : String.Empty;
                                //obj.role = new Role
                                //{
                                //    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_ROLE"]))) ? Convert.ToString(rdr["USER_ROLE"]) : String.Empty
                                //};
                                lstUser.Add(obj);
                            }
                            objCommittee.committeeAdmins = lstUser;
                            _committeeResponse.AddObject(objCommittee);
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        public CommitteeResponse GetCommitteesMembersForAdmin(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_USER_FOR_DIRECTOR"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<User> lstUser = new List<User>();
                            while (rdr.Read())
                            {
                                User obj = new User();
                                obj.ID = Convert.ToInt32(rdr["ID"]);
                                obj.userLogin = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_LOGIN"]))) ? Convert.ToString(rdr["USER_LOGIN"]) : String.Empty;
                                obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["NAME"]))) ? Convert.ToString(rdr["NAME"]) : String.Empty;
                                obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["EMAIL_ID"]))) ? Convert.ToString(rdr["EMAIL_ID"]) : String.Empty;
                                obj.role = new Role
                                {
                                    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty
                                };
                                lstUser.Add(obj);
                            }
                            objCommittee.committeeAdmins = lstUser;
                            _committeeResponse.AddObject(objCommittee);
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        public CommitteeResponse CommitteeCoordinatorUserList(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEE_COORDINATOR_USER"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<User> lstUser = new List<User>();
                            while (rdr.Read())
                            {
                                User obj = new User();
                                obj.ID = Convert.ToInt32(rdr["ID"]);
                                obj.userLogin = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_LOGIN"]))) ? Convert.ToString(rdr["USER_LOGIN"]) : String.Empty;
                                obj.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["NAME"]))) ? Convert.ToString(rdr["NAME"]) : String.Empty;
                                obj.emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["EMAIL_ID"]))) ? Convert.ToString(rdr["EMAIL_ID"]) : String.Empty;
                                obj.role = new Role
                                {
                                    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty
                                };
                                lstUser.Add(obj);
                            }
                            objCommittee.committeeAdmins = lstUser;
                            _committeeResponse.AddObject(objCommittee);
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        public CommitteeResponse GetCommitteesRole(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEE_ROLE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<CommitteeRole> lstUser = new List<CommitteeRole>();
                            while (rdr.Read())
                            {
                                CommitteeRole obj = new CommitteeRole();
                                obj.Id = Convert.ToInt32(rdr["ID"]);
                                obj.committeerole = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ROLE"]))) ? Convert.ToString(rdr["COMMITTEE_ROLE"]) : String.Empty;
                                //obj.role = new Role
                                //{
                                //    role = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty
                                //};
                                lstUser.Add(obj);
                            }
                            objCommittee.committeerole = lstUser;
                            _committeeResponse.AddObject(objCommittee);
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        public CommitteeResponse BindCommittee(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Committee obj = new Committee();
                                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
                                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
                                _committeeResponse.AddObject(obj);
                            }
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        public CommitteeResponse GetCommitteeHistory(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No Data Found!";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEE_FOR_HISTORY"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<CommitteeMember> lstMember = new List<CommitteeMember>();
                            while (rdr.Read())
                            {
                                CommitteeMember obj = new CommitteeMember();
                                objCommittee.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                //obj.version = Convert.ToInt32(rdr["VERSION_ID"]);
                                obj.Operation= (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATION"]))) ? Convert.ToString(rdr["OPERATION"]) : String.Empty;
                               // obj.operation_Dt = (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATION_DT"]))) ? Convert.ToString(Convert.ToDateTime(rdr["OPERATION_DT"]).ToString("dd/MM/yyyy")) : String.Empty;
                                obj.Sequence = Convert.ToInt32(rdr["SEQUENCE"]);
                                obj.modifiedBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATE_BY"]))) ? Convert.ToString(rdr["CREATE_BY"]) : String.Empty;
                                obj.createdon = (!String.IsNullOrEmpty(Convert.ToString(rdr["UPDATED_ON"]))) ? Convert.ToString(Convert.ToDateTime(rdr["UPDATED_ON"]).ToString("dd/MM/yyyy")) : String.Empty;
                                obj.UserLogin = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_ID"]))) ? Convert.ToString(rdr["USER_ID"]) : String.Empty;
                                obj.UserNm = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty;
                                obj.UserEmail = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]): String.Empty;
                                obj.CommitteeRoleId= Convert.ToInt32(rdr["ID"]);
                                obj.CommitteeDesignationName= (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ROLE"]))) ? Convert.ToString(rdr["COMMITTEE_ROLE"]) : String.Empty;
                                obj.committeeModifiedDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_MODIFIED_DATE"]))) ? (Convert.ToString(rdr["COMMITTEE_MODIFIED_DATE"]) == "1900-01-01 00:00:00.000" ? "" : Convert.ToString(Convert.ToDateTime(rdr["COMMITTEE_MODIFIED_DATE"]).ToString("dd/MM/yyyy"))) : String.Empty;
                               // obj.remarks = (!String.IsNullOrEmpty(Convert.ToString(rdr["REMARKS"]))) ? Convert.ToString(rdr["REMARKS"]) : String.Empty;
                                lstMember.Add(obj);
                            }
                            objCommittee.committeeMembers = lstMember;
                            _committeeResponse.Committee = objCommittee;
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been fetched successfully !";
                        }
                        rdr.Close();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _committeeResponse = new CommitteeResponse();
                _committeeResponse.StatusFl = false;
                _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }
    }
}