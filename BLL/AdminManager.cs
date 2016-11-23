using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class AdminManager
    {
        //通过id获取数据
        public Admin GetAdminById(string id)
        {
            return new AdminService().GetAdminById(id);
        }
        //增加
        public void AddAdmin(Admin q)
        {
            new AdminService().AddAdmin(q);
        }
        //删除
        public bool DeleteAdminById(int id)
        {
            return new AdminService().DeleteAdminById(id);
        }
        //更新
        public bool ModifyAdmin(Admin q)
        {
            return new AdminService().ModifyAdmin(q);
        }
        //登陆
        public bool AdminLogIn(string loginId, string loginPwd, out Admin validAdmin)
        {
            Admin admin = new AdminService().GetAdminById(loginId);

            if (admin == null)
            {
                validAdmin = null; //用户名不存在
                return false;
            }
            if (admin.AdminPwd == loginPwd)
            {
                validAdmin = admin;
                return true;
            }
            else
            {
                validAdmin = null;//密码错误
                return false;
            }
        }
    }
}
