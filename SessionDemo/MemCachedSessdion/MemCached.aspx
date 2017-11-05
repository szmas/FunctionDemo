<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemCached.aspx.cs" Inherits="MemCachedSession.MemCached" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <%=Session["name"] %><br />
            <asp:Button ID="Button1" runat="server" Text="设置Session" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
