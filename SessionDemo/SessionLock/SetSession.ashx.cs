using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;

namespace SessionLock
{
    /// <summary>
    /// SetSession1 的摘要说明
    /// </summary>
    public class SetSession1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            /*
             
             IReadOnlySessionState不会向浏览器端写入cookie
             IReadOnlySessionState不会堵塞页面
             Thread.Sleep()会堵塞页面
             */

            context.Response.ContentType = "text/plain";

            if (context.Request.QueryString["t"] != null)
                Thread.Sleep(10000);

            context.Session["username"] = "mas";

            context.Response.Write("登录成功" + DateTime.Now.ToString("HH:mm:ss:ffff"));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}