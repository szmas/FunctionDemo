using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            #region 核心类 ConnectionMultiplexer

            //连接服务器
            //可以连接多个服务器  client = ConnectionMultiplexer.Connect("server1:6379,server2:6379");
            ConnectionMultiplexer RedisClient = ConnectionMultiplexer.Connect("127.0.0.1:6379,password=305596979@qq.com");

            IDatabase db = RedisClient.GetDatabase();

            #endregion




            #region Redis 字符串(String) 可以包含任何数据。比如jpg图片或者序列化的对象 。

            //赋值
            db.StringSet("name", "mas" + new Random().Next());

            //判断key是否存在
            if (db.KeyExists("name"))
            {
                Console.WriteLine("name已赋值");
            }

            //设置10秒钟过期
            db.StringSet("time", "mas" + new Random().Next(), TimeSpan.FromSeconds(10));

            //批量赋值
            string[] keys = new string[] { "p1", "p2", "p3" };
            string[] values = new string[] { "m1", "m2", "m3" };
            var keyValuePair = new KeyValuePair<RedisKey, RedisValue>[keys.Length];

            for (int i = 0; i < keys.Length; i++)
            {
                keyValuePair[i] = new KeyValuePair<RedisKey, RedisValue>(keys[i], values[i]);
            }

            db.StringSet(keyValuePair);

            //取值
            string name = db.StringGet("name");

            //取值
            string time = db.StringGet("time");

            var redisKey = new RedisKey[keys.Length];

            //批量取值
            for (int i = 0; i < keys.Length; i++)
            {
                redisKey[i] = keys[i];
            }
            var RedisValues = db.StringGet(redisKey);


            Console.WriteLine("{0}={1}", "name", name);

            Console.WriteLine("{0}={1}", "time", time);

            //删除值
            db.KeyDelete("name");

            //key的类型
            var type = db.KeyType("name");


            //批量删除
            db.KeyDelete(redisKey);

            var v = db.StringGet("name");

            Console.WriteLine("{0}={1}", "name", v);

            #endregion





            #region 哈希(Hash) string类型的field和value的映射表

            db.HashSet("hs", new HashEntry[] { new HashEntry("a", "A"), new HashEntry("b", "B"), new HashEntry("c", "C") });
            db.HashSet("hsAll", "A", "B");


            var hs_a = db.HashGet("hs", "a");
            Console.WriteLine(hs_a);
            var hs_all = db.HashGetAll("hsAll");
            Console.WriteLine(hs_all.FirstOrDefault().Name + "：" + hs_all.FirstOrDefault().Value);

            db.HashDelete("hasAll", "A");//删掉元素
            db.KeyDelete("hasAll");//删除key
            #endregion





            #region  列表 按照插入顺序排序。你可以添加一个元素到列表的头部（左边）或者尾部（右边）。

            db.ListLeftPush("list", new RedisValue[] { "A", "B", "C", "D", "E", "F" });
            db.ListRightPush("list", new RedisValue[] { "a", "b", "c", "d", "e", "f" });

            var list = db.ListRange("list", 0, -1);

            db.ListRemove("list", "A");//删除元素
            db.KeyDelete("list");//删除key
            #endregion





            #region Redis 集合(Set)string类型的无序集合,且不允许重复的成员。


            db.SetAdd("li", "a");
            db.SetAdd("li", "b");
            db.SetAdd("li", new RedisValue[] { "c", "d", "e" });

            //集合默认是无序的
            var li = db.SetMembers("li");

            li = li.OrderBy(g => g).ToArray();//排序

            foreach (var item in li)
            {
                Console.WriteLine(item);
            }

            db.SetRemove("li", "a");//删除元素a
            db.KeyDelete("li");//删除key

            #endregion





            #region Redis 有序集合(sorted set)  不允许重复的成员
            //不同的是每个元素都会关联一个double类型的分数。redis正是通过分数来为集合中的成员进行从小到大的排序。

            db.SortedSetAdd("sortLi", "a", 1);
            db.SortedSetAdd("sortLi", "b", 2);

            db.SortedSetAdd("sortLi", new SortedSetEntry[] { new SortedSetEntry("c", 3), new SortedSetEntry("d", 4), new SortedSetEntry("e", 5) });

            //集合默认是无序的
            var sortLi = db.SortedSetRangeByRank("sortLi");

            foreach (var item in sortLi)
            {
                Console.WriteLine(item);
            }

            db.SortedSetRemoveRangeByRank("sortLi", 0, -1);//删除元素
            db.KeyDelete("sortLi");//删除key

            #endregion





            #region 发布订阅


            ISubscriber sub = RedisClient.GetSubscriber();

            //订阅者
            sub.Subscribe("redisChat", (channel, value) =>
            {
                Console.WriteLine(channel + "：" + value);
            });


            //发布者
            db.Publish("redisChat", "推送一条消息");

            #endregion





            #region 事物处理

            //开启事物
            var tran = db.CreateTransaction();

            db.StringSet("test1", "xiaopotian");
            db.StringSet("test2", "xiaopangu");

            //执行命令
            tran.Execute();


            db.KeyDelete("test1");
            db.KeyDelete("test2");

            #endregion



            Console.ReadLine();


        }
    }
}

