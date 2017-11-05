using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FA = System.Web.Security.FormsAuthentication;
namespace FormsAuthentication
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "admin" && txtpwd.Text == "admin")
            {

                //会话性cookie保存于内存中。关闭浏览器则会话性cookie会过期消失；持久化cookie则不会，直至过期时间已到或确认注销。

                FA.SetAuthCookie(txtusername.Text, true);


                #region 票据验证

                string userData = "序列化对象";
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                                        txtusername.Text,
                                                        DateTime.Now,
                                                        DateTime.Now.AddMinutes(720),
                                                        true,
                                                        userData,
                                                        FA.FormsCookiePath);

                // 加密票证
                string encTicket = FA.Encrypt(ticket);

                // 创建cookie
                HttpCookie cookie = new HttpCookie(FA.FormsCookieName, encTicket);
                cookie.HttpOnly = true;
                cookie.Secure = FA.RequireSSL;
                cookie.Domain = FA.CookieDomain;
                cookie.Path = FA.FormsCookiePath;
                if (ticket.IsPersistent)
                    cookie.Expires = DateTime.Now.AddMinutes(720);

                HttpContext.Current.Response.Cookies.Add(cookie);

                #endregion

                Response.Redirect("admin/index.aspx");



            }
            else
            {
                Response.Write("用户名或密码错误");
            }
        }
    }
}