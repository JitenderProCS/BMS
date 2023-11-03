using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace BMS_New.Controllers
{
    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        string input;
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        CompanyResponse companyResponse = new CompanyResponse();
        CompanyGroupResponse companygroupResponse = new CompanyGroupResponse();


        [Route("SaveCompany")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public CompanyResponse SaveCompany()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    companyResponse.StatusFl = false;
                    companyResponse.Msg = "SessionExpired";
                    return companyResponse;
                }

                input = HttpContext.Current.Request.Form["Object"];
                List<Company> lstCompany = new List<Company>();
                lstCompany = serializer1.Deserialize<List<Company>>(input);
                if (lstCompany == null)
                {
                    companyResponse.StatusFl = false;
                    companyResponse.Msg = "Something went wrong";
                }
                else if (lstCompany.Count == 0)
                {
                    companyResponse.StatusFl = false;
                    companyResponse.Msg = "Something went wrong";
                }
                else
                {
                    Company objCompany = new Company();
                    objCompany = lstCompany[0];
                   // objCompany.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                    objCompany.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                   // objCompany.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                   // objCompany.moduleId = Convert.ToInt32(HttpContext.Current.Session["ModuleId"]);

                    if (HttpContext.Current.Request.Files.Count > 0)
                    {
                        String sSaveAs = "";
                        String userDir = "/BoardMeeting/images/CompanyLogo/";

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

                            objCompany.uploadAvatar = newFileName;
                        }
                    }
                    CompanyRequest UserReq = new CompanyRequest(objCompany);
                    companyResponse = UserReq.SaveCompany();
                }
            }
            catch (Exception ex)
            {
                // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                companyResponse.StatusFl = false;
                companyResponse.Msg = ex.Message;
            }
            return companyResponse;
        }

        [Route("GetCompanyList")]
        [HttpPost]
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
                Company objcom = new Company();
               var Id = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objcom.companyId = Convert.ToInt32(Id);
                //meetingVenue.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                //user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //  user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                // user.moduleId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                CompanyRequest gReqCompanyList = new CompanyRequest(objcom);
                companyResponse = gReqCompanyList.GetCompanyList();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                companyResponse.StatusFl = false;
                companyResponse.Msg = ex.Message;
            }
            return companyResponse;
        }

        [Route("GetCompanyTypeList")]
        [HttpPost]
        // [SwaggerOperation(Tags = new[] { "User APIs" })]
        public CompanyResponse GetCompanyTypeList()
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
                //meetingVenue.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                //user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //  user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                // user.moduleId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                CompanyRequest gReqCompanyList = new CompanyRequest(company);
                companyResponse = gReqCompanyList.GetCompanyTypeList();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                companyResponse.StatusFl = false;
                companyResponse.Msg = ex.Message;
            }
            return companyResponse;
        }

        [Route("GetCompanyGroupList")]
        [HttpPost]
        // [SwaggerOperation(Tags = new[] { "User APIs" })]
        public CompanyGroupResponse GetCompanyGroupList()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    companygroupResponse.StatusFl = false;
                    companygroupResponse.Msg = "SessionExpired";
                    return companygroupResponse;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                CompanyGrooup company = new JavaScriptSerializer().Deserialize<CompanyGrooup>(input);
                CompanyGrooup objGrp = new CompanyGrooup();
                var createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                objGrp.createdBy = Convert.ToString(createdBy);

                //user.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                //  user.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                // user.moduleId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                CompanyGroupRequest gReqCompanyList = new CompanyGroupRequest(objGrp);
                companygroupResponse = gReqCompanyList.GetCompanyGroupList();
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                companyResponse.StatusFl = false;
                companyResponse.Msg = ex.Message;
            }
            return companygroupResponse;
        }

        [Route("SaveCompanyGroup")]
        [HttpPost]
        //[SwaggerOperation(Tags = new[] { "User APIs" })]
        public CompanyGroupResponse SaveCompanyGroup()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    companygroupResponse.StatusFl = false;
                    companygroupResponse.Msg = "SessionExpired";
                    return companygroupResponse;
                }

                input = HttpContext.Current.Request.Form["Object"];
                List<CompanyGrooup> lstCompany = new List<CompanyGrooup>();
                lstCompany = serializer1.Deserialize<List<CompanyGrooup>>(input);
                if (lstCompany == null)
                {
                    companygroupResponse.StatusFl = false;
                    companygroupResponse.Msg = "Something went wrong";
                }
                else if (lstCompany.Count == 0)
                {
                    companygroupResponse.StatusFl = false;
                    companygroupResponse.Msg = "Something went wrong";
                }
                else
                {
                    CompanyGrooup objCompany = new CompanyGrooup();
                    objCompany = lstCompany[0];
                    // objCompany.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                    objCompany.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                    // objCompany.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                    // objCompany.moduleId = Convert.ToInt32(HttpContext.Current.Session["ModuleId"]);

                    if (HttpContext.Current.Request.Files.Count > 0)
                    {
                        String sSaveAs = "";
                        String userDir = "/BoardMeeting/images/CompanyGroupLogo/";

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

                            objCompany.uploadAvatar = newFileName;
                        }
                    }
                    CompanyGroupRequest UserReq = new CompanyGroupRequest(objCompany);
                    companygroupResponse = UserReq.SaveCompanyGroup();
                }
            }
            catch (Exception ex)
            {
                // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                companygroupResponse.StatusFl = false;
                companygroupResponse.Msg = ex.Message;
            }
            return companygroupResponse;
        }

    }
}
