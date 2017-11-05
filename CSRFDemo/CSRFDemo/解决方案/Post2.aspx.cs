using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSRFDemo.解决方案
{
    public partial class Post2 : System.Web.UI.Page
    {
        protected string token = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.Form["username"]))
            {

                token = Guid.NewGuid().ToString();
                Session["token"] = token;
            }
            else
            {


                //第一种：判断Request.UrlReferrer是不是本网站发送的请求
                if (Request.UrlReferrer != null && Request.UrlReferrer.Host == "localhost")
                {

                    //现在业界对CSRF的防御，一致的做法是使用一个Token（Anti CSRF Token）。
                    //token只有访问了这个表单，才会生成。所以无法预先猜测
                    if (Session["token"].ToString() == Request.Form["AntiCsrfToken"])
                    {

                        Response.Write("转账成功!金额：" + Request.Form["money"]);

                    }
                    else
                    {
                        Response.Write("操作失败！");
                        Response.End();
                    }
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