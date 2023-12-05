using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Model
{
    public class BaseEntity
    {
        public String moduleDatabase { get; set; }
        public Int32 CompanyId { get; set; }
        public string LoginId { set; get; }
        public String operation { get; set; }
        public String operation_Dt { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public virtual void Validate() { }
        public Boolean ValidateInput()
        {
            Type objType = this.GetType();
            foreach (System.Reflection.PropertyInfo propertyInfo in objType.GetProperties())
            {

                if (!propertyInfo.PropertyType.IsGenericType)
                {
                    if (!propertyInfo.PropertyType.FullName.StartsWith("BMS"))
                    {
                        if (propertyInfo.PropertyType.Name.ToUpper() == "STRING")
                        {
                            string sVal = (string)propertyInfo.GetValue(this, null);

                            if (sVal != null)
                            {
                                if (sVal.ToUpper().Contains("<SCRIPT")
                                    || sVal.ToUpper().Contains("ALERT") || sVal.ToUpper().Contains("CREATE")
                                    || sVal.ToUpper().Contains("DROP") || sVal.ToUpper().Contains("TRUNCATE")
                                    || sVal.ToUpper().Contains("UPDATE") || sVal.ToUpper().Contains("XSS")
                                   )
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {

                        if (propertyInfo.GetValue(this, null) != null)
                        {
                            dynamic o = propertyInfo.GetValue(this, null);
                            if (!o.ValidateInput())
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    string s2x = propertyInfo.PropertyType.FullName.ToUpper();
                    if (!s2x.Contains("SYSTEM.DATETIME"))
                    {
                        if (propertyInfo.GetValue(this, null) != null)
                        {
                            dynamic oSelf = this;
                            int cnt = propertyInfo.GetValue(oSelf, null).Count;
                            if (cnt > 0)
                            {
                                for (int cntNum = 0; cntNum < cnt; cntNum++)
                                {
                                    dynamic o = propertyInfo.GetValue(oSelf, null)[cntNum];
                                    string s1 = o.GetType().FullName;
                                    if (s1.StartsWith("DMS"))
                                    {
                                        if (!o.ValidateInput())
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}