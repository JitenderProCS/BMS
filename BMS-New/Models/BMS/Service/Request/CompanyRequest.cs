using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Repository;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Request
{
    public class CompanyRequest
    {
        private Company _company;
        private CompanyRepository _companyRepo;
        private CompanyResponse _companyRes;
        public CompanyRequest()
        {
        }

        public CompanyRequest(Company company)
        {
            _company = new Company();
            _company = company;
        }

        public CompanyResponse SaveCompany()
        {
            _companyRes = new CompanyResponse();
            try
            {
                _companyRepo = new CompanyRepository();
                if (_company.CompanyId == 0)
                {
                    _companyRes = _companyRepo.AddCompnay(_company);
                }
                else
                {
                    _companyRes = _companyRepo.UpdateCompany(_company);
                }
            }
            catch (Exception ex)
            {
                _companyRes.StatusFl = false;
                _companyRes.Msg = ex.Message;
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
            }
            return _companyRes;
        }


        public CompanyResponse GetCompanyList()
        {
            try
            {
                _companyRepo = new CompanyRepository();
                return _companyRepo.GetCompanyList(_company);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }
        //For AdminUser
        public CompanyResponse GetCompanyForAdminUserList()
        {
            try
            {
                _companyRepo = new CompanyRepository();
                return _companyRepo.GetCompanyForAdminUserList(_company);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }
        public CompanyResponse GetCompanyTypeList()
        {
            try
            {
                _companyRepo = new CompanyRepository();
                return _companyRepo.GetCompanyTypeList(_company);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }
    }
}