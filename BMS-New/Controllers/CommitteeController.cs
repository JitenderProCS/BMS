using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Service.Response;
using BMS_New.Models.Infrastructure;
using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace BMS_New.Controllers
{
    [RoutePrefix("api/Committee")]
    public class CommitteeController : ApiController
    {
        string input;
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        UserResponse userResponse = new UserResponse();
        CommitteeResponse committeeResponse = new CommitteeResponse();

        [Route("GetUsersForCommitteeSuperAdmin")]
        [HttpPost]
        public UserResponse GetUsersForCommitteeSuperAdmin()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    userResponse.StatusFl = false;
                    userResponse.Msg = "SessionExpired";
                    return userResponse;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                User user = new JavaScriptSerializer().Deserialize<User>(input);
                user.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                UserRequest userRequest = new UserRequest(user);
                userResponse = userRequest.GetUsersForCommitteeSuperAdmin();
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }

        [Route("SaveCommittee")]
        [HttpPost]
        public CommitteeResponse SaveCommittee()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    committeeResponse.StatusFl = false;
                    committeeResponse.Msg = "SessionExpired";
                    return committeeResponse;
                }

                List<Committee> lstUser = new List<Committee>();
              
                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }

                lstUser = serializer1.Deserialize<List<Committee>>(input);
                Committee committee = new Committee();
                committee = lstUser[0];
                committee.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                committee.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                committee.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                CommitteeRequest committeeRequest = new CommitteeRequest(committee);
                committeeResponse = committeeRequest.Savecommittee();
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                committeeResponse.StatusFl = false;
                committeeResponse.Msg = ex.Message;
            }
            return committeeResponse;
        }

        [Route("GetUserListForCommittee")]
        [HttpPost]
        public CommitteeResponse GetUserListForCommittee()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    committeeResponse.StatusFl = false;
                    committeeResponse.Msg = "SessionExpired";
                    return committeeResponse;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Committee committee = new JavaScriptSerializer().Deserialize<Committee>(input);
                committee.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                committee.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                committee.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                CommitteeRequest committeeRequest = new CommitteeRequest(committee);
                committeeResponse = committeeRequest.userlistforcommittee();
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                committeeResponse.StatusFl = false;
                committeeResponse.Msg = ex.Message;
            }
            return committeeResponse;
        }

        [Route("ListCommittee")]
        [HttpPost]
        public CommitteeResponse ListCommittee()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    committeeResponse.StatusFl = false;
                    committeeResponse.Msg = "SessionExpired";
                    return committeeResponse;
                }

                Committee committee = new Committee();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }

                committee = serializer1.Deserialize<Committee>(input);


                committee.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                committee.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                committee.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                CommitteeRequest committeeRequest = new CommitteeRequest(committee);
                committeeResponse = committeeRequest.ListCommittee();
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                committeeResponse.StatusFl = false;
                committeeResponse.Msg = ex.Message;
            }
            return committeeResponse;
        }
    }
}
