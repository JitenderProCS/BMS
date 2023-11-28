using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class Designation : BaseEntity
    {
        public Int32 ID { get; set; }
        public Int32 Sequence { get; set; }
        public string designationName { get; set; }
        public Int32 companyId { get; set; }
        public String createdBy { get; set; }
        public String createdOn { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedOn { get; set; }
        public override void Validate()
        {
            base.Validate();
        }
    }

}