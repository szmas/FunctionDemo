using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSRFDemo.解决方案
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.Form["username"]))
            {
                //第一种：判断Request.UrlReferrer是不是本网站发送的请求
                if (Request.UrlReferrer != null && Request.UrlReferrer.Host == "localhost")
                {
                    Response.Write("转账成功!金额：" + Request.Form["money"]);
                }
                else
                {
                    Response.Write("不是本站的请求！");
                    Response.End();
                }
            }
        }
    }
}