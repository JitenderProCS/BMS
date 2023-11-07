using BMS_New.Models.BMS.Model;
using BMS_New.Models.Infrastructure;
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
   [RoutePrefix("api/SwitchCompanyDashBoard")]
    public class SwitchDashBoardController : ApiController
    {
        [Route("SetSessionDashBoard")]
        [HttpPost]

        public void SetSessionDashBoard()
        {

        }

        //public String SetSessionDashBoard()
        //{
        //    try
        //    {
        //        string input;
        //        using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
        //        {
        //            input = sr.ReadToEnd();
        //        }
        //        CompanyAccess CompanyMapping = new JavaScriptSerializer().Deserialize<CompanyAccess>(input);
        //        HttpContext.Current.Session["CompanyId"] = CompanyMapping.companyId;
        //        HttpContext.Current.Session["CompanyName"] = CompanyMapping.CompanyName;
        //        HttpContext.Current.Session["CompanyLogo"] = CompanyMapping.logo;
        //        HttpContext.Current.Session["ModuleId"] = CompanyMapping.moduleId;
        //        HttpContext.Current.Session["ModuleName"] = CompanyMapping.moduleName;
        //        HttpContext.Current.Session["ModuleFolder"] = CompanyMapping.modulefolder;
        //        HttpContext.Current.Session["ModuleDatabase"] = CompanyMapping.ModuleDataBase;
        //       // HttpContext.Current.Session["ModuleDatabase"] = "PROCS_BOARD_MEETING_50";
        //        HttpContext.Current.Session["EmployeeId"] = CompanyMapping.LOGIN_ID;
        //        HttpContext.Current.Session["UserMobile"] = CompanyMapping.Mobile;
        //        return Convert.ToString(HttpContext.Current.Session["ModuleFolder"]);


        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
        //    }
        //    return String.Empty;
        //}
    }
}
