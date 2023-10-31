using System;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BMS_New.Models.BMS.Service.Response;
using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Model;

namespace BMS_New.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        string input;
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        UserResponse userResponse = new UserResponse();

        [Route("SaveUser")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public UserResponse SaveUser()
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
                List<User> lstUser = new List<User>();
                lstUser = serializer1.Deserialize<List<User>>(input);
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
                    User objUser = new User();
                    objUser = lstUser[0];
                    objUser.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                    objUser.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                    //objUser.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                    objUser.moduleId = Convert.ToInt32(HttpContext.Current.Session["ModuleId"]);

                    if (HttpContext.Current.Request.Files.Count > 0)
                    {
                        String sSaveAs = "";
                        String userDir = "/BoardMeeting/images/user/";

                        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~" + userDir)))
                        {
                            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~" + userDir));
                        }
                        HttpFileCollection files = HttpContext.Current.Request.Files;
                        String newFileName = String.Empty;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFile file = files[i];
                            String ext = Path.GetExtension(file.FileName);
                            String name = String.Empty;
                            if (file.FileName.Length > 20)
                            {
                                name = Path.GetFileNameWithoutExtension(file.FileName).Replace(".", "").Substring(0, 20);
                            }
                            else
                            {
                                name = Path.GetFileNameWithoutExtension(file.FileName).Replace(".", "");
                            }
                            if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                newFileName = testfiles[testfiles.Length - 1] + "_" + DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss_fff", CultureInfo.InvariantCulture) + ext;
                            }
                            else
                            {
                                newFileName = name + "_" + DateTime.UtcNow.ToString("yyyy_MM_dd_HH_mm_ss_fff", CultureInfo.InvariantCulture) + ext;
                            }
                            sSaveAs = Path.Combine(HttpContext.Current.Server.MapPath("~" + userDir), newFileName);
                            file.SaveAs(sSaveAs);

                            objUser.uploadAvatar = newFileName;
                        }
                    }
                    UserRequest UserReq = new UserRequest(objUser);
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
        public UserResponse DeleteUser()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    userResponse.StatusFl = false;
                    userResponse.Msg = "SessionExpired";
                    return userResponse;
                }

                List<User> lstUser = new List<User>();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                lstUser = serializer1.Deserialize<List<User>>(input);
                User objUser = new User();
                objUser = lstUser[0];
                // objUser.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                objUser.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //objUser.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                UserRequest UserReq = new UserRequest(objUser);
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

        [Route("GetUserList")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public UserResponse GetUserList()
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
                // meetingVenue.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                 //user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                //user.moduleId = Convert.ToInt32(HttpContext.Current.Session["ModuleId"]);
                UserRequest gReqUserList = new UserRequest(user);
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
        public UserResponse GetUserEmailList()
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
                user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                UserRequest gReqEmailList = new UserRequest(user);
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

        //[Route("GetAllUsersRole")]
        //[HttpGet]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        //public UserResponse GetAllUsersRole()
        //{
        //    try
        //    {
        //        if (HttpContext.Current.Session.Count == 0)
        //        {
        //            userResponse.StatusFl = false;
        //            userResponse.Msg = "SessionExpired";
        //            return userResponse;
        //        }

        //        User user = new User();
        //        //user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
        //        UserRequest cReq = new UserRequest(user);
        //        userResponse = cReq.GetAllUsersRole();
        //    }
        //    catch (Exception ex)
        //    {
        //        //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
        //        userResponse.StatusFl = false;
        //        userResponse.Msg = ex.Message;
        //    }
        //    return userResponse;
        //}

        [Route("GetAllUser")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public UserResponse GetAllUserByCompany()
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
                //  meetingVenue.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                // user.moduleId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                UserRequest gReqUserList = new UserRequest(user);
                userResponse = gReqUserList.GetAllUserByCompany();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                userResponse.StatusFl = false;
                userResponse.Msg = ex.Message;
            }
            return userResponse;
        }



        //[HttpGet]
        //public UserResponse GetAllUsers()
        //{
        //    try
        //    {
        //        if (HttpContext.Current.Session.Count == 0)
        //        {
        //            UserResponse objResponse = new UserResponse();
        //            objResponse.StatusFl = false;
        //            objResponse.Msg = "SessionExpired";
        //            return objResponse;
        //        }
        //        User oUser = new User();
        //        oUser.LoginId = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
        //        oUser.UserEmail = Convert.ToString(HttpContext.Current.Session["EmailId"]);
        //        oUser.UserNm = Convert.ToString(HttpContext.Current.Session["UserNm"]);
        //        oUser.RoleNm = Convert.ToString(HttpContext.Current.Session["RoleNm"]);
        //        oUser.RoleId = Convert.ToInt32(HttpContext.Current.Session["RoleId"]);

        //        if (!oUser.ValidateInput())
        //        {
        //            UserResponse objResponse = new UserResponse();
        //            objResponse.StatusFl = false;
        //            objResponse.Msg = "Invalid Input Format";
        //            return objResponse;
        //        }
        //        UserRequest docReq = new UserRequest(oUser);
        //        UserResponse docRes = docReq.GetAllUsers();
        //        return docRes;
        //    }
        //    catch (Exception ex)
        //    {
        //        UserResponse objResponse = new UserResponse();
        //        objResponse.StatusFl = false;
        //        objResponse.Msg = ex.Message;
        //        return objResponse;
        //    }
        //}
    }
}