using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularDemo
{
    class Program
    {

        static void Main(string[] args)
        {

            Base.Run();

            string content = Base.GetUrltoHtml("http://www.cnblogs.com/youring2/p/3836259.html");
            string txtContent = Base.GetText("data.html");

            //匹配任意闭合HTML标签的正则表达式：
            string pattern = @"<(?<HtmlTag>[\w]+)[^>]*?>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>";

            var reg = new Regex(pattern, RegexOptions.IgnoreCase);

            string result = reg.Match("<div class='main'><div class='left'></div><div class='right'></div></div></div>").Value;

            Console.WriteLine(result);



            //如果只想匹配div标签，可以使用下面的正则表达式：
            //<(?<HtmlTag>(div|span|h1))[^>]*?>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>

            pattern = @"<(?<HtmlTag>div)[^>]*?>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>";

            reg = new Regex(pattern, RegexOptions.IgnoreCase);

            result = reg.Match("<div class='main'><div class='left'></div><div class='right'></div></div></div>").Value;

            Console.WriteLine(result);


            //如果想匹配包含class的标签，可以使用下面的正则表达式：
            //<(?<HtmlTag>[\w]+)[^>]*\s[iI][dD]=(?<Quote>["']?)footer(?(Quote)\k<Quote>)[^>]*?(/>|>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>)

            pattern = @"<(?<HtmlTag>div)[^>]*\sid=(?<Quote>[""']?)main(?(Quote)\k<Quote>)[^>]*?(/>|>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>)";

            reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            result = reg.Match(content).Value;

            Console.WriteLine(result);



            pattern = @"<(?<HtmlTag>tr)[^>]*\sclass=(?<Quote>[""']?)t1(?(Quote)\k<Quote>)[^>]*?(/>|>((?<Nested><\k<HtmlTag>[^>]*>)|</\k<HtmlTag>>(?<-Nested>)|.*?)*</\k<HtmlTag>>)";

            reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            result = reg.Match(txtContent).Value;

            Console.WriteLine(result);

        }
    }
}
