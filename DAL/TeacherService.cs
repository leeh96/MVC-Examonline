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
    public class TeacherService
    {
        //查询
        public Teacher GetTeacherById(string id)
        {
            //sql语句

            string sql = "SELECT *  FROM  Teacher where TeacherID=@id";
            Teacher teacher = null;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                if (reader.Read())
                {
                    teacher = new Teacher();
                    teacher.TeacherID = (int)reader["TeacherID"];
                    teacher.TeacherPwd = (string)reader["TeacherPwd"];
                    teacher.TeacherName = (string)reader["TeacherName"];
                    teacher.TeacherSubject = (string)reader["TeacherSubject"];
                    teacher.TeacherTel = (string)reader["TeacherTel"];
                    teacher.TeacherRank = (string)reader["TeacherRank"];
                }
            }

            return teacher;
        }
        public List<Teacher> GetTeacher()
        {

            List<Teacher> list = new List<Teacher>();
            string sql = "SELECT * FROM  Teacher ORDER BY TeacherID";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Teacher teacher = new Teacher();
                    teacher.TeacherID = (int)row["TeacherID"];
                    teacher.TeacherName = (string)row["TeacherName"];
                    teacher.TeacherSubject = (string)row["TeacherSubject"];
                    teacher.TeacherRank = (string)row["TeacherRank"];
                    teacher.TeacherTel = (string)row["TeacherTel"];
                    list.Add(teacher);
                }
            }
            return list;

        }
        public List<Teacher> GetTeacher(TeacherQuery category, string keyWord)
        {
            List<Teacher> list = new List<Teacher>();
            string sql = "SELECT * FROM Teacher where  ";
            if (String.Compare(category.ToString(), "教师编号", true) == 0)
            {
                sql = sql + " TeacherID LIKE '%" + keyWord + "%'";
            }
            else if (String.Compare(category.ToString(), "教师姓名", true) == 0)
            {
                sql = sql + " TeacherName LIKE '%" + keyWord + "%'";
            }
            else if (String.Compare(category.ToString(), "教授学科", true) == 0)
            {
                sql = sql + " TeacherSubject LIKE '%" + keyWord + "%'";
            }
            else if (String.Compare(category.ToString(), "教师职称", true) == 0)
            {
                sql = sql + " TeacherRank LIKE '%" + keyWord + "%'";
            }
            //DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, "sp_QueryTeachers", category, keyWord);
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Teacher teacher = new Teacher();
                    teacher.TeacherID = (int)row["TeacherID"];
                    teacher.TeacherName = (string)row["TeacherName"];
                    teacher.TeacherSubject = (string)row["TeacherSubject"];
                    teacher.TeacherRank = (string)row["TeacherRank"];
                    teacher.TeacherTel = (string)row["TeacherTel"];
                    list.Add(teacher);
                }
            }
            return list;

        }


        //增加
        public void AddTeacher(Teacher teacher)
        {
            //1、sql语句

            string sql = "insert into Teacher(TeacherID,TeacherPwd,TeacherName,TeacherSubject,TeacherTel,TeacherRank) values(@TeacherID,@TeacherPwd,@TeacherName,@TeacherSubject,@TeacherTel,@TeacherRank)";
            //sql += " select @@IDENTITY";
            //2、参数赋值
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TeacherID",teacher.TeacherID),
                new SqlParameter("@TeacherPwd",teacher.TeacherPwd),
                new SqlParameter("@TeacherName",teacher.TeacherName),
                new SqlParameter("@TeacherSubject",teacher.TeacherSubject),
                new SqlParameter("@TeacherTel",teacher.TeacherTel),
                new SqlParameter("@TeacherRank",teacher.TeacherRank)
            };
            //3、执行sql

            teacher.TeacherID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnString, CommandType.Text, sql, para));
        }
        //删除
        public bool DeleteTeacherById(int id)
        {
            string sql = "delete  FROM Teacher where TeacherID=@Id";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnString, CommandType.Text, sql, para) > 0;
        }
        //修改
        public bool ModifyTeacher(Teacher teacher)
        {
            string sql = "UPDATE Teacher " +
                          " SET TeacherPwd = @TeacherPwd," +
                              " TeacherName = @TeacherName," +
                              " TeacherSubject = @TeacherSubject," +
                              " TeacherTel = @TeacherTel," +
                              " TeacherRank = @TeacherRank WHERE " +
                              " TeacherID = @TeacherID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TeacherID",teacher.TeacherID),
                new SqlParameter("@TeacherPwd",teacher.TeacherPwd),
                new SqlParameter("@TeacherName",teacher.TeacherName),
                new SqlParameter("@TeacherSubject",teacher.TeacherSubject),
                new SqlParameter("@TeacherTel",teacher.TeacherTel),
                new SqlParameter("@TeacherRank",teacher.TeacherRank)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnString, CommandType.Text, sql, para) > 0;
        }
    }
}
