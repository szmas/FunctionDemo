using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebUploader
{
    /// <summary>
    /// fileupload 的摘要说明
    /// </summary>
    public class fileupload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request.Files.Count > 0 && context.Request.Files[0].ContentLength > 0)
            {
                string fileName = context.Request.Files[0].FileName;
                string location = context.Server.MapPath("/uploadfiles/") + fileName;

                context.Request.Files[0].SaveAs(location);

                context.Response.Write("{\"type\":\"Success\",\"Message\":\"/uploadfiles/" + fileName + "\"}");
                context.Response.End();
            }
            else
            {
                context.Response.Write("{\"type\":\"Error\",\"Message\":\"没有文件\"}");
                context.Response.End();
            }
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