using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class Department: BaseEntity
    {
        public Int32 departmentId { get; set; }
        public String departmentName { get; set; }
        public string departmentHead { get; set; }
        //public Int32 companyId { get; set; }
        public String createdBy { get; set; }
        public String createdOn { get; set; }
        public String modifiedBy { get; set; }
        public String modifiedOn { get; set; }
        public override void Validate()
        {
            base.Validate();
        }
    }
}