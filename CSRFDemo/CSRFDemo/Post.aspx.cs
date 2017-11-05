using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSRFDemo
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(Request.Form["username"]))
            {
                Response.Write("转账成功!金额：" + Request.Form["money"]);
            }
        }
    }
}