using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class BaseResponse
    {
        public Boolean StatusFl { set; get; }
        public string Msg { set; get; }
    }
}