using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Repository;
using BMS_New.Models.BMS.Service.Response;
using BMS_New.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BMS_New.Models.BMS.Service.Request
{
    public class DepartmentRequest: IRequiresSessionState
    {
        private Department _department;
        private DepartmentRepository _departmentRepo;
        private DepartmentResponse _departmentRes;

        public DepartmentRequest()
        {
        }

        public DepartmentRequest(Department department)
        {
            _department = new Department();
            _department = department;
        }

        public DepartmentResponse SaveDepartment()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                if (_department.departmentId == 0)
                {
                    _departmentRes = _departmentRepo.AddDepartment(_department);
                }
                else
                {
                    _departmentRes = _departmentRepo.UpdateDepartment(_department);
                }
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }

        public DepartmentResponse DeleteDepartment()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                return _departmentRepo.DeleteDepartment(_department);
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }

        public DepartmentResponse GetDepartmentList()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                _departmentRes = _departmentRepo.GetDepartmentList(_department);
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }

        public DepartmentResponse GetDepartmentsForUser()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                _departmentRes = _departmentRepo.GetDepartmentsForUser(_department);
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }

        public DepartmentResponse GetDepartmentForWorkFlow()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                _departmentRes = _departmentRepo.GetDepartmentForWorkFlow(_department);
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }

        public DepartmentResponse GetDepartmentForAgenda()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                _departmentRes = _departmentRepo.GetDepartmentForAgenda(_department);
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }

        public DepartmentResponse getDepartmentAuditRecord()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                _departmentRes = _departmentRepo.getDepartmentAuditRecord(_department);
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }
        public DepartmentResponse GetUserDepartmentId()
        {
            _departmentRes = new DepartmentResponse();
            try
            {
                _departmentRepo = new DepartmentRepository();
                _departmentRes = _departmentRepo.GetUserDepartmentId(_department);
            }
            catch (Exception ex)
            {
                _departmentRes.StatusFl = false;
                _departmentRes.Msg = ex.Message;
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _departmentRes;
        }
    }
}