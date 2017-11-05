using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionLock
{
    public partial class SetSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("/SetSession.ashx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(10000);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(10000);
            Session["username"] = "jack";
        }
    }
}