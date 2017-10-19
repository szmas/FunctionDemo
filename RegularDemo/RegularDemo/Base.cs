using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularDemo
{
    class Base
    {
        public static string GetUrltoHtml(string Url, string type = "UTF-8")
        {
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.GetEncoding(type)))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
            }
            return "";
        }

        public static string GetText(string fileName)
        {
            return File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "../../" + fileName).ReadToEnd();
        }

        public static void Run()
        {


            #region 贪婪与懒惰

            string _reg = @"a\w*b";

            Regex _pattern = new Regex(_reg, RegexOptions.IgnoreCase);

            var _result = _pattern.Match("acccccccccccb").Value; //acccccccccccb


            _reg = @"a\w*?b";

            _pattern = new Regex(_reg, RegexOptions.IgnoreCase);

            _result = _pattern.Match("abcccccccccccb").Value; //ab


            #endregion


            #region 命名捕获

            //命名捕获组

            string reg = @"(?<mas>\d)\w{1,3}\1";

            string reg2 = @"(?'mas'\d)\w{1,3}\k<mas>";

            Regex r1 = new Regex(reg2, RegexOptions.IgnoreCase);

            var result = r1.Match("1abc1").Value;//1abc1


            #endregion



            #region 零宽断言

            //零宽断言 
            //用于查找在某些内容(但并不包括这些内容)之前或之后的东西，像\b,^,$那样用于指定一个位置，这个位置应该满足一定的条件(即断言)，因此它们也被称为零宽断言。

            //(?=exp)正向断言	     匹配exp前面的位置

            string reg3 = "java(?=script)";

            Regex r2 = new Regex(reg3, RegexOptions.IgnoreCase);

            var result2 = r2.Match("javascript").Value;//java



            //(?<=exp)反向断言	 匹配exp后面的位置

            string reg4 = "(?<=java)script";

            Regex r3 = new Regex(reg4, RegexOptions.IgnoreCase);

            var result3 = r3.Match("javascript").Value;//script



            //(?!exp)正向否定断言	  匹配后面跟的不是exp的位置

            string reg5 = "java(?!script)";

            Regex r4 = new Regex(reg5, RegexOptions.IgnoreCase);

            var result4 = r4.Match("javaEE").Value;//java



            //(?<!exp)反向否定断言	 匹配前面不是exp的位置

            string reg6 = "(?<!java)script";

            Regex r5 = new Regex(reg6, RegexOptions.IgnoreCase);

            var result5 = r5.Match("Jscript").Value;//script


            //(?<!comment) 这种类型的分组不对正则表达式的处理产生任何影响

            string reg7 = "(?#备注)script";

            Regex r6 = new Regex(reg7, RegexOptions.IgnoreCase);

            var result6 = r6.Match("Jscript").Value;//script

            #endregion



            #region 平衡组/递归匹配

            /*
             
             
            (?'group') 把捕获的内容命名为group,并压入堆栈(Stack)
            (?'-group') 从堆栈上弹出最后压入堆栈的名为group的捕获内容，如果堆栈本来为空，则本分组的匹配失败
            (?(group)yes|no) 如果堆栈上存在以名为group的捕获内容的话，继续匹配yes部分的表达式，否则继续匹配no部分
            (?!) 零宽负向先行断言，由于没有后缀表达式，试图匹配总是失败
             
             
            (?<group>) 写法一样
         
             */

            #region 嵌套标签

            string content = GetUrltoHtml("http://www.cnblogs.com/deerchao/archive/2006/08/24/zhengzhe30fengzhongjiaocheng.html");


            string s1 = @"(?'Open'\w)\k<Open>";

            string ress = new Regex(s1, RegexOptions.IgnoreCase).Match("xddddx").Value;


            s1 = @"\(((?'Open'\()|(?'-Open'\))|[^()])*(?(Open)(?!))\)";


            ress = new Regex(s1, RegexOptions.IgnoreCase).Match("(1(2(3(4)5)6)7)8)").Value;


            s1 = @"<td\s*id=""td2""[^>]*>((?><td[^>]*>(?<o>)|</td>(?<-o>)|[\s\S])*)(?(o)(?!))</td>";


            s1 = @"<(?<HtmlTag>div)[^>]*?>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>";

            s1 = @"<(?<HtmlTag>[\w]+)[^>]*\sclass=(?<Quote>[""']?)postText(?(Quote)\k<Quote>)[^>]*?(/>|>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>)";

            ress = new Regex(s1, RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(content).Value;



            #endregion


            string regg = @"<[^<>]*(((?'Open'<)[^<>]*)+((?'-Open'>)[^<>]+))*(?(Open)(?!))>";

            Regex r = new Regex(regg, RegexOptions.IgnoreCase);

            var res = r.Match("xx <aa <bbb> <bbb> aa> yy>").Value;//<aa <bbb> <bbb> aa>

            regg = "<div[^>]*>[^< >]*(((?'Open'<div[^>]*>)[^<>]*)+((?'-Open'</div>)[^<>]*)+)*(?(Open)(?!))</div>";

            r = new Regex(regg, RegexOptions.IgnoreCase);

            res = r.Match("<a href=\"http://www.baidu.com\"></a><div id=\"div1\">1<p>p1</p><div><p>p2</p>2</div></div>").Value;//<div id="div1"><div id="div2">你在他乡还好吗？</div></div>


            #endregion




            regg = "<div id=\"footer\"[^>]*>[\\s\\S]*(((?'Open'<div[^>]*>)[\\s\\S]*)*((?'-Open'</div>)[\\s\\S]*)*)*(?(Open)(?!))</div>";


            r = new Regex(regg, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            res = r.Match(content).Value;//<div id="div1"><div id="div2">你在他乡还好吗？</div></div>


            regg = @"<(?<HtmlTag>[\w]+)[^>]*?>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>";
        }
    }
}
