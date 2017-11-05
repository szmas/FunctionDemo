<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="SessionDemo.Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <p>
        Session是依靠cookie来工作的，cookie失效后，将无法访问session<br />

        只要这个串够随机，攻击者就不能轻易冒充他人的sessionid进行操作；除非通过CSRF或http劫持的方式，才有可能冒充别人进行操作；<br />

        即使冒充成功，也必须被冒充的用户session里面包含有效的登录凭证才行。但是在真正决定用它管理会话之前，也得根据自己的应用情况考虑以下几个问题：<br />

        如果客户端的cookie被人获取，在控制台生成cookie,将同样实现Session会话<br />
        <pre>document.cookie='ASP.NET_SessionId=3wvmqk1pz1sg4vjkyenjrqx1;readonly=true;path=/'

        </pre>
    </p>

    <p>
        1）这种方式将会话信息存储在web服务器里面，所以在用户同时在线量比较多时，这些会话信息会占据比较多的内存；<br />

        2）当应用采用集群部署的时候，会遇到多台web服务器之间如何做session共享的问题。因为session是由单个服务器创建的，但是处理用户请求的服务器不一定是那个创建session的服务器，这样他就拿不到之前已经放入到session中的登录凭证之类的信息了；<br />

        3）多个应用要共享session时，除了以上问题，还会遇到跨域问题，因为不同的应用可能部署的主机不一样，需要在各个应用做好cookie跨域的处理。<br />

        针对问题1和问题2，我见过的解决方案是采用redis这种中间服务器来管理session的增删改查，一来减轻web服务器的负担，二来解决不同web服务器共享session的问题。<br />

        针对问题3，由于服务端的session依赖cookie来传递sessionid，所以在实际项目中，只要解决各个项目里面如何实现sessionid的cookie跨域访问即可，这个是可以实现的，就是比较麻烦，前后端有可能都要做处理。<br />

        如果不考虑以上三个问题，这种管理方式比较值得使用，尤其是一些小型的web应用。但是一旦应用将来有扩展的必要，那就得谨慎对待前面的三个问题。如果真要在项目中使用这种方式，推荐结合单点登录框架如CAS一起用，这样会使应用的扩展性更强。<br />
    </p>
    <form id="form1" runat="server">
        <div>
            <%=Session["name"] %><br />
            <asp:Button ID="Button1" runat="server" Text="写入Session" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
