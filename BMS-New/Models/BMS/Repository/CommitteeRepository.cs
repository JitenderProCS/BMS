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
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
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
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", obj));
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
                       // cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
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

        //public CommitteeResponse GetListCommittees(Committee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
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
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEES_LIST"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.CompanyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    List<Committee> lstUser = new List<Committee>();
        //                    while (rdr.Read())
        //                    {
        //                        Committee obj = new Committee();
        //                        obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
        //                        obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        obj.NoOfMembers = Convert.ToInt32(rdr["NO_OF_MEMBER"]);
        //                        obj.NoOfIndependentDirector = Convert.ToInt32(rdr["NO_OF_INDEPENDENT_DIRECTOR"]);
        //                        obj.NoOfWomenDirector = Convert.ToInt32(rdr["NO_OF_WOMEN_DIRECTOR"]);
        //                        obj.NoOfcommitteeMembers = (!String.IsNullOrEmpty(Convert.ToString(rdr["TotalMembers"]))) ? Convert.ToString(rdr["TotalMembers"]) : String.Empty;
        //                        //obj.NoOfIndependentDirector = Convert.ToInt32(rdr["CNT_Independent_Director"]);
        //                        //obj.NoOfWomenDirector = Convert.ToInt32(rdr["CNT_WomenDirector"]);
        //                        obj.CntIndependentDirector = (!String.IsNullOrEmpty(Convert.ToString(rdr["CNT_Independent_Director"]))) ? Convert.ToString(rdr["CNT_Independent_Director"]) : String.Empty;
        //                        obj.CntWomenDirector = (!String.IsNullOrEmpty(Convert.ToString(rdr["CNT_WomenDirector"]))) ? Convert.ToString(rdr["CNT_WomenDirector"]) : String.Empty;
        //                        //obj.isDelete = Convert.ToInt32(rdr["IS_EXISTS"]);
        //                        _committeeResponse.AddObject(obj);
        //                    }
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
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
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
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

        public CommitteeResponse DeleteCommittee_CheckMeeting(Committee objCommittee)
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "DELETE_COMMITTEE_CHECK_MEETING"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (Convert.ToInt32(rdr["COUNT"]) > 0)
                                {
                                    _committeeResponse.StatusFl = true;
                                    _committeeResponse.Msg = "Meeting exits for the selected Committee. Operation can't be completed!";
                                }
                            }
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

        public CommitteeResponse SaveCommitteeComposition(Committee objCommittee)
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "VALIDATE_IF_COMMITTEE_COMPOSITION_EXISTS"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        Int32 isExists = Convert.ToInt32(cmd.ExecuteScalar());
                        //if (isExists == 0)
                        //{
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "ADD_COMMITTEE_MEMBER_DELETE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        cmd.ExecuteNonQuery();

                        foreach (CommitteeMember objCM in objCommittee.committeeMembers)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "ADD_COMMITTEE_MEMBER"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                            //cmd.Parameters.Add(new SqlParameter("@USER1_ID", objCM.member.ID));
                            //cmd.Parameters.Add(new SqlParameter("@DESIGNATION_ID", objCM.designation.ID));
                            cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                           // cmd.Parameters.Add(new SqlParameter("@SEQUENCE", objCM.sequence));
                            //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                            cmd.ExecuteNonQuery();
                        }

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BMS_COMMITTEE_MEMBERS_ARCHIVAL_HDR"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        cmd.Parameters.Add(new SqlParameter("@REMARKS", objCommittee.remarks));
                        if (!String.IsNullOrEmpty(Convert.ToString(objCommittee.committeeModifiedDate)))
                        {
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEE_MODIFIED_DATE", ConvertDate(objCommittee.committeeModifiedDate)));
                        }
                        cmd.ExecuteNonQuery();
                        var VER = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);

                        foreach (CommitteeMember objCM in objCommittee.committeeMembers)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("@MODE", "BMS_COMMITTEE_MEMBERS_ARCHIVAL_DETL"));
                            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                           // cmd.Parameters.Add(new SqlParameter("@USER1_ID", objCM.member.ID));
                           // cmd.Parameters.Add(new SqlParameter("@DESIGNATION_ID", objCM.designation.ID));
                            cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                            cmd.Parameters.Add(new SqlParameter("@VERSION_NO", Convert.ToInt32(VER)));
                            //cmd.Parameters.Add(new SqlParameter("@SEQUENCE", objCM.sequence));
                            //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                            cmd.ExecuteNonQuery();
                        }
                        _committeeResponse.StatusFl = true;
                        _committeeResponse.Msg = "Data has been saved successfully !";
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

        public CommitteeResponse GetListCommitteesComposition(Committee objCommittee)
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEES_COMPOSITION_LIST"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                       // cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<Committee> lstUser = new List<Committee>();
                            while (rdr.Read())
                            {
                                Committee obj = new Committee();
                                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
                                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                obj.NoOfcommitteeMembers = (!String.IsNullOrEmpty(Convert.ToString(rdr["MEMBERS"]))) ? Convert.ToString(rdr["MEMBERS"]) : String.Empty;
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

        public CommitteeResponse GetCommitteeCompositionEdit(Committee objCommittee)
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEE__COMPOSITION_FOR_EDIT"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<CommitteeMember> lstMember = new List<CommitteeMember>();
                            while (rdr.Read())
                            {
                                CommitteeMember obj = new CommitteeMember();
                                objCommittee.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                //obj.sequence = Convert.ToInt32(rdr["SEQUENCE"]);
                                //obj.member = new User
                                //{
                                //    ID = Convert.ToInt32(rdr["USER_ID"]),
                                //    userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty,
                                //    emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty
                                //};
                                //obj.designation = new Designation
                                //{
                                //    ID = Convert.ToInt32(rdr["DESIGNATION_ID"]),
                                //    designationName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DESIGNATION_NAME"]))) ? Convert.ToString(rdr["DESIGNATION_NAME"]) : String.Empty

                                //};
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

        public CommitteeResponse GetCommitteeCompositionHistory(Committee objCommittee)
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEE__COMPOSITION_FOR_HISTORY"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            List<CommitteeMember> lstMember = new List<CommitteeMember>();
                            while (rdr.Read())
                            {
                                CommitteeMember obj = new CommitteeMember();
                                objCommittee.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                obj.version = Convert.ToInt32(rdr["VERSION_ID"]);
                                //obj.sequence = Convert.ToInt32(rdr["SEQUENCE"]);
                                obj.modifiedBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATED_BY"]))) ? Convert.ToString(rdr["CREATED_BY"]) : String.Empty;
                                obj.createdon = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATED_ON"]))) ? Convert.ToString(Convert.ToDateTime(rdr["CREATED_ON"]).ToString("dd/MM/yyyy")) : String.Empty;
                                //obj.member = new User
                                //{
                                //    ID = Convert.ToInt32(rdr["USER_ID"]),
                                //    userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty,
                                //    emailId = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty
                                //};
                                //obj.designation = new Designation
                                //{
                                //    ID = Convert.ToInt32(rdr["DESIGNATION_ID"]),
                                //    designationName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DESIGNATION_NAME"]))) ? Convert.ToString(rdr["DESIGNATION_NAME"]) : String.Empty

                                //};
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

        public CommitteeResponse DeleteCommitteecomposition(Committee objCommittee)
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "ADD_COMMITTEE_MEMBER_DELETE"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new SqlParameter("@COMMITTEE_ID", objCommittee.ID));
                        cmd.ExecuteNonQuery();
                        Int32 idd = Convert.ToInt32(cmd.Parameters["@SET_COUNT"].Value);
                        if (idd == 0)
                        {
                            _committeeResponse.StatusFl = true;
                            _committeeResponse.Msg = "Data has been Deleted successfully !";
                        }
                        else
                        {
                            _committeeResponse.StatusFl = false;
                            _committeeResponse.Msg = "Composition cannot be deleted as Meeting exists for the same !";
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

        #region "Bind Committee For Composition"

        //public CommitteeResponse BindCommitteeForComposition(Committee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No data found !";
        //    try
        //    {
        //        SqlParameter[] parameters = new SqlParameter[4];
        //        parameters[0] = new SqlParameter("@MODE", "BIND_COMMITTEES_FOR_COMPOSITION");
        //        parameters[1] = new SqlParameter("@SET_COUNT", SqlDbType.Int);
        //        parameters[2] = new SqlParameter("@COMPANY_ID", objCommittee.companyId);
        //        parameters[3] = new SqlParameter("@USER_ID", objCommittee.createdBy);
        //        parameters[1].Direction = ParameterDirection.Output;
        //        SqlDataReader rdr = SQLHelper.ExecuteReader(SQLHelper.GetConnString(), CommandType.StoredProcedure, "SP_PROCS_BMS_COMMITTEE", objCommittee.moduleDatabase, parameters);
        //        if (rdr.HasRows)
        //        {
        //            while (rdr.Read())
        //            {
        //                Committee obj = new Committee();
        //                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
        //                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                _committeeResponse.AddObject(obj);
        //            }
        //            _committeeResponse.StatusFl = true;
        //            _committeeResponse.Msg = "Data has been fetched successfully !";
        //        }
        //        rdr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Processing failed, because of system error !";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }
        //    return _committeeResponse;
        //}

        #endregion

        #region "Bind All Committee"

        public CommitteeResponse BindAllCommittee(Committee objCommittee)
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
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_ALL_COMMITTEES"));
                        cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Committee obj = new Committee();
                                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
                                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
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

        #endregion

        #region "Get Circular Resolution Member Repository For API"

        //public CommitteeResponse GetAPICRMemberRepository(APICRLibraryCommittee objCRLibraryCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        string applicationPath = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ApplicationURL"].ToString(), true);
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_CR", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_CR_MEMBERS_REPOSITORY_FOR_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@CR_ID", objCRLibraryCommittee.crId));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    List<APICRMemberCommittee> listCRMemberCommittee = new List<APICRMemberCommittee>();
        //                    APICRMemberCommittee objCRMemberCommittee;
        //                    while (rdr.Read())
        //                    {
        //                        objCRMemberCommittee = new APICRMemberCommittee();
        //                        objCRMemberCommittee.crMemberId = (!String.IsNullOrEmpty(Convert.ToString(rdr["BMS_CR_MEMBERS_ID"]))) ? Convert.ToInt32(rdr["BMS_CR_MEMBERS_ID"]) : 0;
        //                        objCRMemberCommittee.userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty;
        //                        objCRMemberCommittee.userEmail = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_EMAIL"]))) ? Convert.ToString(rdr["USER_EMAIL"]) : String.Empty;
        //                        objCRMemberCommittee.userRole = (!String.IsNullOrEmpty(Convert.ToString(rdr["ROLE"]))) ? Convert.ToString(rdr["ROLE"]) : String.Empty;
        //                        objCRMemberCommittee.status = (!String.IsNullOrEmpty(Convert.ToString(rdr["STATUS"]))) ? Convert.ToString(rdr["STATUS"]) : String.Empty;
        //                        objCRMemberCommittee.reviewedOn = (!String.IsNullOrEmpty(Convert.ToString(rdr["REVIEWED_ON"]))) ? Convert.ToString(rdr["REVIEWED_ON"]) : String.Empty;
        //                        objCRMemberCommittee.comments = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMUNICATION_COMMENTS"]))) ? Convert.ToString(rdr["COMMUNICATION_COMMENTS"]) : String.Empty;
        //                        objCRMemberCommittee.lstCommunicationAttachments = GetCRMemberCommunicationAttachments(objCRMemberCommittee.crMemberId);
        //                        listCRMemberCommittee.Add(objCRMemberCommittee);
        //                    }
        //                    _committeeResponse.APICRMemberCommitteeList = listCRMemberCommittee;
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
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

        #endregion

        #region "Get CR Member Communication Attachments"

        //private List<string> GetCRMemberCommunicationAttachments(Int32 crMemberId)
        //{
        //    List<string> lstCrMemberCommunicationAttachments = new List<string>();
        //    string applicationPath = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ApplicationURL"].ToString(), true);
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        conn.ChangeDatabase(dataBaseName);
        //        using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_CR", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 0;
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.Add(new SqlParameter("@MODE", "GET_CR_MEMBERS_REPOSITORY_FOR_API"));
        //            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(new SqlParameter("@BMS_CR_MEMBER_ID", crMemberId));
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            if (rdr.HasRows)
        //            {
        //                while (rdr.Read())
        //                {
        //                    string fileName = (!String.IsNullOrEmpty(Convert.ToString(rdr["FILE_NAME"]))) ? applicationPath + @"BoardMeeting/emailAttachment/" + Convert.ToString(rdr["FILE_NAME"]) : String.Empty;
        //                    lstCrMemberCommunicationAttachments.Add(fileName);
        //                }
        //            }
        //            rdr.Close();
        //        }
        //        conn.Close();
        //    }
        //    return lstCrMemberCommunicationAttachments;
        //}

        #endregion

        #region "Get Members Count"

        //private APICRLibraryCommittee GetCRMembersCount(Int32 crId)
        //{
        //    APICRLibraryCommittee objCRLibraryCommittee = new APICRLibraryCommittee(); ;
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        conn.ChangeDatabase(dataBaseName);
        //        using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_CR", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 0;
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.Add(new SqlParameter("@MODE", "GET_CR_MEMBERS_COUNT_OF_EVERY_STATUS_FOR_API"));
        //            cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(new SqlParameter("@CR_ID", crId));
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            if (rdr.HasRows)
        //            {
        //                while (rdr.Read())
        //                {
        //                    objCRLibraryCommittee.assentedMembersCount = (!String.IsNullOrEmpty(Convert.ToString(rdr["ASSENTED_MEMBERS_COUNT"]))) ? Convert.ToInt32(rdr["ASSENTED_MEMBERS_COUNT"]) : 0;
        //                    objCRLibraryCommittee.dissentedMembersCount = (!String.IsNullOrEmpty(Convert.ToString(rdr["DISSENTED_MEMBERS_COUNT"]))) ? Convert.ToInt32(rdr["DISSENTED_MEMBERS_COUNT"]) : 0;
        //                    objCRLibraryCommittee.abstainedMembersCount = (!String.IsNullOrEmpty(Convert.ToString(rdr["ABSTAINED_MEMBERS_COUNT"]))) ? Convert.ToInt32(rdr["ABSTAINED_MEMBERS_COUNT"]) : 0;
        //                    objCRLibraryCommittee.notYetVotedMembersCount = (!String.IsNullOrEmpty(Convert.ToString(rdr["NOT_YET_VOTED_MEMBERS_COUNT"]))) ? Convert.ToInt32(rdr["NOT_YET_VOTED_MEMBERS_COUNT"]) : 0;
        //                }
        //            }
        //            rdr.Close();
        //        }
        //        conn.Close();
        //    }
        //    return objCRLibraryCommittee;
        //}

        #endregion

        #region "Bind Committee For Draft MOM Library"

        public CommitteeResponse BindCommitteeForDraftMOM(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_FOR_DRAFT_MOM"));
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion                       

        #region "Bind Committee For Final MOM Library"

        public CommitteeResponse BindCommitteeForFinalMOM(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_FOR_FINAL_MOM"));
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion                       

        #region "Bind Committee For Meeting Attendance Report"

        public CommitteeResponse BindCommitteeForMeetingAttendanceReport(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_FOR_MEETING_ATTENDANCE_REPORT"));
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion                       

        #region "Bind Committee For Composition Attendance Report"

        public CommitteeResponse BindCommitteeForCompositionReport(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_FOR_COMPOSITION_REPORT"));
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion                       

        #region "Mobile Sync API Methods"

        #region "Bind Committee"

        //public CommitteeResponse BindAPISyncCommittee(APICommittee objCommittee, APIUser objAPIUser)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No data found !";
        //    _meetingResponse = new MeetingResponse();
        //    MeetingRepository meetingRepo = new MeetingRepository();
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
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_API_SYNC_COMMITTEES"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
        //                cmd.Parameters.Add(new SqlParameter("@XML_DATA", ConvertAPIDataToXML(objAPIUser.UAccess)));
        //                cmd.Parameters.Add(new SqlParameter("@FDF_SYNC_DATE", objAPIUser.fdfSyncDate));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        APICommittee obj = new APICommittee();
        //                        obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
        //                        obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        obj.companyId = objCommittee.companyId;
        //                        obj.createdBy = objCommittee.createdBy;
        //                        obj.moduleDatabase = objCommittee.moduleDatabase;
        //                        meetingRepo.GetSyncBMSMeetingListAPI(obj, objAPIUser);
        //                        _committeeResponse.AddObject(obj);
        //                    }
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //                //ConvertAPIDataToXML(objAPIUser.UAccess);
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message, ex.Source, ex.StackTrace, "MobileAPI", "BindAPISyncCommittee", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        //public APIUser GetCommitteeCompositionForMobileApp(APIUser objAPIUser)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMPOSITION_FOR_MOBILE_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objAPIUser.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", objAPIUser.LoginId));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    List<CommitteeComposition> lstCommittee = new List<CommitteeComposition>();
        //                    CommitteeComposition obj = null;
        //                    while (rdr.Read())
        //                    {
        //                        obj = new CommitteeComposition();
        //                        obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        lstCommittee.Add(obj);
        //                    }

        //                    if (lstCommittee.Count > 0)
        //                    {
        //                        objAPIUser.lstCommiteeComposition = lstCommittee;
        //                    }
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message, ex.Source, ex.StackTrace, "MobileAPI CommitteeRepository", "GetCommitteeCompositionForMobileApp", objAPIUser.LoginId, 1, objAPIUser.companyId);
        //    }
        //    return objAPIUser;
        //}

        #endregion

        #region "Convert Object into XML"

        //private String ConvertAPIDataToXML(List<APIUserAccess> lstUAccess)
        //{
        //    String xmlStr = String.Empty;
        //    try
        //    {
        //        xmlStr += "<SYNCDATA>";
        //        foreach (APIUserAccess objUAccess in lstUAccess)
        //        {
        //            if (objUAccess.committeeList != null)
        //            {
        //                if (objUAccess.committeeList.Count > 0)
        //                {
        //                    foreach (APICommittee objCommittee in objUAccess.committeeList)
        //                    {
        //                        if (objCommittee.listMeeting != null)
        //                        {
        //                            if (objCommittee.listMeeting.Count > 0)
        //                            {
        //                                foreach (APIMeeting objMeeting in objCommittee.listMeeting)
        //                                {
        //                                    if (objMeeting.agendaItems != null)
        //                                    {
        //                                        if (objMeeting.agendaItems.Count > 0)
        //                                        {
        //                                            foreach (APIAgendaItems objAgenda in objMeeting.agendaItems)
        //                                            {
        //                                                xmlStr += "<COMPANY>";
        //                                                xmlStr += "<COMPANYID>" + objUAccess.CompanyId + "</COMPANYID>";
        //                                                xmlStr += "<COMMITTEEID>" + objCommittee.ID + "</COMMITTEEID>";
        //                                                xmlStr += "<MEETINGID>" + objMeeting.ID + "</MEETINGID>";
        //                                                xmlStr += "<AGENDAID>" + objAgenda.ID + "</AGENDAID>";
        //                                                xmlStr += "<SYNCDATE>" + objAgenda.syncDate + "</SYNCDATE>";
        //                                                xmlStr += "</COMPANY>";
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        xmlStr += "</SYNCDATA>";
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //    }

        //    return xmlStr;
        //}

        #endregion

        #region "Get Draft MOM Repository For API"

        //public CommitteeResponse GetAPIDraftMOMRepository(APICommittee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        string applicationPath = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ApplicationURL"].ToString(), true);
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_MEETING_MOM", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_DRAFT_MOM_FOR_WEB_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", objCommittee.createdBy));
        //                if (String.IsNullOrEmpty(objCommittee.fileSyncDate))
        //                {
        //                    cmd.Parameters.Add(new SqlParameter("@FILE_SYNC_DATE", "NULL"));
        //                }
        //                else
        //                {
        //                    cmd.Parameters.Add(new SqlParameter("@FILE_SYNC_DATE", objCommittee.fileSyncDate));
        //                }
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    List<APIDraftMOMCommittee> listDraftMOMCommittee = new List<APIDraftMOMCommittee>();
        //                    APIDraftMOMCommittee objDraftMOMCommittee;
        //                    while (rdr.Read())
        //                    {
        //                        objDraftMOMCommittee = new APIDraftMOMCommittee();
        //                        objDraftMOMCommittee.ID = (!String.IsNullOrEmpty(Convert.ToString(rdr["ID"]))) ? Convert.ToInt32(rdr["ID"]) : 0;
        //                        objDraftMOMCommittee.companyId = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMPANY_ID"]))) ? Convert.ToInt32(rdr["COMPANY_ID"]) : 0;
        //                        objDraftMOMCommittee.taskId = (!String.IsNullOrEmpty(Convert.ToString(rdr["TASK_ID"]))) ? Convert.ToInt32(rdr["TASK_ID"]) : 0;
        //                        objDraftMOMCommittee.draftMOMId = (!String.IsNullOrEmpty(Convert.ToString(rdr["DRAFT_MOM_ID"]))) ? Convert.ToInt32(rdr["DRAFT_MOM_ID"]) : 0;
        //                        objDraftMOMCommittee.committeeId = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ID"]))) ? Convert.ToInt32(rdr["COMMITTEE_ID"]) : 0;
        //                        objDraftMOMCommittee.meetingId = (!String.IsNullOrEmpty(Convert.ToString(rdr["MEETING_ID"]))) ? Convert.ToInt32(rdr["MEETING_ID"]) : 0;
        //                        objDraftMOMCommittee.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NAME"]))) ? Convert.ToString(rdr["COMMITTEE_NAME"]) : String.Empty;
        //                        objDraftMOMCommittee.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        objDraftMOMCommittee.meetingTitle = (!String.IsNullOrEmpty(Convert.ToString(rdr["MEETING_TITLE"]))) ? Convert.ToString(rdr["MEETING_TITLE"]) : String.Empty;
        //                        objDraftMOMCommittee.meetingDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["MEETING_DATE"]))) ? Convert.ToString(Convert.ToDateTime(rdr["MEETING_DATE"]).ToString("dd/MM/yyyy")) : String.Empty;
        //                        if (!String.IsNullOrEmpty(Convert.ToString(rdr["MOM_FILE"])))
        //                        {
        //                            String newFileName = Convert.ToString(rdr["MOM_FILE"]);
        //                            if (System.IO.Path.GetExtension(Convert.ToString(rdr["MOM_FILE"])).ToUpper() == ".DOCX")
        //                            {
        //                                newFileName = System.IO.Path.GetFileNameWithoutExtension(Convert.ToString(rdr["MOM_FILE"])) + ".pdf";
        //                                bool isConverted = ConvertDocToPDF(Convert.ToString(rdr["MOM_FILE"]), newFileName, objCommittee.createdBy, objCommittee.companyId);
        //                                if (isConverted)
        //                                {
        //                                    objDraftMOMCommittee.draftMOMDocument = (!String.IsNullOrEmpty(Convert.ToString(rdr["MOM_FILE"]))) ? applicationPath + @"BoardMeeting/Documents/MOMuplodedFile/" + newFileName : String.Empty;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                objDraftMOMCommittee.draftMOMDocument = (!String.IsNullOrEmpty(Convert.ToString(rdr["MOM_FILE"]))) ? applicationPath + @"BoardMeeting/Documents/MOMuplodedFile/" + Convert.ToString(rdr["MOM_FILE"]) : String.Empty;
        //                            }
        //                        }
        //                        objDraftMOMCommittee.isFileDownload = (!String.IsNullOrEmpty(Convert.ToString(rdr["IS_DOWNLOAD_FILE"]))) ? (Convert.ToString(rdr["IS_DOWNLOAD_FILE"]) == "Yes" ? true : false) : true;
        //                        objDraftMOMCommittee.fileSyncDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["SYNC_DATE"]))) ? Convert.ToString(rdr["SYNC_DATE"]) : String.Empty;
        //                        objDraftMOMCommittee.taskStatus = (!String.IsNullOrEmpty(Convert.ToString(rdr["TASK_STATUS"]))) ? Convert.ToString(rdr["TASK_STATUS"]) : String.Empty;
        //                        listDraftMOMCommittee.Add(objDraftMOMCommittee);
        //                    }
        //                    _committeeResponse.APIDraftMOMCommitteeList = listDraftMOMCommittee;
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "MobileAPI", "GetAPIDraftMOMRepository", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        #endregion

        #region "Get Final MOM Repository For API"

        //public CommitteeResponse GetAPIFinalMOMRepository(APICommittee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        string applicationPath = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ApplicationURL"].ToString(), true);
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_MEETING_MOM", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_FINAL_MOM_REPOSITORY_FOR_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", objCommittee.createdBy));
        //                cmd.Parameters.Add(new SqlParameter("@FILE_SYNC_DATE", objCommittee.fileSyncDate));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    List<APIFinalMOMCommittee> listFinalMOMCommittee = new List<APIFinalMOMCommittee>();
        //                    APIFinalMOMCommittee objFinalMOMCommittee;
        //                    while (rdr.Read())
        //                    {
        //                        objFinalMOMCommittee = new APIFinalMOMCommittee();
        //                        objFinalMOMCommittee.ID = (!String.IsNullOrEmpty(Convert.ToString(rdr["MOM_ID"]))) ? Convert.ToInt32(rdr["MOM_ID"]) : 0;
        //                        objFinalMOMCommittee.meetingTitle = (!String.IsNullOrEmpty(Convert.ToString(rdr["MEETING_TITLE"]))) ? Convert.ToString(rdr["MEETING_TITLE"]) : String.Empty;
        //                        objFinalMOMCommittee.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NAME"]))) ? Convert.ToString(rdr["COMMITTEE_NAME"]) : String.Empty;
        //                        objFinalMOMCommittee.meetingDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["MEETING_DATE"]))) ? Convert.ToString(Convert.ToDateTime(rdr["MEETING_DATE"])) : String.Empty;
        //                        objFinalMOMCommittee.finalMOMDocument = (!String.IsNullOrEmpty(Convert.ToString(rdr["MOM_DOCUMENT"]))) ? applicationPath + @"BoardMeeting/Documents/MOMuplodedFile/" + Convert.ToString(rdr["MOM_DOCUMENT"]) : String.Empty;
        //                        objFinalMOMCommittee.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        objFinalMOMCommittee.committeeId = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ID"]))) ? Convert.ToInt32(rdr["COMMITTEE_ID"]) : 0;
        //                        objFinalMOMCommittee.isFileDownload = (!String.IsNullOrEmpty(Convert.ToString(rdr["IS_DOWNLOAD_FILE"]))) ? (Convert.ToString(rdr["IS_DOWNLOAD_FILE"]) == "Yes" ? true : false) : true;
        //                        objFinalMOMCommittee.fileSyncDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["SYNC_DATE"]))) ? Convert.ToString(rdr["SYNC_DATE"]) : String.Empty;
        //                        objFinalMOMCommittee.isDeleted = (!String.IsNullOrEmpty(Convert.ToString(rdr["IS_DELETED"]))) ? (Convert.ToInt32(rdr["IS_DELETED"]) == 1 ? true : false) : true;
        //                        listFinalMOMCommittee.Add(objFinalMOMCommittee);
        //                    }
        //                    _committeeResponse.APIFinalMOMCommitteeList = listFinalMOMCommittee;
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "MobileAPI", "GetAPIFinalMOMRepository", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        #endregion

        #region "Get Circular Resolution Library Repository For API"

        //public CommitteeResponse GetAPICRLibraryRepository(APICommittee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        string applicationPath = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["ApplicationURL"].ToString(), true);
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_CR", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "GET_CR_Library_REPOSITORY_FOR_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objCommittee.createdBy));
        //                cmd.Parameters.Add(new SqlParameter("@FILE_SYNC_DATE", objCommittee.fileSyncDate));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    List<APICRLibraryCommittee> listCRLibraryCommittee = new List<APICRLibraryCommittee>();
        //                    APICRLibraryCommittee objCRLibraryCommittee;
        //                    while (rdr.Read())
        //                    {
        //                        objCRLibraryCommittee = new APICRLibraryCommittee();
        //                        objCRLibraryCommittee.crId = (!String.IsNullOrEmpty(Convert.ToString(rdr["CR_ID"]))) ? Convert.ToInt32(rdr["CR_ID"]) : 0;
        //                        objCRLibraryCommittee.committeeId = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ID"]))) ? Convert.ToInt32(rdr["COMMITTEE_ID"]) : 0;
        //                        objCRLibraryCommittee.crNo = (!String.IsNullOrEmpty(Convert.ToString(rdr["CR_NO"]))) ? Convert.ToString(rdr["CR_NO"]) : String.Empty;
        //                        objCRLibraryCommittee.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        objCRLibraryCommittee.committeeAbbr = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        objCRLibraryCommittee.crDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["CR_DATE"]))) ? Convert.ToString(rdr["CR_DATE"]) : String.Empty;
        //                        objCRLibraryCommittee.crFile = (!String.IsNullOrEmpty(Convert.ToString(rdr["CR_FILE"]))) ? applicationPath + @"BoardMeeting/CRDocument/" + Convert.ToString(rdr["CR_FILE"]) : String.Empty;
        //                        objCRLibraryCommittee.dueBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["DUE_BY"]))) ? Convert.ToString(rdr["DUE_BY"]) : String.Empty;
        //                        objCRLibraryCommittee.status = (!String.IsNullOrEmpty(Convert.ToString(rdr["STATUS"]))) ? Convert.ToString(rdr["STATUS"]) : String.Empty;
        //                        objCRLibraryCommittee.crCurrentMemberStatus = (!String.IsNullOrEmpty(Convert.ToString(rdr["CR_CURRENT_MEMBER_STATUS"]))) ? Convert.ToString(rdr["CR_CURRENT_MEMBER_STATUS"]) : String.Empty;
        //                        objCRLibraryCommittee.crMemberId = (!String.IsNullOrEmpty(Convert.ToString(rdr["BMS_CR_MEMBERS_ID"]))) ? Convert.ToInt32(rdr["BMS_CR_MEMBERS_ID"]) : 0;
        //                        objCRLibraryCommittee.isFileDownload = (!String.IsNullOrEmpty(Convert.ToString(rdr["IS_DOWNLOAD_FILE"]))) ? (Convert.ToString(rdr["IS_DOWNLOAD_FILE"]) == "Yes" ? true : false) : true;
        //                        objCRLibraryCommittee.fileSyncDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["SYNC_DATE"]))) ? Convert.ToString(rdr["SYNC_DATE"]) : String.Empty;
        //                        APICRLibraryCommittee objCRMembersCount = GetCRMembersCount(objCRLibraryCommittee.crId);
        //                        objCRLibraryCommittee.assentedMembersCount = objCRMembersCount.assentedMembersCount;
        //                        objCRLibraryCommittee.dissentedMembersCount = objCRMembersCount.dissentedMembersCount;
        //                        objCRLibraryCommittee.abstainedMembersCount = objCRMembersCount.abstainedMembersCount;
        //                        objCRLibraryCommittee.notYetVotedMembersCount = objCRMembersCount.notYetVotedMembersCount;
        //                        listCRLibraryCommittee.Add(objCRLibraryCommittee);
        //                    }
        //                    _committeeResponse.APICRLibraryCommitteeList = listCRLibraryCommittee;
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "MobileAPI", "GetAPICRLibraryRepository", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        #endregion

        #endregion

        #region "Mobile Fresh API Methods"

        #region "Bind Committee"

        //public CommitteeResponse BindAPICommittee(APICommittee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    _meetingResponse = new MeetingResponse();
        //    MeetingRepository meetingRepo = new MeetingRepository();

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
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        APICommittee obj = new APICommittee();
        //                        obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
        //                        obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        obj.companyId = objCommittee.companyId;
        //                        obj.createdBy = objCommittee.createdBy;
        //                        obj.moduleDatabase = objCommittee.moduleDatabase;
        //                        meetingRepo.GetBMSMeetingListAPI(obj);
        //                        _committeeResponse.AddObject(obj);
        //                    }
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "MobileAPI", "BindAPICommittee", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        #endregion

        #endregion

        #region "Web APP API Methods"

        #region "Get Committee for Web Application API"

        //public CommitteeResponse BindWebAppAPICommittee(APICommittee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    _meetingResponse = new MeetingResponse();
        //    MeetingRepository meetingRepo = new MeetingRepository();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        APICommittee obj = new APICommittee();
        //                        obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
        //                        obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        obj.companyId = objCommittee.companyId;
        //                        obj.createdBy = objCommittee.createdBy;
        //                        meetingRepo.GetBMSMeetingListAPIWebApp(obj);
        //                        _committeeResponse.AddObject(obj);
        //                    }
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "WebAppAPI", "BindWebAppAPICommittee", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        #endregion

        #region "Get Committee for Web Application API For Dashboard"

        //public CommitteeResponse BindWebAppAPICommitteeForDashboard(APICommittee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    _meetingResponse = new MeetingResponse();
        //    MeetingRepository meetingRepo = new MeetingRepository();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        APICommittee obj = new APICommittee();
        //                        obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
        //                        obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        obj.companyId = objCommittee.companyId;
        //                        obj.createdBy = objCommittee.createdBy;
        //                        meetingRepo.GetBMSMeetingListAPIWebAppDashboard(obj);
        //                        _committeeResponse.AddObject(obj);
        //                    }
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "WebAppAPI", "BindWebAppAPICommitteeForDashboard", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        #endregion

        #region "Update CR Member Task Repository For API"
        //public CommitteeResponse UpdateAPICRMemberTaskRepository(APICRMemberCommittee objCRMemberCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            conn.ChangeDatabase(dataBaseName);
        //            using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_CR", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "UPDATE_CR_MEMBERS_TASK_FOR_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@BMS_CR_MEMBER_ID", objCRMemberCommittee.crMemberId));
        //                cmd.Parameters.Add(new SqlParameter("@BMS_CR_MEMBER_STATUS", objCRMemberCommittee.status));
        //                cmd.Parameters.Add(new SqlParameter("@BMS_CR_MEMBER_COMMUNICATION_COMMENTS", objCRMemberCommittee.comments));
        //                cmd.ExecuteScalar();
        //                _committeeResponse.StatusFl = true;
        //                _committeeResponse.Msg = "Data has been updated successfully !";

        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "WebAppAPI", "UpdateAPICRMemberTaskRepository", String.Empty, 1);
        //    }
        //    return _committeeResponse;
        //}
        #endregion

        #endregion

        #region "Bind Committee For Activity Log Report"

        public CommitteeResponse BindCommitteeForActivityLogReport(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_ACTIVITY_LOG_REPORT", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@MODE", "GET_COMMITTEE_FILTER"));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Committee obj = new Committee();
                                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
                                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion

        //private bool ConvertDocToPDF(String docFileName, String pdfFileName, String createdBy, Int32 companyID)
        //{
        //    bool isStatus = false;
        //    try
        //    {
        //        String filePath = CryptorEngine.Decrypt(ConfigurationManager.AppSettings["DraftMOMFilePath"], true);

        //        //Loads an existing Word document
        //        WordDocument wordDocument = new WordDocument(System.IO.Path.Combine(filePath, docFileName), Syncfusion.DocIO.FormatType.Docx);

        //        //create an instance of DocToPDFConverter - responsible for Word to PDF conversion
        //        DocToPDFConverter converter = new DocToPDFConverter();

        //        //Set the image quality
        //        converter.Settings.ImageQuality = 100;

        //        //Set the image resolution
        //        converter.Settings.ImageResolution = 640;

        //        //Set true to optimize the memory usage for identical images
        //        converter.Settings.OptimizeIdenticalImages = true;

        //        //Convert Word document into PDF document
        //        PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);
        //        //pdfDocument.PageSettings.Size = PdfPageSize.A4;

        //        //Save the PDF file to file system                
        //        pdfDocument.Save(System.IO.Path.Combine(filePath, pdfFileName));

        //        //close the instance of document objects
        //        pdfDocument.Close(true);

        //        wordDocument.Close();

        //        isStatus = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message, ex.Source, ex.StackTrace, "CommitteeRepository", "ConvertDocToPDF", createdBy, 1, companyID);
        //        isStatus = false;
        //    }
        //    return isStatus;
        //}

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

        public CommitteeResponse BindYear(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SELECT distinct YEAR(MEETING_DT)'Year' from BMS_MEETING", conn))
                    {

                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Committee obj = new Committee();

                                obj.CommitteeYear = (!String.IsNullOrEmpty(Convert.ToString(rdr["Year"]))) ? Convert.ToString(rdr["Year"]) : String.Empty;
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #region "Bind Committee For Department Workflow Report"

        public CommitteeResponse BindCommitteeForDepartmentWorkFlow(Committee objCommittee)
        {
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_FOR_DEPARTMENET_WORKFLOW_REPORT"));
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion


        #region "Get Committee Audit Record"

        public CommitteeResponse GetCommitteeAuditRecord(Committee objCommittee)
        {
            List<Committee> lstCommittee = new List<Committee>();
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_BMS_AUDIT_REPORT_ALL", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "COMMITTEE"));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        cmd.Parameters.Add(new SqlParameter("@FROMDATE", ConvertDate(objCommittee.fromDate)));
                        cmd.Parameters.Add(new SqlParameter("@TODATE", ConvertDate(objCommittee.toDate)));
                        //cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Committee obj = new Committee();
                                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
                                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
                                obj.createdBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATED_BY"]))) ? Convert.ToString(rdr["CREATED_BY"]) : String.Empty;
                                obj.createdOn = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATED_ON"]))) ? Convert.ToString(rdr["CREATED_ON"]) : String.Empty;
                                obj.modifiedBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["MODIFIED_BY"]))) ? Convert.ToString(rdr["MODIFIED_BY"]) : String.Empty;
                                obj.modifiedOn = (!String.IsNullOrEmpty(Convert.ToString(rdr["MODIFIED_ON"]))) ? Convert.ToString(rdr["MODIFIED_ON"]) : String.Empty;
                                obj.operation = (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATION"]))) ? Convert.ToString(rdr["OPERATION"]) : String.Empty;
                                obj.operation_Dt = (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATION_DT"]))) ? Convert.ToString(rdr["OPERATION_DT"]) : String.Empty;
                                lstCommittee.Add(obj);
                                //_committeeResponse.AddObject(obj);
                            }
                            _committeeResponse.CommitteeList = lstCommittee;
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion


        #region "Get Committee Audit Record"

        public CommitteeResponse GetCommitteeCompositionAuditRecord(Committee objCommittee)
        {
            List<Committee> lstCommittee = new List<Committee>();
            _committeeResponse = new CommitteeResponse();
            _committeeResponse.StatusFl = false;
            _committeeResponse.Msg = "No data found !";
            try
            {
                List<CommitteeMember> lstMember = new List<CommitteeMember>();
                Committee obj = new Committee();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    conn.ChangeDatabase(objCommittee.moduleDatabase);
                    using (SqlCommand cmd = new SqlCommand("USP_BMS_AUDIT_REPORT_ALL", conn))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(new SqlParameter("@ACTION_TYPE", "COMMITTEE_COMPOSITION"));
                        //cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
                        cmd.Parameters.Add(new SqlParameter("@FROMDATE", ConvertDate(objCommittee.fromDate)));
                        cmd.Parameters.Add(new SqlParameter("@TODATE", ConvertDate(objCommittee.toDate)));
                        //cmd.Parameters.Add(new SqlParameter("@USER_ID", objCommittee.createdBy));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {

                                CommitteeMember mbmobj = new CommitteeMember();
                                obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
                                obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
                                //mbmobj.member = new User
                                //{
                                //    userName = (!String.IsNullOrEmpty(Convert.ToString(rdr["USER_NM"]))) ? Convert.ToString(rdr["USER_NM"]) : String.Empty
                                //};
                                //mbmobj.designation = new Designation
                                //{
                                //    designationName = (!String.IsNullOrEmpty(Convert.ToString(rdr["DESIGNATION_NAME"]))) ? Convert.ToString(rdr["DESIGNATION_NAME"]) : String.Empty
                                //};
                                mbmobj.createdBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATED_BY"]))) ? Convert.ToString(rdr["CREATED_BY"]) : String.Empty;
                                mbmobj.createdon = (!String.IsNullOrEmpty(Convert.ToString(rdr["CREATED_ON"]))) ? Convert.ToString(rdr["CREATED_ON"]) : String.Empty;
                                mbmobj.modifiedBy = (!String.IsNullOrEmpty(Convert.ToString(rdr["MODIFIED_BY"]))) ? Convert.ToString(rdr["MODIFIED_BY"]) : String.Empty;
                                mbmobj.committeeModifiedDate = (!String.IsNullOrEmpty(Convert.ToString(rdr["MODIFIED_ON"]))) ? Convert.ToString(rdr["MODIFIED_ON"]) : String.Empty;
                                mbmobj.operation = (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATION"]))) ? Convert.ToString(rdr["OPERATION"]) : String.Empty;
                                mbmobj.operation_Dt = (!String.IsNullOrEmpty(Convert.ToString(rdr["OPERATION_DT"]))) ? Convert.ToString(rdr["OPERATION_DT"]) : String.Empty;
                               // mbmobj.sequence = Convert.ToInt32(rdr["SEQUENCE"]);
                                //mbmobj.finalApprover = (!String.IsNullOrEmpty(Convert.ToString(rdr["FINAL_APPROVER"]))) ? Convert.ToString(rdr["FINAL_APPROVER"]) : String.Empty;
                                lstMember.Add(mbmobj);
                                //_committeeResponse.AddObject(obj);
                            }
                            obj.committeeMembers = lstMember;
                            _committeeResponse.Committee = obj;
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
                _committeeResponse.Msg = "Processing failed, because of system error !";
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _committeeResponse;
        }

        #endregion


        #region "Bind API Committee For Meeting Repository"

        //public CommitteeResponse BindAPICommitteeForMeetingRepository(APICommittee objCommittee)
        //{
        //    _committeeResponse = new CommitteeResponse();
        //    _committeeResponse.StatusFl = false;
        //    _committeeResponse.Msg = "No Data Found!";
        //    _meetingResponse = new MeetingResponse();
        //    MeetingRepository meetingRepo = new MeetingRepository();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            //conn.ChangeDatabase(objCommittee.moduleDatabase);
        //            conn.ChangeDatabase(dataBaseName);
        //            //using (SqlCommand cmd = new SqlCommand("SP_PROCS_BMS_COMMITTEE", conn))
        //            //{
        //            using (SqlCommand cmd = new SqlCommand("USP_PROCS_BMS_MEETING_REPOSITORY", conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 0;
        //                cmd.Parameters.Clear();
        //                cmd.Parameters.Add(new SqlParameter("@MODE", "BIND_COMMITTEES_API"));
        //                cmd.Parameters.Add(new SqlParameter("@SET_COUNT", SqlDbType.Int)).Direction = ParameterDirection.Output;
        //                cmd.Parameters.Add(new SqlParameter("@COMPANY_ID", objCommittee.companyId));
        //                cmd.Parameters.Add(new SqlParameter("@USER_LOGIN", objCommittee.createdBy));
        //                cmd.Parameters.Add(new SqlParameter("@MEETING_ID", objCommittee.MeetingId));
        //                SqlDataReader rdr = cmd.ExecuteReader();
        //                if (rdr.HasRows)
        //                {
        //                    while (rdr.Read())
        //                    {
        //                        APICommittee obj = new APICommittee();
        //                        obj.ID = Convert.ToInt32(rdr["COMMITTEE_ID"]);
        //                        obj.committeeName = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_NM"]))) ? Convert.ToString(rdr["COMMITTEE_NM"]) : String.Empty;
        //                        obj.committeeABRR = (!String.IsNullOrEmpty(Convert.ToString(rdr["COMMITTEE_ABBR"]))) ? Convert.ToString(rdr["COMMITTEE_ABBR"]) : String.Empty;
        //                        obj.companyId = objCommittee.companyId;
        //                        obj.createdBy = objCommittee.createdBy;
        //                        obj.MeetingId = objCommittee.MeetingId;
        //                        //obj.moduleDatabase = objCommittee.moduleDatabase;
        //                        obj.Year = objCommittee.Year;
        //                        obj.moduleDatabase = dataBaseName;
        //                        if (obj.MeetingId == 0)
        //                        {
        //                            meetingRepo.GetBMSMeetingListAPIForMeetingRepository(obj);
        //                        }
        //                        else if (obj.MeetingId > 0)
        //                        {
        //                            meetingRepo.GetBMSMeetingDetailAPIForMeetingRepository(obj);
        //                        }
        //                        _committeeResponse.AddObject(obj);
        //                    }
        //                    _committeeResponse.StatusFl = true;
        //                    _committeeResponse.Msg = "Data has been fetched successfully !";
        //                }
        //                rdr.Close();
        //            }
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _committeeResponse = new CommitteeResponse();
        //        _committeeResponse.StatusFl = false;
        //        _committeeResponse.Msg = "Something went wrong. Please try again or Contact Support!";
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, "MobileAPI", "BindAPICommittee", objCommittee.createdBy, 1, objCommittee.companyId);
        //    }
        //    return _committeeResponse;
        //}

        #endregion
    }
}