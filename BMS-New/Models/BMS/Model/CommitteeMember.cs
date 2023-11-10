using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class CommitteeMember : BaseEntity
    {
        public Int32 ID { get; set; }
        public string name { get; set; }
        public User member { get; set; }
        public Designation designation { get; set; }
        public Int32 sequence { get; set; }
        public String createdBy { get; set; }
        public String modifiedBy { get; set; }
        public Int32 version { get; set; }
        public string createdon { get; set; }
        public string committeeModifiedDate { get; set; }
        public string remarks { get; set; }
        public string finalApprover { get; set; }
        public override void Validate()
        {
            base.Validate();
        }
    }
}