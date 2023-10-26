using BMS_New.Models.Login.Repository;
using BMS_New.Models.Login.Service.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.Login.Service.Request
{
    public class LoginRequest
    {

        BMS_New.Models.Login.Model.Login _usr;
        public LoginRequest(BMS_New.Models.Login.Model.Login usr)
        {
            _usr = usr;
        }
        public LoginResponse ValidateUser()
        {
            try
            {
                LoginRepository lRep = new LoginRepository();
                return lRep.ValidateUser(_usr);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public LoginResponse SetSessionStatus()
        {
            LoginRepository rep = new LoginRepository();
            return rep.SetSessionStatus(_usr);
        }
    }
}