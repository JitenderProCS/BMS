using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class APIUser :BaseEntity
    {
        public Int32 Id { get; set; }
        public Int32 companyId { get; set; }
        public String UserName { get; set; }
        public String userProfile { get; set; }
        public String Email { get; set; }
        public string usercategory { get; set; }
        public string userdesignation { get; set; }
        public String userMobile { get; set; }
        //public String LoginId { get; set; }
        public String Password { get; set; }
        public String role { get; set; }
        public String tenureStartDate { get; set; }
        public String tenureEndDate { get; set; }
        public String dateOfBirth { get; set; }
        public String nationality { get; set; }
        public String status { get; set; }
        public String userAddress { get; set; }
        public String uploadAvatar { get; set; }
        public String fdfSyncDate { get; set; }
        public String votingStatus { get; set; }
        public String votedOn { get; set; }
        public bool twoFactorAuthentication { get; set; }
        public Int32 otp { get; set; }
        public DateTime otpGeneratedTime { get; set; }
        public DateTime otpExpiryTime { get; set; }
        //public List<APIUserAccess> UAccess { get; set; }
        //public APIUserVoting objUserVoting { get; set; }
        public Int32 committeeId { get; set; }
        public Int32 meetingId { get; set; }
        public List<CommitteeComposition> lstCommiteeComposition { get; set; }
        //public PendingCounts pendingCounts { get; set; }
        //public List<Notifications> lstNotification { set; get; }
        public String committeeABRRList { get; set; }
        public Int32 Year { get; set; }
        public string SearchLibrary { get; set; }
        public string SearchText { get; set; }
        public int themeId { get; set; }
        public int languageId { get; set; }
        public int timeZoneId { get; set; }
    }
    public class CommitteeComposition
    {
        public String committeeName { get; set; }
        public String committeeABRR { get; set; }
    }
}