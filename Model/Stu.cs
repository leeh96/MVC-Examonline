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
     public class Stu
    {
        [DisplayName("学生编号")]
        //[Remote("Default",HttpMethod="post",ErrorMessage="学生账号不能重复")]
        [DefaultValue(20130000)]
        [Required(ErrorMessage = "{0}不得为空")]

         public int StuID { get; set; }//学号即登陆账号

        
        [DisplayName("学生密码")]
        [Required(ErrorMessage = "{0}不得为空")]
         public string StuPwd { get; set; }//学生登陆密码

        [DisplayName("确认密码")]
        [Required(ErrorMessage = "{0}不得为空")]
        [Compare("StuPwd", ErrorMessage = "两次输入的密码必须一致")]
        public string PasswordConfirm { get; set; }  //确认密码

        [DisplayName("学生姓名")]
        [Required(ErrorMessage = "{0}不得为空")]
         public string StuName { get; set; }//学生姓名

        [DisplayName("学生班级")]
        [Required(ErrorMessage = "{0}不得为空")]
        [Range(typeof(int), "1", "4", ErrorMessage = "{0}必须在{1}和{2}之间")]
         public int StuClass { get; set; }//学生班级

        [DisplayName("学生年级")]
        [Required(ErrorMessage = "{0}不得为空")]
        [Range(typeof(int), "1", "4", ErrorMessage = "{0}必须在{1}和{2}之间")]
         public int StuGrade { get; set; }//学生年级

        [DisplayName("联系方式")]
        [Required(ErrorMessage = "{0}不得为空")]
        [StringLength(11, MinimumLength = 7, ErrorMessage = "{0}长度必须在{2}和{1}之间")]
         public string StuTel { get; set; }//学生联系方式
    }
    public enum StuQuery
    {
        学号,
        姓名,
        年级,
        班级
    }
}
