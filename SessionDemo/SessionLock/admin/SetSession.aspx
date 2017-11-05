<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetSession.aspx.cs" Inherits="SessionLock.admin.SetSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%=Session["A"] %><br />
            <asp:Button ID="Button1" runat="server" Text="模拟延迟写入Session" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
