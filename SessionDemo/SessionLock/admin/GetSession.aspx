<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="GetSession.aspx.cs" Inherits="SessionLock.GetSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <%
                if (Session["username"] != null)
                {
                    Response.Write(Session["username"]);
                }
            %>
        </div>
    </form>
</body>
</html>
