using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class AdminUserResponse : BaseResponse
    {
        private AdminUser _user;
        private List<AdminUser> lstUser;

        public AdminUser User
        {
            set
            {
                _user = value;
            }
            get
            {
                return _user;
            }
        }

        public List<AdminUser> UserList
        {
            set
            {
                lstUser = value;
            }
            get
            {
                return lstUser;
            }
        }

        public void AddObject(AdminUser o)
        {
            if (lstUser == null)
            {
                lstUser = new List<AdminUser>();
            }
            lstUser.Add(o);
        }
    }
}