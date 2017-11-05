<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FormsAuthentication.admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            是否登录： <%=Context.User.Identity.IsAuthenticated %><br />
            用户名：<%=Context.User.Identity.Name %>
        </div>
        <asp:Button ID="Button1" runat="server" Text="退出" OnClick="Button1_Click" />
    </form>
</body>
</html>
