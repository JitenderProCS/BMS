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
                //HttpContext.Current.Session["ModuleDatabase"] = usraccess.moduleDatabase;
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
    }
}
