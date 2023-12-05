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
    public class DesignationRequest : IRequiresSessionState
    {
        private Designation _designation;
        private Category _category;
        private DesignationRepository _designationRepo;

        public DesignationRequest()
        {
        }

        public DesignationRequest(Designation designation)
        {
            _designation = new Designation();
            _designation = designation;
        }

        public DesignationRequest(Category category)
        {
            _category = new Category();
            _category = category;
        }

        public DesignationResponse SaveDesignation()
        {
            try
            {
                _designationRepo = new DesignationRepository();
                if (_designation.ID == 0)
                {
                    return _designationRepo.AddDesignation(_designation);
                }
                else
                {
                    return _designationRepo.UpdateDesignation(_designation);
                }
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        //public DesignationResponse DeleteDesignation()
        //{
        //    try
        //    {
        //        _designationRepo = new DesignationRepository();
        //        return _designationRepo.DeleteDesignation(_designation);
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //        return null;
        //    }
        //}

        public DesignationResponse GetDesignationList()
        {
            try
            {
                _designationRepo = new DesignationRepository();
                return _designationRepo.GetDesignationList(_designation);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public DesignationResponse GetDesignation()
        {
            try
            {
                _designationRepo = new DesignationRepository();
                return _designationRepo.GetDesignation(_designation);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public DesignationResponse GetCategory()
        {
            try
            {
                _designationRepo = new DesignationRepository();
                return _designationRepo.GetCategory(_category);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }


        //public DesignationResponse getDesignationAuditRecord()
        //{
        //    try
        //    {
        //        _designationRepo = new DesignationRepository();
        //        return _designationRepo.getDesignationAuditRecord(_designation);
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //        return null;
        //    }
        //}

    }
}