using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class UserResponse : BaseResponse
    {
        private User _user;
        private List<User> lstUser;

        public User User
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

        public List<User> UserList
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

        public void AddObject(User o)
        {
            if (lstUser == null)
            {
                lstUser = new List<User>();
            }
            lstUser.Add(o);
        }

        //public User _usr { set; get; }
        //private List<User> _usrs;
        //public User Usr
        //{
        //    set { _usr = value; }
        //    get { return _usr; }
        //}
        //public List<User> Usrs
        //{
        //    set { _usrs = value; }
        //    get { return _usrs; }
        //}
        //public void AddUser(User obj)
        //{
        //    if (_usrs == null)
        //    {
        //        _usrs = new List<User>();
        //    }
        //    _usrs.Add(obj);
        //}
    }
}