using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class SqlHelper
    {

        public static readonly string ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        #region ExecuteNonQuery 执行SQL语句或者存储过程后，返回影响的行数
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="commandParameters">参数数组，允许为空对象</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, CommandType.Text, conn, commandText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
        /// <summary>
        /// 执行SqlServer存储过程，注意：不能执行有输出Out参数的存储过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程的名称</param>
        /// <param name="parameterValues">参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //PrepareCommand(cmd, CommandType.Text, conn, commandText, commandParameters);
                PrepareCommand(cmd, conn, spName, parameterValues);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
        #endregion
        #region ExecuteScalar 执行SQL语句或者存储过程后，如插入一条新纪录的时候，返回自增的ID
        /// <summary>
        /// 执行sql命令返回自增的ID
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="commandParameters">参数数组 允许空参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, CommandType.Text, conn, commandText, commandParameters);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }
        /// <summary>
        /// 执行SqlServer存储过程返回自增的ID
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程的名称</param>
        /// <param name="parameterValues">参数数组</param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, spName, parameterValues);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }
        #endregion
        #region ExecuteReader 执行SQL语句或者存储过程后，返回一个DataReader
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="commandParameters">参数数组 允许空参数</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, CommandType.Text, conn, commandText, commandParameters);
                //PrepareCommand(cmd, conn, spName, parameterValues);
                SqlDataReader rdr = cmd.ExecuteReader();
                return rdr;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }

        }
        /// <summary>
        /// 执行SqlServer存储过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程的名称</param>
        /// <param name="parameterValues">参数数组</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                // PrepareCommand(cmd, CommandType.Text, conn, commandText, commandParameters);
                PrepareCommand(cmd, conn, spName, parameterValues);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch (Exception)
            {
                conn.Close();
                throw;
            }

        }
        #endregion
        #region ExecuteDataset 执行SQL语句或者存储过程后，返回一个Dataset
        /// <summary>
        /// 执行Sql返回Dataset
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="commandParameters">参数数组 可以为空</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                //PrepareCommand(cmd, CommandType.Text, conn, commandText, commandParameters);
                PrepareCommand(cmd, commandType, conn, commandText, commandParameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
       
        /// <summary>
        /// 执行Sql存储过程返回Dataset
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程的名称</param>
        /// <param name="parameterValues">参数数组</param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, spName, parameterValues);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }

        }

        #endregion
        #region PrepareCommand构建一个Command对象供内部方法进行调用，两个重载方法（一个执行存储语句，一个执行Sql语句）
        /// <summary>
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd">SQLCommand对象，不允许为空对象</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="conn">SqlConnection对象，不允许为空对象</param>
        /// <param name="commandText">sql语句</param>
        /// <param name="cmdParms">参数数组，允许为空对象</param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, SqlParameter[] cmdParms)
        {
            //打开连接
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            //设置SqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }

            }
        }
        /// <summary>
        /// 设置一个等待执行存储过程的SQLCommand对象
        /// </summary>
        /// <param name="cmd">SQLCommand对象，不允许为空对象</param>
        /// <param name="conn">SqlConnection对象，不允许为空对象</param>
        /// <param name="spName">存储过程的名称</param>
        /// <param name="parameterValues">参数数组，允许为空对象</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, string spName, params object[] parameterValues)
        {
            //打开连接
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            //设置SqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = spName;
            cmd.Parameters.Clear();
            if (parameterValues != null)
            {
                foreach (SqlParameter parm in parameterValues)
                {
                    cmd.Parameters.Add(parm);
                }

            }
        }

        #endregion

        #region
        public static DataTable ExecuteDataTable(SqlConnection conn, string cmdText,
          params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable ExecuteDataTable(string cmdText,
           params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                return ExecuteDataTable(conn, cmdText, parameters);
            }
        }
        #endregion

      
        
    }
}
