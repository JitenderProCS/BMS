using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.Login.Service.Response
{
    public class LoginResponse
    {
        public bool StatusFl { set; get; }
        public string Msg { set; get; }
        public BMS_New.Models.Login.Model.Login Usr { set; get; }
    }
}
