using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace DAL
{
    public class AdminService
    {
        //查询
        public Admin GetAdminById(string id)
        {
            //sql语句

            string sql = "SELECT *  FROM  Admin where AdminID=@id";
            Admin admin = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                if (reader.Read())
                {
                    admin = new Admin();
                    admin.AdminID = (int)reader["AdminID"];
                    admin.AdminPwd = (string)reader["AdminPwd"];
                }
            }
            return admin;
        }
        //增加
        public void AddAdmin(Admin admin)
        {
            //1、sql语句

            string sql = "insert into Admin(AdminID,AdminPwd) values(@AdminID,@AdminPwd)";
            //sql += " select @@IDENTITY";
            //2、参数赋值
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@AdminID",admin.AdminID),
                new SqlParameter("@AdminPwd",admin.AdminPwd)
            };
            //3、执行sql

            admin.AdminID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnString, CommandType.Text, sql, para));
        }
        //删除
        public bool DeleteAdminById(int id)
        {
            string sql = "delete  FROM Admin where AdminID=@Id";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnString, CommandType.Text, sql, para) > 0;
        }
        //修改
        public bool ModifyAdmin(Admin admin)
        {
            string sql = "UPDATE Admin " +
                          " SET AdminPwd = @AdminPwd WHERE "+
                          "AdminID = @AdminID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@AdminID",admin.AdminID),
                new SqlParameter("@AdminPwd",admin.AdminPwd)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnString, CommandType.Text, sql, para) > 0;
        }
    }
}
