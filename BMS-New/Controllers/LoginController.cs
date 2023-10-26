using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BMS_New.Controllers
{

    public class LoginController : ApiController
    {
        [HttpGet]
        public string Home()
        {
            string str = "deepak";

            return str;
        }

        [HttpPost]
        public string Login(string Name,string Pass)
        {
            string str = Name;
            string str2 = Pass;
            return str + str2;
        }
    }
}
