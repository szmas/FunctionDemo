<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="CSRFDemo.Post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <p>
        csrf :cross site request forgery 伪造跨站请求

    </p>
    <h4>跨站请求伪造（英语：Cross-site request forgery），也被称为 one-click attack 或者 session riding，通常缩写为 CSRF 或者 XSRF，<br />
        是一种挟制用户在当前已登录的Web应用程序上执行非本意的操作的攻击方法。[1] 跟跨网站脚本（XSS）相比，XSS 利用的是用户对指定网站的信任，CSRF 利用的是网站对用户网页浏览器的信任。
    </h4>
    <form id="form1" runat="server">
        <div>
            用户名：<input type="text" name="username" /><br />
            金额：<input type="text" name="money" /><br />
            <input type="submit" value="转账" />
        </div>
    </form>
</body>
</html>
