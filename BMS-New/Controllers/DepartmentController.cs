using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Request;
using BMS_New.Models.BMS.Service.Response;
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
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {
        string input;
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        DepartmentResponse _departmentRes;
        DepartmentRequest _departmentReq;

        [Route("GetDepartmentList")]
        [HttpPost]
        public DepartmentResponse GetDepartmentList()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    _departmentRes.StatusFl = false;
                    _departmentRes.Msg = "SessionExpired";
                    return _departmentRes;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Department objDepartment = new JavaScriptSerializer().Deserialize<Department>(input);
                objDepartment.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                objDepartment.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objDepartment.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                _departmentReq = new DepartmentRequest(objDepartment);
                _departmentRes = _departmentReq.GetDepartmentList();
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
            }
            return _departmentRes;
        }

        [Route("SaveDepartment")]
        [HttpPost]
        public DepartmentResponse SaveDepartment()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    _departmentRes.StatusFl = false;
                    _departmentRes.Msg = "SessionExpired";
                    return _departmentRes;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Department objDepartment = serializer1.Deserialize<Department>(input);
                //objDepartment.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                objDepartment.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                objDepartment.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objDepartment.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                _departmentReq = new DepartmentRequest(objDepartment);
                _departmentRes = _departmentReq.SaveDepartment();
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
            }
            return _departmentRes;
        }

        [Route("DeleteDepartment")]
        [HttpPost]
        public DepartmentResponse DeleteDepartment()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    _departmentRes.StatusFl = false;
                    _departmentRes.Msg = "SessionExpired";
                    return _departmentRes;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Department objDepartment = serializer1.Deserialize<Department>(input);
                objDepartment.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                objDepartment.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objDepartment.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                _departmentReq = new DepartmentRequest(objDepartment);
                _departmentRes = _departmentReq.DeleteDepartment();
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
            }
            return _departmentRes;
        }

        [Route("GetDepartmentsForUser")]
        [HttpPost]
        public DepartmentResponse GetDepartmentsForUser()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    _departmentRes.StatusFl = false;
                    _departmentRes.Msg = "SessionExpired";
                    return _departmentRes;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Department objDepartment = new JavaScriptSerializer().Deserialize<Department>(input);
                objDepartment.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                objDepartment.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objDepartment.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                _departmentReq = new DepartmentRequest(objDepartment);
                _departmentRes = _departmentReq.GetDepartmentsForUser();
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
            }
            return _departmentRes;
        }

        [Route("getDepartmentAuditRecord")]
        [HttpPost]
        public DepartmentResponse getDepartmentAuditRecord()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    _departmentRes.StatusFl = false;
                    _departmentRes.Msg = "SessionExpired";
                    return _departmentRes;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Department objDepartment = new JavaScriptSerializer().Deserialize<Department>(input);
                objDepartment.createdBy = Convert.ToString(HttpContext.Current.Session["EMPLOYEE_ID"]);
                objDepartment.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objDepartment.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                _departmentReq = new DepartmentRequest(objDepartment);
                _departmentRes = _departmentReq.getDepartmentAuditRecord();
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
            }
            return _departmentRes;
        }

        [Route("GetUserDepartmentId")]
        [HttpPost]
        public DepartmentResponse GetUserDepartmentId()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                if (HttpContext.Current.Session.Count == 0)
                {
                    _departmentRes.StatusFl = false;
                    _departmentRes.Msg = "SessionExpired";
                    return _departmentRes;
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    input = sr.ReadToEnd();
                }
                Department objDepartment = new JavaScriptSerializer().Deserialize<Department>(input);
                objDepartment.createdBy = Convert.ToString(HttpContext.Current.Session["EmployeeId"]);
                objDepartment.CompanyId = Convert.ToInt32(HttpContext.Current.Session["CompanyId"]);
                objDepartment.moduleDatabase = Convert.ToString(HttpContext.Current.Session["ModuleDatabase"]);
                _departmentReq = new DepartmentRequest(objDepartment);
                _departmentRes = _departmentReq.GetUserDepartmentId();
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]), Convert.ToInt32(HttpContext.Current.Session["CompanyId"]));
            }
            return _departmentRes;
        }

    }
}
