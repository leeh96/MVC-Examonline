using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Answer
    {
        public int AnswerID { get; set; }  //答案编号
        public int StuID { get; set; }  //对应学生表编号
        public string CQ1 { get; set; }  //学生选择题答案1
        public string CQ2 { get; set; }  //学生选择题答案2
        public string CQ3 { get; set; }  //学生选择题答案3
        public string CQ4 { get; set; }  //学生选择题答案4
        public string CQ5 { get; set; }  //学生选择题答案5
        public string Completion1 { get; set; }  //学生填空题答案1
        public string Completion2 { get; set; }  //学生填空题答案2
        public string Completion3 { get; set; }  //学生填空题答案3
        public string Completion4 { get; set; }  //学生填空题答案4
        public string Completion5 { get; set; }  //学生填空题答案5
        public bool TOF1 { get; set; }  //学生判断题答案1
        public bool TOF2 { get; set; }  //学生判断题答案2
        public bool TOF3 { get; set; }  //学生判断题答案3
        public bool TOF4 { get; set; }  //学生判断题答案4
        public bool TOF5 { get; set; }  //学生判断题答案5
        public string COM1 { get; set; }  //学生综合题答案1
        public string COM2 { get; set; }  //学生综合题答案2




    }
}
