using System;
using BMS_New.Models.BMS.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class User : BaseEntity
    {
        //public string UserNm { set; get; }
        //public string UserLogin { set; get; }
        //public string UserEmail { set; get; }
        //public string UserPwd { set; get; }
        //public string UserMobile { set; get; }
        //public string Status { set; get; }
        //public int RoleId { set; get; }
        //public string RoleNm { set; get; }
        //public int DeptId { set; get; }
        //public string DeptNm { set; get; }
        //public int DesigId { set; get; }
        //public string DesigNm { set; get; }
        //public string ReactionTm { set; get; }
        //public string UserRemark { set; get; }

        public Int32 ID { get; set; }
        public Int32 Sequence { get; set; }
        public string salutation { get; set; }
        public string userName { get; set; }
        public string userFirstName { get; set; }
        public string userMiddleName { get; set; }
        public string userLastName { get; set; }
        public string emailId { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string tenureStartDate { get; set; }
        public string tenureEndDate { get; set; }
        public string dateOfBirth { get; set; }
        public string nationality { get; set; }
        public string userLogin { get; set; }
        public string password { get; set; }
        public string status { get; set; }


        //2 Prop for D
        public string UserRemark { set; get; }
        public string ReactionTm { set; get; }
        public string comments { get; set; }
        public string reviewedOn { get; set; }
        public List<string> lstMemberCommunicationAttachment { get; set; }
        public string uploadAvatar { get; set; }
        public Int32 companyId { get; set; }
        public Int32 moduleId { get; set; }
        public string createdBy { get; set; }
        public string createdOn { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedOn { get; set; }
        //public Committee committee { get; set; }
        public string role { get; set; }
        public bool isChecked { get; set; }
        public int CHECKED { get; set; }
        //public Designation designation { get; set; }
        //public Category category { get; set; }
        public string designation { get; set; }
        public string category { get; set; }
        public Int32 version { get; set; }
        public string profile { get; set; }
        public string attendanceStatus { get; set; }
        public string markedByDirectorOn { get; set; }
        //public Int32 score { get; set; }
        public decimal score { get; set; }
        public string questionRemark { get; set; }
        //public Department department { get; set; }
        public string department { get; set; }

        //add more field for director open
        public string txtdp_pan { get; set; }
        public string panremark { get; set; }
        public string txtdin_pan { get; set; }
        public string din_remark { get; set; }
        public string ddlcat1 { get; set; }
        public string ddlcat2 { get; set; }
        public string ddlcat3 { get; set; }
        public string ddl17A { get; set; }
        public string txtdate { get; set; }
        public string no_of_directorship { get; set; }
        public string no_of_independent { get; set; }
        public string no_of_membership { get; set; }
        public string no_of_post_of_chairperson { get; set; }
        public string occupation_Area { get; set; }
        public string educational_Qualification { get; set; }
        public string experience { get; set; }
        public string gender { get; set; }
        public string aadhar_Number { get; set; }
        public string shareHolding { get; set; }
        public string shareHolding_percentage { get; set; }
        public string currency_Symbol { get; set; }
        public string sitting_Amount { get; set; }
        public string payment_mode { get; set; }
        public string remuneration_Amount { get; set; }
        public string appointed_Section { get; set; }
        //public string other_Companies { get; set; }
        //public IEnumerable<companyList> multi_Companies { get; set; }
        public List<string> multi_Companies { get; set; }
        public string keyCompany { get; set; }
        public string committees_Already_director { get; set; }
        public string membership_Num_Secretarial_User { get; set; }

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
    public class companyList
    {
        public string Companies { get; set; }
    }
}