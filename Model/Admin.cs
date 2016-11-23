using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Admin
    {
        [DisplayName("管理员ID")]
        [Required(ErrorMessage = "{0}不得为空")]
        public int AdminID { get; set; }//管理员ID
        [DisplayName("管理员密码")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string AdminPwd { get; set; }//管理员密码

        [DisplayName("确认密码")]
        [Required(ErrorMessage = "{0}不得为空")]
        [Compare("AdminPwd", ErrorMessage = "两次输入的密码必须一致")]
        public string PasswordConfirm { get; set; }  //确认密码
    }
}
