using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.Login.Model
{
    public class BaseEntity
    {
        private List<String> _brokenRules = new List<String>();
        public virtual void Validate() { }
        public void ClearRules()
        {
            _brokenRules.Clear();
        }
        public void AddRule(String rule)
        {
            _brokenRules.Add(rule);
        }
        public List<String> GetRules()
        {
            return _brokenRules;
        }
    }
}