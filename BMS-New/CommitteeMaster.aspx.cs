using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BMS_New
{
    public partial class CommitteeMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Convert.ToString(Session["CompanyName"])))
            {
                CompanyName.InnerText = Convert.ToString(Session["CompanyName"]);
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

    }
}