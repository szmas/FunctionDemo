<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoSomeThing.aspx.cs" Inherits="SessionLock.SetSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%=Session["username"] %><br />
            <asp:Button ID="Button2" runat="server" Text="模拟延迟操作" OnClick="Button1_Click" />
            <asp:Button ID="Button1" runat="server" Text="模拟延迟写入Session" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
