using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Grades
    {
        public int GradesID { get; set; }  //成绩单编号
        public Stu NOID { get; set; }  //学生编号
        public float Chinese { get; set; }  //语文成绩
        public float English { get; set; }  //英语成绩
        public float Politics { get; set; }  //政治成绩
        public float History { get; set; }  //历史成绩
        public float Geo { get; set; }  //地理成绩
        public float CS { get; set; }  //计算机成绩

    }
}
