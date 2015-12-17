using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TreeListDemo

{
    /// <summary>
    /// 数据交互类
    ///  <connectionStrings>
    ///    <add name="localhost_NorthwindConnection" connectionString="XpoProvider=MSSqlServer;data source=localhost;user id=sa;password=Landmark1;initial catalog=Northwind;Persist Security Info=true" />
    ///</connectionStrings>
    /// </summary>
    public class SqlHelper
    {
        private SqlConnection conn;
        private string strConnectionString;
        public SqlHelper()
        {
            strConnectionString = "server=localhost;uid=sa;pwd=Landmark1;database=ZWJQuickEvaluation";
            conn = new SqlConnection(strConnectionString);
        }
        /// <summary>
        /// 打开与数据库的连接
        /// </summary>
        public void OpenDBConn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = strConnectionString;
                conn.Open();
            }
        }

        /// <summary>
        /// 获取数据库连接对象
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetDBConn()
        {
            return conn;
        }

        /// <summary>
        /// 关闭与数据库的连接
        /// </summary>
        public void CloseDBConn()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                //conn.Dispose();
            }
        }

        /// <summary>
        /// 获取数据以DataTable方式返回,参数sql表示要执行的SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            SqlDataAdapter da = null;
            try
            {
                OpenDBConn();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                da.Dispose();
                CloseDBConn();
            }
        }

        
        /// <summary>
        /// 获取数据以DataTable方式返回,参数sql表示要执行的SQL语句,参数tablename表示要返回DataTable的表名
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <param name="tablename">返回DataTable的表名</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, string tablename)
        {
            SqlDataAdapter da = null;
            try
            {
                OpenDBConn();
                DataTable dt = new DataTable(tablename);
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                da.Dispose();
                CloseDBConn();
            }
        }

        /// <summary>
        /// 返回一个DataSet数据集。
        /// </summary>
        /// <param name="strsql">要执行的SQL语句</param>
        /// <param name="datasetname"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strsql,string datasetname) 
        {
            SqlDataAdapter da = null;
            try
            {
                DataSet ds = new DataSet(datasetname);

                OpenDBConn();
                da = new SqlDataAdapter(strsql,conn);
                da.Fill(ds);
                return ds;
            }
            finally
            {
                da.Dispose();
                CloseDBConn();
            }
        }

       /// <summary>
        ///  //获取数据,以SqlDataReader形式返回,参数sql表示要执行的SQL语句
       /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
       /// <returns></returns>
        public SqlDataReader GetSqlDataReader(string sql)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                OpenDBConn();
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                return dr;
            }
            finally
            {
                dr.Dispose();
            }
        }

        /// <summary>
        /// 查询数据，以单个数字的形式返回，如：求平均值，参数sql表示要执行的SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetIntValue(string sql)
        {
            SqlCommand cmd = null;
            try
            {
                OpenDBConn();
                cmd = new SqlCommand(sql, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                cmd.Dispose();
                CloseDBConn();
            }

        }

        //查询数据，以字符串的形式返回，参数sql表示要执行的SQL语句
        public string GetStringValue(string sql)
        {
            SqlCommand cmd = null;
            try
            {
                OpenDBConn();
                cmd = new SqlCommand(sql, conn);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                cmd.Dispose();
                CloseDBConn();
            }

        }

        
        /// <summary>
        /// 查询是否存在数据，以布尔值形式返回，参数sql表示要执行的SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool IsDataExist(string sql)
        {
            SqlDataReader dr = null;
            SqlCommand cmd = null;
            try
            {
                OpenDBConn();
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                return dr.Read();
            }
            finally
            {
                dr.Close();
                cmd.Dispose();
                CloseDBConn();
            }
        }

       
        /// <summary>
        /// 执行增、删、改SQL语句，参数sql表示要执行的SQL语句
        /// </summary>
        /// <param name="sql"></param>
        public void ExecSQL(string sql)
        {
            SqlTransaction tan;
            SqlCommand cmd = null;
            try
            {
                OpenDBConn();
                tan = conn.BeginTransaction();
               // tran = conn.BeginTransaction();
                cmd = new SqlCommand(sql, conn);
                cmd.Transaction = tan;
                int x = 0;
               x= cmd.ExecuteNonQuery();
               if (x > 0)
               {
                   tan.Commit();
               }
               else
               {
                   tan.Rollback();
               }
                
            }
           
            finally
            {
                cmd.Dispose();
                CloseDBConn();
            }

        }
       
        /// <summary>
        ///  执行增、删、改SQL语句，参数sql表示要执行的SQL语句,返回所影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecSQL1(string sql)
        {
            int i = 0;
            SqlCommand cmd = null;
            try
            {
                OpenDBConn();
                cmd = new SqlCommand(sql, conn);
                i=cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                CloseDBConn();
            }
            return i;
        }

        
        /// <summary>
        /// //执行增、删、改SQL语句，参数sql表示要执行的SQL语句,参数spAry表示要执行的SQL语句中的@参数的数组
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spAry"></param>
        public void ExecSQL(string sql, SqlParameter[] spAry)
        {
            SqlCommand cmd = null;
            try
            {
                OpenDBConn();
                cmd = new SqlCommand(sql, conn);
                foreach (SqlParameter sp in spAry)
                {
                    cmd.Parameters.Add(sp);
                }
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            finally
            {
                cmd.Dispose();
                CloseDBConn();
            }
        }

        /// <summary>
        /// 返回int,查询数据的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetintData(string sql)
        {
            int i = 0;
            SqlDataAdapter da = null;
            try
            {
                OpenDBConn();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                i = dt.Rows.Count;
                return i;
            }
            finally
            {
                da.Dispose();
                CloseDBConn();
            }


        }
    }
}

