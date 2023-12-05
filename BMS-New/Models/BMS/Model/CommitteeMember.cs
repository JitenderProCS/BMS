using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class CommitteeMember : BaseEntity
    {
        public Int32 ID { get; set; }
        public Int32 Sequence { get; set; }
        public String UserLogin { get; set; }
        public String UserNm { get; set; }
        public String CommitteeDesignationName { get; set; }
        public Int32 CommitteeRoleId { get; set; }
        public String createdBy { get; set; }
        public String modifiedBy { get; set; }
        public Int32 version { get; set; }
        public string createdon { get; set; }
        public string committeeModifiedDate { get; set; }
       // public CommitteeRole committeerole { get; set; }
        //public Designation designation { get; set; }
        public override void Validate()
        {
            base.Validate();
        }
    }
}