using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BLL;
using Model;

namespace onlinetest.Controllers
{
    public class StuController : Controller
    {
        //
        // GET: /Stu/

        public ActionResult Index()
        {
            return View();
        }
        #region 修改个人信息
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="loginId">登录账号</param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Update(string StuId)
        {
            StuId = Session["CurrentUser"].ToString();//获取登陆用户名
            Stu stu = new StuManager().GetStuById(StuId);//通过登陆id获取学生信息
            return View(stu);
        }
        [HttpPost]
        public ActionResult Update(Stu stu)
        {
            try
            {
                //调用修改学生信息方法
                new StuManager().ModifyStu(stu);

                return Content("<script type='text/javascript'>alert('修改成功！');location.href='" + Url.Action("Update", "Stu") + "' </script>");
            }
            catch (Exception)
            {

                return Content("<script type='text/javascript'>alert('信息不合法！');location.href='" + Url.Action("Update", "Stu") + "' </script>");
            }


        }
        #endregion
        #region 修改密码
        /// <summary>
        /// 修改修改密码
        /// </summary>
        /// <param name="loginId">登陆账号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModifyStuPaw(string StuId)
        {
            StuId = Session["CurrentUser"].ToString();//获取登陆用户名
            Stu stu = new StuManager().GetStuById(StuId);//通过登陆id获取学生信息
            return View(stu);
        }
        [HttpPost]
        public ActionResult ModifyStuPaw(Stu stu)
        {
            try
            {
                //调用修改学生信息方法
                new StuManager().ModifyStu(stu);

                return Content("<script type='text/javascript'>alert('修改成功！');location.href='" + Url.Action("ModifyStuPaw", "Stu") + "' </script>");
            }
            catch (Exception)
            {

                return Content("<script type='text/javascript'>alert('信息不合法！');location.href='" + Url.Action("ModifyStuPaw", "Stu") + "' </script>");
            }

        }
        #endregion
        #region 班级排名
        public ActionResult Banjilist()
        {
            return View();
        }
        #endregion
        #region 成绩查询
        public ActionResult QueryGrades()
        {
            return View();
        }
        #endregion
        #region 在线考试
        public ActionResult TestOnline()
        {
            return View();
        }
        #endregion
        #region 考试编排
        public ActionResult TestData()
        {
            return View();
        }
        #endregion
    }
}
