using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XSSDemo
{
    public partial class XSS : System.Web.UI.Page
    {
        protected static Dictionary<string, string> remark = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             
            cross site scripting  跨站脚本攻击
             
             过滤特殊字符[编辑]
            避免XSS的方法之一主要是将用户所提供的内容进行过滤，许多语言都有提供对HTML的过滤：
            PHP的htmlentities()或是htmlspecialchars()。
            Python的cgi.escape()。
            ASP的Server.HTMLEncode()。
            ASP.NET的Server.HtmlEncode()或功能更强的Microsoft Anti-Cross Site Scripting Library
            Java的xssprotect (Open Source Library)。
            Node.js的node-validator。
             
             */


            if (Request.HttpMethod == "POST")
            {

                remark.Add(Request.Form["username"], Request.Form["content"]);
            }
        }
    }
}