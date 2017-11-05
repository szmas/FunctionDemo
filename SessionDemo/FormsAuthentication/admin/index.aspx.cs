using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FA = System.Web.Security.FormsAuthentication;
namespace FormsAuthentication.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Logon();
        }

        public void Logon()
        {
            FA.SignOut();
            Response.Redirect("/login.aspx");
        }
    }
}