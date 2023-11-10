using BMS_New.Models.BMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class CommitteeResponse : BaseResponse
    {
        private Committee _committee;
        private List<Committee> lstCommittee;

        public Committee Committee
        {
            set
            {
                _committee = value;
            }
            get
            {
                return _committee;
            }
        }

        public List<Committee> CommitteeList
        {
            set
            {
                lstCommittee = value;
            }
            get
            {
                return lstCommittee;
            }
        }
        public void AddObject(Committee o)
        {
            if (lstCommittee == null)
            {
                lstCommittee = new List<Committee>();
            }
            lstCommittee.Add(o);
        }
    }
}