using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class DocumentSection : BaseEntity
    {
        public Int32 SectionId { set; get; }
        public string SectionNm { set; get; }
        public string SectionContent { set; get; }
    }
}