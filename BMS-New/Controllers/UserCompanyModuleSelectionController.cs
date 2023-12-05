using BMS_New.Models.BMS.Model;
using BMS_New.Models.Infrastructure;
using BMS_New.Models.Login.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace BMS_New.Controllers
{
    [RoutePrefix("api/UserCompanyModuleListing")]
    public class UserCompanyModuleSelectionController : ApiController
    {
        [Route("SetSession")]
        [HttpPost]
        public String SetSession()
        {
            try
            {
                string input;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                UserAccess usraccess = new JavaScriptSerializer().Deserialize<UserAccess>(input);
                HttpContext.Current.Session["CompanyId"] = usraccess.CompanyId;
                HttpContext.Current.Session["CompanyName"] = usraccess.CompanyNm;
                HttpContext.Current.Session["CompanyLogo"] = usraccess.CompanyLogo;
                HttpContext.Current.Session["ModuleId"] = usraccess.ModuleId;
                 HttpContext.Current.Session["ModuleName"] = usraccess.ModuleNm;
                HttpContext.Current.Session["ModuleFolder"] = usraccess.ModuleFolder;
                //HttpContext.Current.Session["ModuleDatabase"] = usraccess.ModuleDataBase;
                HttpContext.Current.Session["ModuleDatabase"] = "PROCS_BOARD_MEETING_50";
                HttpContext.Current.Session["EmployeeId"] = usraccess.EmployeeId;
                HttpContext.Current.Session["UserMobile"] = usraccess.Mobile;
                return Convert.ToString(HttpContext.Current.Session["ModuleFolder"]);


            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
            }
            return String.Empty;
        }

        [Route("SetSessionDashBoard")]
        [HttpPost]
        public string SetSessionDashBoard()
        {
            try
            {
                string input;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }

                List<CompanyAccess> data = new JavaScriptSerializer().Deserialize<List<CompanyAccess>>(input);

                foreach (CompanyAccess p in data)
                {
                    HttpContext.Current.Session["CompanyId"] = p.CompanyId;
                    HttpContext.Current.Session["CompanyName"] = p.CompanyName;
                    HttpContext.Current.Session["CompanyLogo"] = p.logo;
                    HttpContext.Current.Session["ModuleId"] = p.moduleId;
                    HttpContext.Current.Session["ModuleName"] = p.moduleName;
                    HttpContext.Current.Session["ModuleFolder"] = p.modulefolder;
                    //HttpContext.Current.Session["ModuleDatabase"] = p.ModuleDataBase;
                    HttpContext.Current.Session["ModuleDatabase"] = "PROCS_BOARD_MEETING_50";
                    HttpContext.Current.Session["EmployeeId"] = p.LoginId;
                    HttpContext.Current.Session["UserMobile"] = p.Mobile;
                }

                // You can return a response if needed, for example, a success message or status code.
                return "Session data set successfully";
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));

                // Handle the error, return an error message or status code.
                return "Error: " + ex.Message;
            }
        }


        //[Route("SetSessionDashBoard")]
        //[HttpPost]
        //public String SetSessionDashBoard()
        //{
        //    try
        //    {
        //        string input;
        //        using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
        //        {
        //            input = sr.ReadToEnd();
        //        }
        //        //CompanyAccess CompanyMapping = new JavaScriptSerializer().Deserialize<CompanyAccess>(input);
        //        //HttpContext.Current.Session["CompanyId"] = CompanyMapping.companyId;
        //        //HttpContext.Current.Session["CompanyName"] = CompanyMapping.CompanyName;
        //        //HttpContext.Current.Session["CompanyLogo"] = CompanyMapping.logo;
        //        //HttpContext.Current.Session["ModuleId"] = CompanyMapping.moduleId;
        //        //HttpContext.Current.Session["ModuleName"] = CompanyMapping.moduleName;
        //        //HttpContext.Current.Session["ModuleFolder"] = CompanyMapping.modulefolder;
        //        //HttpContext.Current.Session["ModuleDatabase"] = CompanyMapping.ModuleDataBase;
        //        //// HttpContext.Current.Session["ModuleDatabase"] = "PROCS_BOARD_MEETING_50";
        //        //HttpContext.Current.Session["EmployeeId"] = CompanyMapping.LOGIN_ID;
        //        //HttpContext.Current.Session["UserMobile"] = CompanyMapping.Mobile;
        //        //return Convert.ToString(HttpContext.Current.Session["ModuleFolder"]);
        //        List<CompanyAccess> data = new JavaScriptSerializer().Deserialize<List<CompanyAccess>>(input);
        //        foreach (CompanyAccess p in data)
        //        {
        //            p.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
        //            p.CompanyName = Convert.ToString(HttpContext.Current.Session["CompanyName"]);
        //            p.logo = Convert.ToString(HttpContext.Current.Session["CompanyLogo"]);
        //            p.moduleId = Convert.ToInt32(HttpContext.Current.Session["ModuleId"]);
        //            p.moduleName = Convert.ToString(HttpContext.Current.Session["ModuleName"]);
        //            p.modulefolder = Convert.ToString(HttpContext.Current.Session["ModuleFolder"]);
        //            p.ModuleDataBase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
        //            p.LOGIN_ID = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
        //            p.Mobile = Convert.ToString(HttpContext.Current.Session["UserMobile"]);

        //        }
        //       // return Convert.ToString(HttpContext.Current.Session["ModuleFolder"]);
        //        //return Convert.ToString(HttpContext.Current.Session["ModuleFolder"]);
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
        //    }
        //    return String.Empty;
        //}
    }
}
