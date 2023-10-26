using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class Document : BaseEntity
    {
        public Int32 DocId { set; get; }
        public Int32 DocTypId { set; get; }
        public string DocTypNm { set; get; }
        public string DocTitle { set; get; }
        public string DocVersion { set; get; }
        public string DocStatus { set; get; }
        public string EffectiveDt { set; get; }
        public string DocUrl { set; get; }
        public List<DocumentLn> lstLn { set; get; }
        public List<User> lstUsr { set; get; }
    }
}