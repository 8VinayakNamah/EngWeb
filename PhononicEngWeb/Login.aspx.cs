using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActiveDirectory;
using System.Configuration;
using log4net;

namespace PhononicEngWeb
{
    public partial class Login : System.Web.UI.Page
    {
        readonly ILog log;
        string _userName;
        string _password;
        string _domain = ConfigurationManager.AppSettings.Get("domain");

        public Login()
        {
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLoginSubmit_Click(object sender, EventArgs e)
        {
            _userName = txtUserName.Text;
            _password = txtPassword.Text;
            if (AdService.IsValidUser(_userName, _password,_domain))
            {
                log.Info(_userName + " " + _password + " is authenticated");
                Session["UserId"] = _userName;
                Response.Redirect("Default.aspx",true);
            }
            else
            {
                lblErrorMsg.Text = "Invalid User Please check UserName and Password";
                log.Error(_userName + " " + _password + " is not correct");
            }
        }
    }
}