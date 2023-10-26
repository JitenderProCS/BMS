using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Repository;
using BMS_New.Models.BMS.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Request
{
    public class AdminUserRequest
    {
        private AdminUser _user;
        private AdminUserRepository _userRepo;

        public AdminUserRequest()
        {
        }

        public AdminUserRequest(AdminUser user)
        {
            _user = new AdminUser();
            _user = user;
        }

        public AdminUserResponse SaveUser()
        {
            try
            {
                _userRepo = new AdminUserRepository();
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

        public AdminUserResponse DeleteUser()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.DeleteUser(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public AdminUserResponse GetModuleList()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetModuleList(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public AdminUserResponse GetUserList()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetUserList(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public AdminUserResponse GetAllUsersRole()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetAllUsersRole(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public AdminUserResponse GetEmailList()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetEmailList(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public AdminUserResponse GetUserDetails()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetUserDetails(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }


        public AdminUserResponse GetUserNameByLoginId()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetUserNameByLoginId(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public AdminUserResponse GetUserEmailById()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetUserEmailById(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public AdminUserResponse GetUsersForCommitteeSuperAdmin()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetUsersForCommitteeSuperAdmin(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public AdminUserResponse FillUserDetails()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.FillUserDetails(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public AdminUserResponse GetUserCompanyList()
        {
            try
            {
                _userRepo = new AdminUserRepository();
                return _userRepo.GetUserCompanyList(_user);
            }
            catch (Exception ex)
            {
                //new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

    }
}