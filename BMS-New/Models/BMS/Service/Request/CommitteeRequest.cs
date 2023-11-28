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
        public CommitteeResponse DeleteCommittee_checkMeeting()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.DeleteCommittee_CheckMeeting(_committee);
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

        public CommitteeResponse SavecommitteeComposition()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();

                return _committeeRepo.SaveCommitteeComposition(_committee);
                if (_committee.ID == 0)
                {

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
        public CommitteeResponse ListCommitteeComposition()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetListCommitteesComposition(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse ListEditCommitteeComposition()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteeCompositionEdit(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse HistoryCommitteeComposition()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteeCompositionHistory(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }
        public CommitteeResponse DeleteCommitteecomposition()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.DeleteCommitteecomposition(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        //public CommitteeResponse BindCommitteeForComposition()
        //{
        //    try
        //    {
        //        _committeeRepo = new CommitteeRepository();
        //        return _committeeRepo.BindCommitteeForComposition(_committee);
        //    }
        //    catch (Exception ex)
        //    {
        //        new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
        //        return null;
        //    }
        //}

        public CommitteeResponse BindAllCommittee()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindAllCommittee(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse BindCommitteeForDraftMOM()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindCommitteeForDraftMOM(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse BindCommitteeForFinalMOM()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindCommitteeForFinalMOM(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse BindCommitteeForMeetingAttendanceReport()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindCommitteeForMeetingAttendanceReport(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse BindCommitteeForCompositionReport()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindCommitteeForCompositionReport(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse BindCommitteeForActivityLogReport()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindCommitteeForActivityLogReport(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse BindYear()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindYear(_committee);

            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse BindCommitteeForDepartmentWorkFlow()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.BindCommitteeForDepartmentWorkFlow(_committee);

            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }

        public CommitteeResponse GetCommitteeAuditRecord()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteeAuditRecord(_committee);

            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }
        public CommitteeResponse CommitteeCompositionAuditRecord()
        {
            try
            {
                _committeeRepo = new CommitteeRepository();
                return _committeeRepo.GetCommitteeCompositionAuditRecord(_committee);
            }
            catch (Exception ex)
            {
                new LogHelper().AddExceptionLogs(ex.Message.ToString(), ex.Source, ex.StackTrace, this.GetType().Name, new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name, Convert.ToString(HttpContext.Current.Session["EmployeeId"]), Convert.ToInt32(HttpContext.Current.Session["ModuleId"]));
                return null;
            }
        }
    }
}