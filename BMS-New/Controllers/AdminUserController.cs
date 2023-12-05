using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace DMS.Controllers
{
    [RoutePrefix("api/AdminUser")]
    public class AdminUserController : ApiController
    {
        string input;
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        CompanyResponse companyResponse = new CompanyResponse();
        AdminUserResponse userResponse = new AdminUserResponse();

        [Route("SaveUser")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "AdminUser APIs" })]

        public AdminUserResponse SaveUser()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    userResponse.StatusFl = false;
                    userResponse.Msg = "SessionExpired";
                    return userResponse;
                }

                input = HttpContext.Current.Request.Form["Object"];
                List<AdminUser> lstUser = new List<AdminUser>();
                lstUser = serializer1.Deserialize<List<AdminUser>>(input);
                if (lstUser == null)
                {
                    userResponse.StatusFl = false;
                    userResponse.Msg = "Something went wrong";
                }
                else if (lstUser.Count == 0)
                {
                    userResponse.StatusFl = false;
                    userResponse.Msg = "Something went wrong";
                }
                else
                {
                    AdminUser objUser = new AdminUser();
                    objUser = lstUser[0];
                    objUser.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                    objUser.CREATED_BY = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                    //objUser.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                    //objUser.moduleId = Convert.ToInt32(HttpContext.Current.Session["ModuleId"]);

                    AdminUserRequest UserReq = new AdminUserRequest(objUser);
                    userResponse = UserReq.SaveUser();
                }
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }

        [Route("DeleteUser")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public AdminUserResponse DeleteUser()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    userResponse.StatusFl = false;
                    userResponse.Msg = "SessionExpired";
                    return userResponse;
                }

                List<AdminUser> lstUser = new List<AdminUser>();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                lstUser = serializer1.Deserialize<List<AdminUser>>(input);
                AdminUser objUser = new AdminUser();
                objUser = lstUser[0];
                // objUser.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                //objUser.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //objUser.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                AdminUserRequest UserReq = new AdminUserRequest(objUser);
                userResponse = UserReq.DeleteUser();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }

        [Route("GetCompanyList")]
        [HttpGet]
        // [SwaggerOperation(Tags = new[] { "User APIs" })]
        public CompanyResponse GetCompanyList()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    companyResponse.StatusFl = false;
                    companyResponse.Msg = "SessionExpired";
                    return companyResponse;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Company company = new JavaScriptSerializer().Deserialize<Company>(input);

                Company Objcomp = new Company();
                //meetingVenue.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                var id = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                Objcomp.CompanyId = Convert.ToInt32( id);
                //  user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                // user.moduleId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                CompanyRequest gReqCompanyList = new CompanyRequest(Objcomp);
                companyResponse = gReqCompanyList.GetCompanyForAdminUserList();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                companyResponse.StatusFl = false;
                companyResponse.Msg = ex.Message;
            }
            return companyResponse;
        }

        [Route("GetModuleList")]
        [HttpGet]
        // [SwaggerOperation(Tags = new[] { "User APIs" })]
        public AdminUserResponse GetModuleList()
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
                AdminUser user = new JavaScriptSerializer().Deserialize<AdminUser>(input);
                //meetingVenue.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                //user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //  user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                // user.moduleId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                AdminUserRequest gReqUserList = new AdminUserRequest(user);
                userResponse = gReqUserList.GetModuleList();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }

        [Route("GetUserList")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public AdminUserResponse GetUserList()
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
                AdminUser user = new JavaScriptSerializer().Deserialize<AdminUser>(input);
                // meetingVenue.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                user.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
               // user.LoginId = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                //user.moduleId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                AdminUserRequest gReqUserList = new AdminUserRequest(user);
                userResponse = gReqUserList.GetUserList();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }

        [Route("GetUserEmailList")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public AdminUserResponse GetUserEmailList()
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
                AdminUser user = new JavaScriptSerializer().Deserialize<AdminUser>(input);
                //user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                AdminUserRequest gReqEmailList = new AdminUserRequest(user);
                userResponse = gReqEmailList.GetEmailList();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }

        [Route("GetAllUsersRole")]
        [HttpGet]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public AdminUserResponse GetAllUsersRole()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    userResponse.StatusFl = false;
                    userResponse.Msg = "SessionExpired";
                    return userResponse;
                }

                AdminUser user = new AdminUser();
                //user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                AdminUserRequest cReq = new AdminUserRequest(user);
                userResponse = cReq.GetAllUsersRole();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }

        [Route("FillUserDetails")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public AdminUserResponse FillUserDetails()
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
                AdminUser user = new JavaScriptSerializer().Deserialize<AdminUser>(input);
                //user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                AdminUserRequest cReq = new AdminUserRequest(user);
                userResponse = cReq.FillUserDetails();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }
    }
}
