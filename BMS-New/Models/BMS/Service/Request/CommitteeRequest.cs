using BMS_New.Models.BMS.Model;
using BMS_New.Models.BMS.Repository;
using BMS_New.Models.BMS.Service.Response;
using BMS_New.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Request
{
    public class CommitteeRequest
    {
        private Committee _committee;
        private CommitteeRepository _committeeRepo;

        public CommitteeRequest()
        {
        }

        public CommitteeRequest(Committee Committee)
        {
            _committee = new Committee();
            _committee = Committee;
        }

        public CommitteeResponse GetCommitteesMembersForMeeting()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteesMembers(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse userlistforcommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteesMembersForAdmin(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

               public CommitteeResponse CommitteeCoordinatorList()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.CommitteeCoordinatorUserList(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public CommitteeResponse listforcommitteerole()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteesRole(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public CommitteeResponse Savecommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                if (_committee.ID == 0)
                {
                    return _committeeRepo.SaveCommittee(_committee);
                }
                else
                {
                    return _committeeRepo.UpdateCommittee(_committee);
                }
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }
        public CommitteeResponse ListCommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetListCommittees(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse ListEditCommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommittee(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }
        public CommitteeResponse DeleteCommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.DeleteCommittee(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }

        }

        public CommitteeResponse BindCommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindCommittee(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }


        public CommitteeResponse HistoryCommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteeHistory(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }
    }
}