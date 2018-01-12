using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace MSEnterpriseLibrary
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            #region Oracle
            var db = DatabaseFactory.CreateDatabase();

            DataSet ds = db.ExecuteDataSet(CommandType.Text, "select * from users");

            IDataReader dr = db.ExecuteReader(CommandType.Text, "select *from users");

            while (dr.Read())
            {
                string userid = dr["userid"].ToString();
            }

            //Accessor进行RowMapper来直接为实体赋值

            DataAccessor<Users> studentAccessor = db.CreateSqlStringAccessor("select * from users",
                MapBuilder<Users>.MapAllProperties().Build());

            studentAccessor = db.CreateSqlStringAccessor("select * from users",
                 MapBuilder<Users>.MapAllProperties().
                 Map(p => p.USERID).ToColumn("USERID").
                 Map(p => p.USERNAME).ToColumn("USERNAME").
                 Map(p => p.TITLE).WithFunc(f => f["TITLE"].ToString().ToUpper()).//将学员名称转换为大写
                 Map(p => p.SEX).ToColumn("SEX").
                 Map(p => p.LASTUPDATE).ToColumn("LASTUPDATE").
                 Map(p => p.EMAIL).ToColumn("EMAIL").
                 Map(p => p.STATUS).ToColumn("STATUS").
                 Build()
             );

            var list = studentAccessor.Execute().ToList();

            #endregion

            #region ODP.NET Oracle
            /*
            var odpdb = DatabaseFactory.CreateDatabase("ODPConnStr");

            ds = db.ExecuteDataSet(CommandType.Text, "select * from users");

            dr = db.ExecuteReader(CommandType.Text, "select *from users");

            while (dr.Read())
            {
                string userid = dr["userid"].ToString();
            }
            */
            #endregion



            #region Sql Server

            var msdb = DatabaseFactory.CreateDatabase("MsSqlConnStr");

            ds = msdb.ExecuteDataSet(CommandType.Text, "select * from emp");

            dr = msdb.ExecuteReader(CommandType.Text, "select * from emp");

            while (dr.Read())
            {
                string empno = dr["empno"].ToString();
            }


            ds = msdb.ExecuteDataSet(CommandType.Text, "select * from Demo");

            #endregion



            #region Mysql

            var mysqldb = DatabaseFactory.CreateDatabase("MySqlConnStr");


            string deleteSql = @"delete from Demo";

            int result = mysqldb.ExecuteNonQuery(CommandType.Text, deleteSql);


            string insertSql = @"INSERT INTO `Demo`(`Name`, `Age`, `Money`, `Sex`, `AddTime`, `Contonts`) VALUES 
                ('mas',18,25.45,1,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','message')";

            result = mysqldb.ExecuteNonQuery(CommandType.Text, insertSql);

            ds = mysqldb.ExecuteDataSet(CommandType.Text, "select * from Demo");

            dr = mysqldb.ExecuteReader(CommandType.Text, "select * from Demo");

            while (dr.Read())
            {
                string Name = dr["Name"].ToString();
            }

            
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < 10000; i++)
            {
                DataRow _dr = dt.NewRow();
                _dr[1] = "mas" + i;
                _dr[2] = 18;
                _dr[3] = 25.45;
                _dr[4] = 1;
                _dr[5] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                _dr[6] = "message";
                dt.Rows.Add(_dr);
            }

            DbCommand insertCommand = mysqldb.GetSqlStringCommand("INSERT INTO `Demo`(`Name`, `Age`, `Money`, `Sex`, `AddTime`, `Contonts`) VALUES (@Name,@Age,@Money,@Sex,@AddTime,@Contonts)");

            mysqldb.AddInParameter(insertCommand, "Name", DbType.String, "Name", DataRowVersion.Current);
            mysqldb.AddInParameter(insertCommand, "Age", DbType.Int32, "Age", DataRowVersion.Current);
            mysqldb.AddInParameter(insertCommand, "Money", DbType.Decimal, "Money", DataRowVersion.Current);
            mysqldb.AddInParameter(insertCommand, "Sex", DbType.UInt64, "Sex", DataRowVersion.Current);
            mysqldb.AddInParameter(insertCommand, "AddTime", DbType.DateTime, "AddTime", DataRowVersion.Current);
            mysqldb.AddInParameter(insertCommand, "Contonts", DbType.String, "Contonts", DataRowVersion.Current);


            int result_affect = mysqldb.UpdateDataSet(ds, "Table", insertCommand, null, null, UpdateBehavior.Transactional);


            ds = mysqldb.ExecuteDataSet(CommandType.Text, "select * from Demo");
            
            #endregion




            #region 通过构造函数直接创建企业库对象

            SqlDatabase sqldb = new SqlDatabase(@"Data Source=AX-EC-G01\SQL2008R2;Initial Catalog=UC7;Integrated Security=True;");

            sqldb.ExecuteDataSet(CommandType.Text, "select * from emp");

            #endregion



            #region 企业库的缓存模块

            ICacheManager goodsCache = CacheFactory.GetCacheManager();
            goodsCache.Add("name", "mas");
            goodsCache.Add("age", 18, CacheItemPriority.High, null, new SlidingTime(TimeSpan.FromSeconds(10)));


            string name = goodsCache.GetData("name").ToString();
            goodsCache.Remove("name");

            #endregion


            #region 日志模块

            LogEntry log = new LogEntry();
            log.EventId = 100;
            log.Priority = 3;
            log.Message = "information message";
            log.Categories.Add("C#学习");
            log.Categories.Add("Microsoft Enterprise Library学习");

            Logger.Write(log);

            #endregion
        }

    }
}