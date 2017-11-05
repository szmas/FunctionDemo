<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SessionLock.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div>
        <h3>
            <pages enablesessionstate="true"></pages>
        </h3>
        <h4>enableSessionState 默认是true 就是session会有读写锁
        </h4>

        <h4>读锁与写锁会冲突，<br />
            读锁与读锁之间不会冲突，<br />
            只有session存在，所有页面就会有读写锁。没有session就不存在读写锁<br />
        </h4>

        <p>
            页面有 EnableSessionState="false"的页面，不能读取session,不会堵塞其他页面
        </p>

        <fieldset>
            <legend>true</legend>
            <p>
                enableSessionState=true 页面只容许读写操作 页面如果延迟的话，所有页面都会堵塞的
            </p>
        </fieldset>

        <fieldset>
            <legend>ReadOnly</legend>
            <p>
                enableSessionState=ReadOnly  页面只容许读的操作， 页面如果延迟的话，所有页面都不会堵塞
            </p>
            <div>
                页面有 EnableSessionState="ReadOnly"的页面，可以读取session,不会堵塞其他页面<br />
            </div>
            <div>
                但是，从当前页面首次创建的session不会写入成功，值为空，如果之前存在session,则没事
            </div>
            <div>
                如果ReadOnly模式，session的值有可能会被其他页面覆盖，因为不是堵塞模式，所有整个过程没法做到数据一致性
            </div>
        </fieldset>
        <fieldset>
            <legend>false</legend>
            <p>
                enableSessionState=false  页面禁止使用session，不存在延迟问题
            </p>
        </fieldset>
    </div>
    <form id="form1" runat="server">
        <div>
            <a target="_blank" href="admin/GetSession.aspx">GetSession.aspx</a>
            <a target="_blank" href="admin/DoSomeThing.aspx">DoSomeThing.aspx</a>
            <a target="_blank" href="admin/NoLogin.aspx">无会话模式</a>
            <a target="_blank" href="admin/ReadOnlySession.aspx">ReadOnly模式</a>
            <a target="_blank" href="SetSession.ashx">登录</a>
        </div>
    </form>
</body>
</html>
