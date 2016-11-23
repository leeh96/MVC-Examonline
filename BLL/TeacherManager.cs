using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class TeacherManager
    {
        //通过id获取数据
        public Teacher GetTeacherById(string id)
        {
            return new TeacherService().GetTeacherById(id);
        }
        public List<Teacher> GetTeacher()
        {
            return new TeacherService().GetTeacher();
        }
        public List<Teacher> GetTeacher(TeacherQuery category, string keyWord)
        {
            return new TeacherService().GetTeacher(category, keyWord);
        }
        //增加
        public void AddTeacher(Teacher q)
        {
            new TeacherService().AddTeacher(q);
        }
        //删除
        public bool DeleteTeacherById(int id)
        {
            return new TeacherService().DeleteTeacherById(id);
        }
        //更新
        public bool ModifyTeacher(Teacher q)
        {
            return new TeacherService().ModifyTeacher(q);
        }
        //登陆
        public bool TeacherLogIn(string loginId, string loginPwd, out Teacher validTeacher)
        {
            Teacher teacher = new TeacherService().GetTeacherById(loginId);

            if (teacher == null)
            {
                validTeacher = null; //用户名不存在
                return false;
            }
            if (teacher.TeacherPwd == loginPwd)
            {
                validTeacher = teacher;
                return true;
            }
            else
            {
                validTeacher = null;//密码错误
                return false;
            }
        }
    }
}
