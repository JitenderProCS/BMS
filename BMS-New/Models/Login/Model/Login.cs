using BMS_New.Models.Login.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.Login.Model
{
    public class Login : BaseEntity
    {
        public string LoginId { get; set; }
        public string Email { set; get; }
        public string Password { set; get; }
        public String newPassword { get; set; }
        public string UserName { set; get; }
        public string Mobile { set; get; }
        public Int32 DepartmentId { set; get; }
        public string DepartmentNm { set; get; }
        public Int32 DesignationId { set; get; }
        public string DesignationNm { set; get; }
       

        public string ModuleDataBase { set; get; }
        public Int32 RoleId { set; get; }
        public string RoleNm { set; get; }


        /****Add By Jitender*********/
      public List<UserAccess> UAccess { get; set; }
        /*********End**********/
        public override void Validate()
        {
            base.Validate();
        }
    }
}