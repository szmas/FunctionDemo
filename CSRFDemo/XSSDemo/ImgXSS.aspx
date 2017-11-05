<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImgXSS.aspx.cs" Inherits="XSSDemo.ImgXSS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img src="javascript:alert('1');"  />
    </div>
    </form>
</body>
</html>
