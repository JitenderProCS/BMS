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

namespace BMS_New.Controllers
{
    public class DesignationController : ApiController
    {
        string input;
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        DesignationResponse designationResponse = new DesignationResponse();

        [Route("GetDesignationList")]
        [HttpPost]
        
        public DesignationResponse GetDesignationList()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    designationResponse.StatusFl = false;
                    designationResponse.Msg = "SessionExpired";
                    return designationResponse;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Designation designation = new JavaScriptSerializer().Deserialize<Designation>(input);
                //designation.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                designation.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                //designation.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                designation.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                DesignationRequest gReqDesignationList = new DesignationRequest(designation);
                designationResponse = gReqDesignationList.GetDesignationList();
            }
            catch (Exception ex)
            {
               // new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                designationResponse.StatusFl = false;
                designationResponse.Msg = ex.Message;
            }
            return designationResponse;
        }

        [Route("SaveDesignation")]
        [HttpPost]
       
        public DesignationResponse SaveDesignation()
        {
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    designationResponse.StatusFl = false;
                    designationResponse.Msg = "SessionExpired";
                    return designationResponse;
                }

                List<Designation> lstDesignation = new List<Designation>();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                lstDesignation = serializer1.Deserialize<List<Designation>>(input);
                Designation objDesignation = new Designation();
                objDesignation = lstDesignation[0];
                objDesignation.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                objDesignation.companyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objDesignation.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                DesignationRequest designationReq = new DesignationRequest(objDesignation);
                designationResponse = designationReq.SaveDesignation();
            }
            catch (Exception ex)
            {
              //  new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                designationResponse.StatusFl = false;
                designationResponse.Msg = ex.Message;
            }
            return designationResponse;
        }
    }
}
