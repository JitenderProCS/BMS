using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class Committee : BaseEntity
    {
        public Int32 ID { get; set; }
        /***Add By Jitender**********/
        public String NoOfMembers { get; set; }
        public String NoOfIndependentDirector { get; set; }
        public String NoOfWomenDirector { get; set; }
        /**********End***************/
        public String committeeName { get; set; }
        public String committeeABRR { get; set; }
        public String committeeSuperAdmins { get; set; }
        public String status { get; set; }
        public User superAdmin { get; set; }
        //public List<string> committeeAdmins1 { get; set; }
        public List<User> committeeAdmins { get; set; }
        public List<Role> roles { get; set; }
        public List<CommitteeMember> committeeMembers { get; set; }
        public Int32 companyId { get; set; }
        public String createdBy { get; set; }
        public String createdOn { get; set; }
        public String modifiedBy { get; set; }
        public String modifiedOn { get; set; }
        public String NoOfcommitteeMembers { get; set; }
        //public String moduleDatabase { set; get; }
        public String companyName { get; set; }
       // public CRLibrary crLibrary { get; set; }
        public Int32 isDelete { get; set; }
        public String remarks { get; set; }
        public String committeeModifiedDate { get; set; }
        public String CommitteeYear { get; set; }

        public override void Validate()
        {
            base.Validate();
        }
    }
}