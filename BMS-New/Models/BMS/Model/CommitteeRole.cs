using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class CommitteeRole :BaseEntity
    {
        public Int32 Id { get; set; }
        public Int32 UserID { get; set; }
        public String committeerole { get; set; }
        public string userName { get; set; }
        public override void Validate()
        {
            base.Validate();
        }
    }
}