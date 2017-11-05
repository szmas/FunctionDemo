<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post2.aspx.cs" Inherits="CSRFDemo.解决方案.Post2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<input type="text" name="username" /><br />
            金额：<input type="text" name="money" /><br />
            <input type="submit" value="转账" />
            <input type="hidden" name="AntiCsrfToken" value="<%:token %>" />
        </div>
    </form>
</body>
</html>
