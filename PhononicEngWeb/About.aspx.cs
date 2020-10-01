using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhononicEngWeb.Lib;
using log4net;
using System.Reflection;

namespace PhononicEngWeb
{
    public partial class About : CustomPage
    {
        readonly static ILog log; 
        static About()
        {
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}