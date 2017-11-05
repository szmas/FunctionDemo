using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionLock.admin
{
    public partial class ReadOnlySession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["username2"] = "jack";
            Thread.Sleep(10000);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["username2"] = "mas";
        }
    }
}