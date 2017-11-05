using MyBlogs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlogs.Domain
{
    public class BlogsDB : DbContext
    {

        /// <summary>
        /// 调用父类构造函数
        /// </summary>
        public BlogsDB()
            : base("BlogsDB")
        {

        }

        public DbSet<Students> Student { get; set; }
    }
}