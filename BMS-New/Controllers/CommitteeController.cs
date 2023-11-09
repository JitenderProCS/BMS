using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Service.Response;
using BMS_New.Models.Infrastructure;
using System;
using System.Web;
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
    }
}
