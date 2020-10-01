using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhononicEngWeb
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();           
            Response.Redirect("Login.aspx");
        }


    }
}