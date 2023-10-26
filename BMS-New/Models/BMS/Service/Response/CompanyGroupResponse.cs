using BMS_New.Models.BMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class CompanyGroupResponse : BaseResponse
    {
        private CompanyGrooup _companygroup;
        private List<CompanyGrooup> _lstCompanygroup;

        public CompanyGrooup CompanyGroup
        {
            set
            {
                _companygroup = value;
            }
            get
            {
                return _companygroup;
            }
        }
        public List<CompanyGrooup> CompanyGroupList
        {
            set
            {
                _lstCompanygroup = value;
            }
            get
            {
                return _lstCompanygroup;
            }
        }
        public void AddCompany(CompanyGrooup obj)
        {
            if (_lstCompanygroup == null)
            {
                _lstCompanygroup = new List<CompanyGrooup>();
            }
            _lstCompanygroup.Add(obj);
        }
    }
}