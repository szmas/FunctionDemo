using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 常见算法
{
    class DistinctChar
    {
        //去除重复算法：输入一串字符如 ababef 将这串字符串去除重复部分得到如下结果 abef
        public static void Run()
        {

            string str = "ababef";



            //先转数组再去重复
            var arr = str.ToArray().Distinct();

            string result = string.Join("", arr);

            Console.WriteLine(result);

            //直接去重复
            Console.WriteLine(string.Join("", str.Distinct()));



            List<char> li = new List<char>();
            foreach (var item in str)
            {
                if (!li.Contains(item))
                    li.Add(item);
            }
            Console.WriteLine(string.Join("", li));


            //统计重复字符串 如  eeefffkkkhjk 得到如下结果 3e3f3khjk;

            str = "eeefffkkkhjk";

            var ddd = str.GroupBy(g => g).Select(g => g.Count() > 1 ? (g.Count() + "" + g.Key) : g.Key.ToString());

            result = string.Join("", ddd);

            Console.WriteLine(result);


            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (var item in str)
            {

                if (!dic.Keys.Contains(item))
                {
                    dic.Add(item, 1);
                }
                else
                {
                    char key = dic.Keys.First(g => g == item);

                    dic[key]++;
                }

            }


            var dddd = dic.Select(g => g.Value > 1 ? g.Value + "" + g.Key : g.Key.ToString());

            result = string.Join("", dddd);

            Console.WriteLine(result);


            string parent = "Xselect * select t where  t.id is select";
            string child = "select";

            var arrs = ("," + parent + ",").Split(new string[] { child }, StringSplitOptions.RemoveEmptyEntries);
            arrs = parent.Split(new string[] { child }, StringSplitOptions.None);

            Console.WriteLine(arrs.Length - 1);
        }
    }
}
