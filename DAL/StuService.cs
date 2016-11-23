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
    public class StuService
    {
        //查询
        public Stu GetStuById(string id)
        {
            //sql语句

            string sql = "SELECT *  FROM  Stu where StuID=@id";
            Stu stu = null;
            using (SqlDataReader row = SqlHelper.ExecuteReader(SqlHelper.ConnString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                if (row.Read())
                {
                    stu = new Stu();
                    stu.StuID = (int)row["StuID"];
                    stu.StuPwd = (string)row["StuPwd"];
                    stu.StuName = (string)row["StuName"];
                    stu.StuClass = (int)row["StuClass"];
                    stu.StuGrade = (int)row["StuGrade"];
                    stu.StuTel = (string)row["StuTel"];


                }
            }

            return stu;
        }
        public List<Stu> GetStusById(string id)
        {

            List<Stu> list = new List<Stu>();
            string sql = "SELECT * FROM  Stu where StuID=@id";
            // DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, CommandType.Text, sql);
            Stu stu = null;
            using (SqlDataReader row = SqlHelper.ExecuteReader(SqlHelper.ConnString, CommandType.Text, sql, new SqlParameter("@id", id)))
            {
                if (row.Read())
                {
                    stu = new Stu();
                    stu.StuID = (int)row["StuID"];
                    stu.StuPwd = (string)row["StuPwd"];
                    stu.StuName = (string)row["StuName"];
                    stu.StuClass = (int)row["StuClass"];
                    stu.StuGrade = (int)row["StuGrade"];
                    stu.StuTel = (string)row["StuTel"];
                    list.Add(stu);

                }
            }


            return list;

        }

        public List<Stu> GetStu()
        {

            List<Stu> list = new List<Stu>();
            string sql = "SELECT * FROM  Stu ORDER BY StuID";
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Stu stu = new Stu();
                    stu.StuID = (int)row["StuID"];
                    stu.StuName = (string)row["StuName"];
                    stu.StuClass = (int)row["StuClass"];
                    stu.StuGrade = row["StuGrade"] != DBNull.Value ? (int)row["StuGrade"] : 0;
                    stu.StuTel = (string)row["StuTel"];
                    list.Add(stu);
                }
            }
            return list;

        }

        public List<Stu> GetStu(int PageNumber, int PageSize, string DataOrderBy, string safeSqlCondition)
        {

            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT TOP " + PageSize + " * FROM (SELECT ROW_NUMBER() OVER (ORDER BY " + DataOrderBy + ") AS RowNumber,* FROM Stu ");
            commandText.Append(" WHERE " + safeSqlCondition + " ");//这里修改条件语句
            commandText.Append(" ) AS T  WHERE RowNumber > (" + PageSize + "*(" + PageNumber + "-1))");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, CommandType.StoredProcedure, commandText.ToString());

            List<Stu> list = new List<Stu>();

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Stu stu = new Stu();
                    stu.StuID = (int)row["StuID"];
                    stu.StuName = (string)row["StuName"];
                    stu.StuClass = (int)row["StuClass"];
                    stu.StuGrade = row["StuGrade"] != DBNull.Value ? (int)row["StuGrade"] : 0;
                    stu.StuTel = (string)row["StuTel"];
                    list.Add(stu);
                }
            }
            return list;

        }
        public List<Stu> GetStu(StuQuery category, string keyWord)
        {
            List<Stu> list = new List<Stu>();
            //category.CompareTo(StuQueryCategories.书名)
            string sql = "SELECT * FROM Stu where  ";
            if (String.Compare(category.ToString(), "学号", true) == 0)
            {
                sql = sql + " StuID LIKE '%" + keyWord + "%'";
            }
            else if (String.Compare(category.ToString(), "姓名", true) == 0)
            {
                sql = sql + " StuName LIKE '%" + keyWord + "%'";
            }
            else if (String.Compare(category.ToString(), "年级", true) == 0)
            {
                sql = sql + " StuGrade LIKE '%" + keyWord + "%'";
            }
            else if (String.Compare(category.ToString(), "班级", true) == 0)
            {
                sql = sql + " StuClass LIKE '%" + keyWord + "%'";
            }
            //DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, "sp_QueryStus", category, keyWord);
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnString, CommandType.Text, sql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Stu stu = new Stu();
                    stu.StuID = (int)row["StuID"];
                    stu.StuName = (string)row["StuName"];
                    stu.StuClass = (int)row["StuClass"];
                    stu.StuGrade = row["StuGrade"] != DBNull.Value ? (int)row["StuGrade"] : 0;
                    stu.StuTel = (string)row["StuTel"];
                    list.Add(stu);
                }
            }
            return list;

        }
        //增加
        public void AddStu(Stu stu)
        {
            //1、sql语句

            string sql = "insert into Stu(StuID,StuPwd,StuName,StuClass,StuGrade,StuTel) values(@StuID,@StuPwd,@StuName,@StuClass,@StuGrade,@StuTel)";
            //sql += " select @@IDENTITY";
            //2、参数赋值
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@StuID",stu.StuID),
                new SqlParameter("@StuPwd",stu.StuPwd),
                new SqlParameter("@StuName",stu.StuName),
                new SqlParameter("@StuClass",stu.StuClass),
                new SqlParameter("@StuGrade",stu.StuGrade),
                new SqlParameter("@StuTel",stu.StuTel)
            };
            //3、执行sql

            stu.StuID = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.ConnString, CommandType.Text, sql, para));
        }
        //删除
        public bool DeleteStuById(string id)
        {
            string sql = "delete  FROM Stu where StuID=@Id";
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter("@Id",id)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnString, CommandType.Text, sql, para) > 0;
        }
        //修改
        public bool ModifyStu(Stu stu)
        {
            string sql = "UPDATE Stu " +
                          " SET StuPwd = @StuPwd," +
                              " StuName = @StuName," +
                              " StuClass = @StuClass," +
                              " StuGrade = @StuGrade," +
                              " StuTel = @StuTel WHERE " +
                              "StuID = @StuID";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@StuID",stu.StuID),
                new SqlParameter("@StuPwd",stu.StuPwd),
                new SqlParameter("@StuName",stu.StuName),
                new SqlParameter("@StuClass",stu.StuClass),
                new SqlParameter("@StuGrade",stu.StuGrade),
                new SqlParameter("@StuTel",stu.StuTel)
            };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnString, CommandType.Text, sql, para) > 0;
        }
    }
}
