using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Repository;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Request
{
    public class UserRequest
    {
        private User _user;
        private UserRepository _userRepo;

        public UserRequest()
        {
        }

        public UserRequest(User user)
        {
            _user = new User();
            _user = user;
        }

        public UserResponse SaveUser()
        {
            try
            {
                _userRepo = new UserRepository();
                if (_user.ID == 0)
                {
                    return _userRepo.AddUser(_user);
                }
                else
                {
                    return _userRepo.UpdateUser(_user);
                }
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }


        }

        public UserResponse DeleteUser()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.DeleteUser(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public UserResponse GetUserList()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetUserList(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }


        public UserResponse GetAllUsersRole()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetAllUsersRole(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public UserResponse GetEmailList()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetEmailList(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public UserResponse GetUserDetails()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetUserDetails(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        //public UserResponse GetUsersForMeeting()
        //{
        //    try
        //    {
        //        _userRepo = new UserRepository();
        //        return _userRepo.GetUsersForMeeting(_user);
        //    }
        //    catch (Exception ex)
        //    {
        //        //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //        return null;
        //    }
        //}

        //public UserResponse GetUsersForComposition()
        //{
        //    try
        //    {
        //        _userRepo = new UserRepository();
        //        return _userRepo.GetUsersForComposition(_user);
        //    }
        //    catch (Exception ex)
        //    {
        //        //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //        return null;
        //    }
        //}

        //public UserResponse GetUserforCompositionAllUser()
        //{
        //    try
        //    {
        //        _userRepo = new UserRepository();
        //        return _userRepo.GetUserforCompositionAllUser(_user);
        //    }
        //    catch (Exception ex)
        //    {
        //        //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //        return null;
        //    }
        //}

        public UserResponse AddTemporaryUser()
        {
            try
            {
                _userRepo = new UserRepository();
                UserResponse userResponse = new UserResponse();
                if (_user.ID == 0)
                {
                    userResponse = _userRepo.AddTemporaryUser(_user);
                }
                return userResponse;
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public UserResponse GetUserNameByLoginId()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetUserNameByLoginId(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public UserResponse GetUserEmailById()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetUserEmailById(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public UserResponse GetUsersForCommitteeSuperAdmin()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetUsersForCommitteeSuperAdmin(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }


        //changes for BOD report by gaurav
        public UserResponse SaveAffiramation()
        {
            try
            {
                _userRepo = new UserRepository();
                if (_user.ID == 0)
                {
                    return _userRepo.SaveAffiramation(_user);
                }
                else
                {
                    return _userRepo.UpdateUser(_user);
                }
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public UserResponse GetAllUserByCompany()
        {
            try
            {
                _userRepo = new UserRepository();
                return _userRepo.GetAllUserByCompany(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }


        //private User _user;
        //public UserRequest() { }
        //public UserRequest(User user)
        //{
        //    _user = user;
        //}
        //public UserResponse GetAllUsers()
        //{
        //    UserRepository uRepo = new UserRepository();
        //    return uRepo.GetAllUsers(_user);
        //}
    }
}