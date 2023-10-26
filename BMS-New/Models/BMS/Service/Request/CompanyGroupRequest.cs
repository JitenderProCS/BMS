using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Repository;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Request
{
    public class CompanyGroupRequest
    {
        private CompanyGrooup _companygroup;
       private CompanyGroupRepository _companyGroupRepo;
        private CompanyGroupResponse _companygroupRes;

        public CompanyGroupRequest()
        {
        }

        public CompanyGroupRequest(CompanyGrooup companygroup)
        {
            _companygroup = new CompanyGrooup();
            _companygroup = companygroup;
        }

        public CompanyGroupResponse SaveCompanyGroup()
        {
            _companygroupRes = new CompanyGroupResponse();
            try
            {
                _companyGroupRepo = new CompanyGroupRepository();
                if (_companygroup.CompanyGroupId == 0)
                {
                    _companygroupRes = _companyGroupRepo.AddCompnayGroup(_companygroup);
                }
                else
                {
                    _companygroupRes = _companyGroupRepo.UpdateCompanyGroup(_companygroup);
                }
            }
            catch (Exception ex)
            {
                _companygroupRes.StatusFl = false;
                _companygroupRes.Msg = ex.Message;
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companygroupRes;
        }


        public CompanyGroupResponse GetCompanyGroupList()
        {
            try
            {
                _companyGroupRepo = new CompanyGroupRepository();
                return _companyGroupRepo.GetCompanyGroupList(_companygroup);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }
    }
}