using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Model
{
    [Serializable]
    public class Teacher
    {
        [DisplayName("教师编号")]
        [Required(ErrorMessage = "{0}不得为空")]
        public int TeacherID { get; set; }//教师ID即登录账号
        [DisplayName("登陆密码")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string TeacherPwd { get; set; }//登陆密码

        [DisplayName("确认密码")]
        [Required(ErrorMessage = "{0}不得为空")]
        [Compare("TeacherPwd", ErrorMessage = "两次输入的密码必须一致")]
        public string PasswordConfirm { get; set; }  //确认密码

        [DisplayName("教师姓名")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string TeacherName { get; set; }//教师姓名
        [DisplayName("教授科目")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string TeacherSubject { get; set; }//教师科目
      

        public string TeacherTel { get; set; }//教师电话
        [DisplayName("教师职称")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string TeacherRank { get; set; }//教师职称
    }
    public enum TeacherQuery
    {
        教师编号,
        教师姓名,
        教授学科,
        教师职称
    }
}
