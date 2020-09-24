using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using ActiveDirectory;

namespace PhononicEngWeb.Lib
{
    public class CustomPage :System.Web.UI.Page
    {
       public CustomPage()
        {
            this.Load += new EventHandler(this.Page_load);
        }

        protected void Page_load(object sender , EventArgs e)
        {
            // if session user is empty then 
            // get the logged in user 
            // check if is in the valid ad group 
            // if true then continue
            // else redirect to login page 

            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    string loggedInWindowsUser = WindowsIdentity.GetCurrent().Name;
                    if (AdService.IsInGroup())
                    {
                        Session["UserId"] = loggedInWindowsUser;
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }            
        }
    }
}