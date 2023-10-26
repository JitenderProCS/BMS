using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class CompanyGrooup : BaseEntity
    {
        public Int32 CompanyGroupId { get; set; }
        public String CompanyGroupName { get; set; }
        public String createdBy { get; set; }
        public String createdOn { get; set; }
        public String modifiedBy { get; set; }
        public String modifiedOn { get; set; }
        public String uploadAvatar { get; set; }
        public override void Validate()
        {
            base.Validate();
        }
    }
}