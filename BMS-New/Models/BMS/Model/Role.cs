﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class Role: BaseEntity
    {
        public Int32 Id { get; set; }
        public String role { get; set; }
        public Int32 attendanceRptSequence { get; set; }

        public override void Validate()
        {
            base.Validate();
        }
    }
}