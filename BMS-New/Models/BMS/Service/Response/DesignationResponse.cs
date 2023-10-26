using BMS_New.Models.BMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS_New.Models.BMS.Service.Response
{
    public class DesignationResponse : BaseResponse
    {
        private Designation _designation;
        private List<Designation> lstDesignation;

        private Category _category;
        private List<Category> lstCategory;

        public Designation Designation
        {
            set
            {
                _designation = value;
            }
            get
            {
                return _designation;
            }
        }

        public List<Designation> DesignationList
        {
            set
            {
                lstDesignation = value;
            }
            get
            {
                return lstDesignation;
            }
        }

        public Category Category
        {
            set
            {
                _category = value;
            }
            get
            {
                return _category;
            }
        }

        public List<Category> CategoryList
        {
            set
            {
                lstCategory = value;
            }
            get
            {
                return lstCategory;
            }
        }

        public void AddObject(Designation o)
        {
            if (lstDesignation == null)
            {
                lstDesignation = new List<Designation>();
            }
            lstDesignation.Add(o);
        }
    }
}