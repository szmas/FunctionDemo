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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1. 读登录Cookie
                HttpCookie cookie = Request.Cookies[FA.FormsCookieName];
                if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                    return;

                try
                {
                    string userData = null;
                    // 2. 解密Cookie值，获取FormsAuthenticationTicket对象
                    FormsAuthenticationTicket ticket = FA.Decrypt(cookie.Value);

                    if (ticket != null && string.IsNullOrEmpty(ticket.UserData) == false)
                        // 3. 还原用户数据
                        userData = ticket.UserData;

                    //反序列化对象

                    Context.User = null;
                }
                catch { /* 有异常也不要抛出，防止攻击者试探。 */ }

            }
        }
    }
}