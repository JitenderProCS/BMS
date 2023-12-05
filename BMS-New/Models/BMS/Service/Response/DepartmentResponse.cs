using BMS_New.Models.BMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class DepartmentResponse:BaseResponse
    {
        private Department _department;
        private List<Department> _lstDepartment;

        public Department Department
        {
            set
            {
                _department = value;
            }
            get
            {
                return _department;
            }
        }

        public List<Department> DepartmentList
        {
            set
            {
                _lstDepartment = value;
            }
            get
            {
                return _lstDepartment;
            }
        }

        public void AddObject(Department o)
        {
            if (_lstDepartment == null)
            {
                _lstDepartment = new List<Department>();
            }
            _lstDepartment.Add(o);
        }
    }
}