using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using BLL;
using Model;
using Helper;
namespace onlinetest.Controllers
{
    
    public class AdminController : Controller
    { 
        //
        // GET: /Admin/
        int pageSize = 5;
        public ActionResult Index()
        {
            return View();
        }
        #region 用户管理
        #region 删除学生信息
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="category">下拉列表传值</param>
        /// <param name="keyWord">查询关键字</param>
        /// <param name="pageIndex">每页索引数</param>
        /// <returns></returns>
        public ActionResult DeleteStu(string category, string keyWord, int pageIndex = 1)
        {
            string id = Request.QueryString["id"];//获取学生id
            StuManager manager = new StuManager();
            manager.DeleteStuById(id);//调用删除学生方法
            List<Stu> stu = new List<Stu>();//定义学生列表对象
            //判断查询关键字是否为空
            if (!String.IsNullOrEmpty(category))
            {
                StuQuery cate = (StuQuery)Enum.Parse(typeof(StuQuery), category);
                stu = new StuManager().GetStu(cate, keyWord);
            }
            else
            {
                stu = new StuManager().GetStu();
            }
            //定义一个pagedList对象
            PagedList<Stu> pagedStus = new PagedList<Stu>(stu, pageIndex, pageSize);
            //提供教师查询方式的下拉框
            //调用查询方式
            SetDropDownList(category);
            ViewData["keyWord"] = keyWord;
            return View("StuList", pagedStus);
        }
        #endregion
        #region 删除教师信息
        /// <summary>
        /// 删除教师信息
        /// </summary>
        /// <param name="category">下拉列表传值</param>
        /// <param name="keyWord">查询关键字</param>
        /// <param name="pageIndex">每页索引数</param>
        /// <returns></returns>
        public ActionResult DeleteTeacher(string category, string keyWord, int pageIndex = 1)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);//获取教师id
            TeacherManager manager = new TeacherManager();
            manager.DeleteTeacherById(id);//调用删除教师方法
            List<Teacher> teacher = new List<Teacher>();//定义教师列表对象
            //判断查询关键字是否为空
            if (!String.IsNullOrEmpty(category))
            {
                TeacherQuery cate = (TeacherQuery)Enum.Parse(typeof(TeacherQuery), category);
                teacher = new TeacherManager().GetTeacher(cate, keyWord);
            }
            else
            {
                teacher = new TeacherManager().GetTeacher();
            }
            //定义一个pagedList对象
            PagedList<Teacher> pagedTeachers = new PagedList<Teacher>(teacher, pageIndex, pageSize);
            //提供教师查询方式的下拉框
            //调用查询方式
            SetDropDownList1(category);

            ViewData["keyWord"] = keyWord;
            return View("TeacherList", pagedTeachers);
        }
        #endregion
        #region 学生列表

        /// <summary>
        /// 学生列表
        /// </summary>
        /// <param name="category"></param>
        /// <param name="keyWord"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult StuList(string category, string keyWord, int pageIndex = 1)
        {
            List<Stu> stu = new List<Stu>();//定义学生列表对象
            //判断查询关键字是否为空
            if (!String.IsNullOrEmpty(category))
            {
                StuQuery cate = (StuQuery)Enum.Parse(typeof(StuQuery), category);
                stu = new StuManager().GetStu(cate, keyWord);
            }
            else
            {
                stu = new StuManager().GetStu();
            }
            //定义一个PagedList对象
            PagedList<Stu> pagedStus = new PagedList<Stu>(stu, pageIndex, pageSize);
            //提供学生查询方式的下拉框书籍
            //
            SetDropDownList(category);

            ViewData["keyWord"] = keyWord;
            return View("StuList", pagedStus);
        }
        /// <summary>
        /// 下拉列表绑定数据
        /// </summary>
        /// <param name="selectCategry">列表项</param>
        private void SetDropDownList(string selectCategry)
        {
            //定义查询列表项
            var itemCategries = new List<SelectListItem>();
            //获取枚举类型StuQuery的值
            Array items = Enum.GetValues(typeof(StuQuery));
            //添加列表项
            for (int i = 0; i < items.Length; i++)
            {
                string selectItem = items.GetValue(i).ToString();
                //判断是否添加过列表项
                if (selectCategry != selectItem)
                {
                    itemCategries.Add(new SelectListItem() { Text = selectItem, Value = selectItem });
                }
                else
                {
                    itemCategries.Add(new SelectListItem() { Text = selectItem, Value = selectItem, Selected = true });
                }

            }
            //传参到视图页
            ViewData["category"] = itemCategries;
        }

        #endregion
        #region 教师列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category">列表项</param>
        /// <param name="keyWord">查询关键字</param>
        /// <param name="pageIndex">列表索引值</param>
        /// <returns></returns>
        public ActionResult TeacherList(string category, string keyWord, int pageIndex = 1)
        {
            List<Teacher> teacher = new List<Teacher>();//定义教师列表对象
            //判断查询关键字是否为空
            if (!String.IsNullOrEmpty(category))
            {
                TeacherQuery cate = (TeacherQuery)Enum.Parse(typeof(TeacherQuery), category);
                teacher = new TeacherManager().GetTeacher(cate, keyWord);
            }
            else
            {
                teacher = new TeacherManager().GetTeacher();
            }
            PagedList<Teacher> pagedTeachers = new PagedList<Teacher>(teacher, pageIndex, pageSize);
            //提供书籍查询方式的下拉框书籍
            //
            SetDropDownList1(category);
            //SetDropDownListCategory1();
            ViewData["keyWord"] = keyWord;
            return View("TeacherList", pagedTeachers);
        }
        /// <summary>
        /// 下拉列表绑定数据
        /// </summary>
        /// <param name="selectCategry"></param>
        private void SetDropDownList1(string selectCategry)
        {
            //定义查询列表项
            var itemCategries = new List<SelectListItem>();
            //获取枚举类型TeacherQuery的值
            Array items = Enum.GetValues(typeof(TeacherQuery));
            //添加列表项
            for (int i = 0; i < items.Length; i++)
            {
                string selectItem = items.GetValue(i).ToString();
                //判断是否添加过列表项
                if (selectCategry != selectItem)
                {
                    itemCategries.Add(new SelectListItem() { Text = selectItem, Value = selectItem });
                }
                else
                {
                    itemCategries.Add(new SelectListItem() { Text = selectItem, Value = selectItem, Selected = true });
                }

            }
            //传参到视图页
            ViewData["category"] = itemCategries;
        }
        #endregion
        #region 添加教师
        [HttpGet]
        public ActionResult AddTeacher()
        {
            Teacher teacher = new Teacher();//定义一个teacher类对象
            //设置teacher默认值
            teacher.TeacherID = 10000;
            teacher.TeacherSubject = "语文";
            teacher.TeacherRank = "普通教师";
            teacher.TeacherTel = "0000000";

            return View(teacher);
        }
        [HttpPost]
        public ActionResult AddTeacher(Teacher teacher)
        {
            try
            {
                new TeacherManager().AddTeacher(teacher);//调用添加学生信息方法

                return Content("<script type='text/javascript'>alert('添加成功！');location.href='" + Url.Action("AddTeacher", "Admin") + "' </script>");
            }


            catch (Exception)
            {

                return Content("<script type='text/javascript'>alert('信息填写不正确！');location.href='" + Url.Action("AddTeacher", "Admin") + "' </script>");
            }
        }
        #endregion
        #region 添加学生
        [HttpGet]
        public ActionResult AddStu()
        {
            Stu stu = new Stu();//定义一个Stu类
            //stu.StuID = Convert.ToInt32(Request.QueryString["stu.StuID"]);
            //定义stu的默认值
            stu.StuID = 20130000;
            stu.StuPwd = "1111";
            stu.StuClass = 1;
            stu.StuGrade = 1;
            stu.StuTel = "0000000";
            return View(stu);
        }
        [HttpPost]
        public ActionResult AddStu(Stu stu)
        {
            try
            {

                new StuManager().AddStu(stu);//调用添加学生信息方法

                return Content("<script type='text/javascript'>alert('添加成功！');location.href='" + Url.Action("AddStu", "Admin") + "' </script>");


            }
            catch (Exception)
            {

                return Content("<script type='text/javascript'>alert('学生编号重复！');location.href='" + Url.Action("AddStu", "Admin") + "' </script>");
            }
        }
        #endregion
        #region 编辑学生信息
        [HttpGet]
        public ActionResult EditStu()
        {
            string id = Request.QueryString["id"];//从前台获取id值

            Stu stu = new StuManager().GetStuById(id);//调用通过id值获取学生信息方法
            return View(stu);
        }
        [HttpPost]
        public ActionResult EditStu(Stu stu)
        {
            try
            {

                new StuManager().ModifyStu(stu);//调用修改学生信息方法
                return Content("<script type='text/javascript'>alert('修改成功！');location.href='" + Url.Action("StuList", "Admin") + "' </script>");
            }
            catch (Exception)
            {

                return Content("<script type='text/javascript'>alert('信息不合法！');location.href='" + Url.Action("EditStu", "Admin") + "' </script>");
            }
        }
        #endregion
        #region 编辑教师信息
        [HttpGet]
        public ActionResult EditTeacher()
        {
            string id = Request.QueryString["id"];//从前台页面获取id值

            Teacher teacher = new TeacherManager().GetTeacherById(id);//通过id获取教师信息
            return View(teacher);
        }
        [HttpPost]
        public ActionResult EditTeacher(Teacher teacher)
        {
            try
            {

                new TeacherManager().ModifyTeacher(teacher);//调用修改教师方法
                //return View();
                return Content("<script type='text/javascript'>alert('修改成功！');location.href='" + Url.Action("TeacherList", "Admin") + "' </script>");
            }
            catch (Exception)
            {

                return Content("<script type='text/javascript'>alert('信息不合法！');location.href='" + Url.Action("EditTeacher", "Admin") + "' </script>");
            }


        }
        #endregion
        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult ModifyAdminPaw(string AdminId)
        {
            AdminId = Session["CurrentUser"].ToString();//获取当前登录用户账号
            Admin admin = new AdminManager().GetAdminById(AdminId);//获取数据表中该账号对应信息
            return View(admin);
        }
        [HttpPost]
        public ActionResult ModifyAdminPaw(Admin admin)
        {
            try
            {

                new AdminManager().ModifyAdmin(admin);//调用修改Admin方法

                return Content("<script type='text/javascript'>alert('修改成功！');location.href='" + Url.Action("ModifyAdminPaw", "Admin") + "' </script>");
            }
            catch (Exception)
            {

                return Content("<script type='text/javascript'>alert('信息不合法！');location.href='" + Url.Action("ModifyAdminPaw", "Admin") + "' </script>");
            }


        }
        #endregion
        #endregion
        #region 题目管理
        public ActionResult TopicManag()
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
        #region 考试管理
        public ActionResult TestManag()
        {
            return View();
        }
        #endregion
    }
}
