using BMS_New.Models.BMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.Login.Modal
{
    public class UserAccess:BaseEntity
    {
        public Int32 GroupId { set; get; }
        public string GroupNm { set; get; }
        public string GroupLogo { set; get; }

        public Int32 CompanyId { set; get; }
        public string CompanyCode { set; get; }
        public string CompanyNm { set; get; }
        public string CompanyLogo { set; get; }

        public Int32 ModuleId { set; get; }
        public string ModuleNm { set; get; }
        public string ModuleLogo { set; get; }
        public string ModuleFolder { set; get; }
        public string ModuleDataBase { set; get; }

        public string moduleDataBase { set; get; }

        public string EmployeeId { set; get; }
        public string Mobile { set; get; }
        //public List<Committee> committeeList { get; set; }
        //public List<Meeting> listMeeting { get; set; }
    }
}