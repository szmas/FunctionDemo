写到这里，我想有必要再来总结一下在ASP.NET中实现登录与注销的方法：

1. 登录：调用FormsAuthentication.SetAuthCookie()方法，传递一个登录名即可。
2. 注销：调用FormsAuthentication.SignOut()方法。


在ASP.NET中，Forms认证是由FormsAuthenticationModule实现的，URL的授权检查是由UrlAuthorizationModule实现的。

这二个阶段在ASP.NET管线中用AuthenticateRequest和AuthorizeRequest事件来表示。


Request.IsAuthenticated  是否登录
HttpContext.User.Identity.Name  用户名