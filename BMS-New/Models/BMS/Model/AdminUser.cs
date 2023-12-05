using BMS_New.Models.BMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class AdminUser : BaseEntity
    {
        public Int32 ID { get; set; }
        public Int32 Sequence { get; set; }
        //public string salutation { get; set; }
        public string userName { get; set; }
        public string emailId { get; set; }
        //public string userLogin { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string authentication { get; set; }
        //public Company company { get; set; }
       // public Int32  companyId { get; set; }
        public string CompanyName { get; set; }
        public Int32 moduleId { get; set; }
        public String moduleName { get; set; }
        /*****Add By Jitender*************/
        public string CREATED_BY { set; get; }
        public List<CompanyAccess> CompanyMapping { set; get; }
        /************End**********/

    }
    /*****Add By Jitender*************/
    public class CompanyAccess : BaseEntity
    {
        public Int32 ID { set; get; }
        //public string LOGIN_ID { set; get; }
        //public Int32 companyId { set; get; }
        public string CompanyCode { set; get; }
        public string CompanyName { set; get; }
        public string logo { set; get; }
        public Int32 moduleId { set; get; }
        public string moduleName { set; get; }
        public string modulefolder { set; get; }
        public string ModuleDataBase { set; get; }
        public string Mobile { set; get; }
        public string Role_Admin { set; get; }
        public string CREATE_BY { set; get; }
        public string STATUS { set; get; }
        public string STATUS1 { set; get; }
        public string selectedValue { set; get; }

    }
    /************End**********/
}