using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class DocumentLn : BaseEntity
    {
        public Int32 DocLnId { set; get; }
        public string DocTitle { set; get; }
        public string CreationDt { set; get; }
        public string DocStatus { set; get; }
        public string ApprovalStatus { set; get; }
        public string ReviewStatus { set; get; }
        public string DocVersion { set; get; }
        public string EffectiveDt { set; get; }
        public string WithdrawnDt { set; get; }
        public string DocUrl { set; get; }
        public string CreatorNm { set; get; }
        public string CreatorId { set; get; }
        public string CanEditMode { set; get; }
        public List<DocumentSection> lstDocSection { set; get; }
    }
}