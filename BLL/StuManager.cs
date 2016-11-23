using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
    public class StuManager
    {
        //通过id获取数据
        public Stu GetStuById(string id)
        {
            return new StuService().GetStuById(id);
        }
        public List<Stu> GetStusById(string id)
        {
            return new StuService().GetStusById(id);
        }
        public List<Stu> GetStu()
        {
            return new StuService().GetStu();
        }
        public List<Stu> GetStu(StuQuery category, string keyWord)
        {
            return new StuService().GetStu(category, keyWord);
        }
        //增加
        public void AddStu(Stu q)
        {
            new StuService().AddStu(q);
        }
        //删除
        public bool DeleteStuById(string id)
        {
            return new StuService().DeleteStuById(id);
        }
        //更新
        public bool ModifyStu(Stu q)
        {
            return new StuService().ModifyStu(q);
        }
        //登陆
        public bool StuLogIn(string loginId, string loginPwd, out Stu validStu)
        {
            Stu stu = new StuService().GetStuById(loginId);

            if (stu == null)
            {
                validStu = null; //用户名不存在
                return false;
            }
            if (stu.StuPwd == loginPwd)
            {
                validStu = stu;
                return true;
            }
            else
            {
                validStu = null;//密码错误
                return false;
            }
        }
    }
}
