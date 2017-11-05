<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="False" CodeBehind="NoLogin.aspx.cs" Inherits="SessionLock.admin.NoLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="Button1" runat="server" Text="模拟延迟操作" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
