using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
namespace onlinetest.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/

        public ActionResult Index()
        {
            return View();
        }
        #region 个人管理
        #region 修改个人信息
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Update(string TeacherId)
        {
            TeacherId = Session["CurrentUser"].ToString();//获取登录用户名
            Teacher teacher = new TeacherManager().GetTeacherById(TeacherId);//调用通过id获取教师信息方法
            return View(teacher);
        }
        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            new TeacherManager().ModifyTeacher(teacher);//调用修改学生信息方法
            return View();
        }
        #endregion
        #region 修改密码
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult ModifyTeacherPaw(string TeacherId)
        {

            TeacherId = Session["CurrentUser"].ToString();//获取登录用户名
            Teacher teacher = new TeacherManager().GetTeacherById(TeacherId);//调用通过id获取教师信息方法
            return View(teacher);
        }
        [HttpPost]
        public ActionResult ModifyTeacherPaw(Teacher teacher)
        {
            new TeacherManager().ModifyTeacher(teacher);//调用修改学生信息方法
            return View();
        }
        #endregion
        #endregion
        #region 考卷评阅
        public ActionResult PaperReview()
        {
            return View();
        }
        #endregion
        #region 成绩管理
        public ActionResult GradesManag()
        {
            return View();
        }
        #endregion
        #region 考试编排
        public ActionResult TestManag()
        {
            return View();
        }
        #endregion

        #region 题目管理
        public ActionResult TopicManag()
        {
            return View();
        }
        #endregion
    }
}
