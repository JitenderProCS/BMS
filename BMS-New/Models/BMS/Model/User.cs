using System;
using BMS_New.Models.BMS.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class User : BaseEntity
    {
        public Int32 ID { get; set; }
        public Int32 Sequence { get; set; }
        public String salutation { get; set; }
        public String userLogin { get; set; }
        public String userName { get; set; }
        //public Role role { get; set; }
        public String userFirstName { get; set; }
        public String userMiddleName { get; set; }
        public String userLastName { get; set; }
        public String emailId { get; set; }
        public String phone { get; set; }
        public String address { get; set; }
        public String tenureStartDate { get; set; }
        public String tenureEndDate { get; set; }
        public String dateOfBirth { get; set; }
        public String nationality { get; set; }
        public String password { get; set; }
        public String status { get; set; }


        //2 Prop for D
        public String UserRemark { set; get; }
        public String ReactionTm { set; get; }
        public String comments { get; set; }
        public String reviewedOn { get; set; }
        public List<string> lstMemberCommunicationAttachment { get; set; }
        public string uploadAvatar { get; set; }
        //public Int32 companyId { get; set; }
        public Int32 moduleId { get; set; }
        public String createdBy { get; set; }
        public String createdOn { get; set; }
        public String modifiedBy { get; set; }
        public String modifiedOn { get; set; }
        public Role role { get; set; }
        //public Committee committee { get; set; }
        //public string role { get; set; }
        public bool isChecked { get; set; }
        public int CHECKED { get; set; }
        public Designation designation { get; set; }
        //public Designation committeedesignation { get; set; }
        //public List<CommitteeMember> committeeMembers { get; set; }
        //public string designation { get; set; }
        public String category { get; set; }
        public Int32 version { get; set; }
        public String profile { get; set; }
        public String attendanceStatus { get; set; }
        public string markedByDirectorOn { get; set; }
        //public Int32 score { get; set; }
        public decimal score { get; set; }
        public string questionRemark { get; set; }
        public Department department { get; set; }
        //public string department { get; set; }

        //add more field for director open
        public String txtdp_pan { get; set; }
        public String panremark { get; set; }
        public String txtdin_pan { get; set; }
        public String din_remark { get; set; }
        public String txtdate { get; set; }
        public String no_of_directorship { get; set; }
        public String no_of_independent { get; set; }
        public String no_of_membership { get; set; }
        public String no_of_post_of_chairperson { get; set; }
        public String occupation_Area { get; set; }
        public String educational_Qualification { get; set; }
        public String experience { get; set; }
        public String gender { get; set; }
        public String aadhar_Number { get; set; }
        public String shareHolding { get; set; }
        public String shareHolding_percentage { get; set; }
        public String currency_Symbol { get; set; }
        public String sitting_Amount { get; set; }
        public string payment_mode { get; set; }
        public string remuneration_Amount { get; set; }
        public string appointed_Section { get; set; }
        //public string other_Companies { get; set; }
        //public IEnumerable<companyList> multi_Companies { get; set; }
        public List<string> multi_Companies { get; set; }
        public string keyCompany { get; set; }
        public String committees_Already_director { get; set; }
        public String membership_Num_Secretarial_User { get; set; }

        //add more field for director close


        public string year { get; set; }
        public string first { get; set; }
        public string first1 { get; set; }
        public string first2 { get; set; }
        public string first3 { get; set; }
        public string first4 { get; set; }
        public string first5 { get; set; }
        public string first6 { get; set; }
        public string first7 { get; set; }
        public string first8 { get; set; }
        public int workflowSeq { get; set; }
        public string downloadReportUrl { get; set; }
        public bool includeSignature { get; set; }
        public bool isApprovedByUser { get; set; }
        public string taskStatus { get; set; }
        public string venue { get; set; }
        public string joinTime { get; set; }
        public string exitTime { get; set; }

        public string meetingId { get; set; }


    }
    public class companyList: BaseEntity
    {
        public string Companies { get; set; }
    }
}