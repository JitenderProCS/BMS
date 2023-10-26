using BMS_New.Models.BMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class CompanyResponse : BaseResponse
    {
        private Company _company;
        private List<Company> _lstCompany;

        public Company Company
        {
            set
            {
                _company = value;
            }
            get
            {
                return _company;
            }
        }
        //public List<Company> companys
        //{
        //    set { _lstCompany = value; }
        //    get { return companys; }
        //}
        public List<Company> CompanyList
        {
            set
            {
                _lstCompany = value;
            }
            get
            {
                return _lstCompany;
            }
        }
        public void AddCompany(Company obj)
        {
            if (_lstCompany == null)
            {
                _lstCompany = new List<Company>();
            }
            _lstCompany.Add(obj);
        }
    }
}