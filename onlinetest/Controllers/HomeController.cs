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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        public ActionResult Index()
        {
            return View("Login");
        }
       
       
        #region 登录处理
        /// <summary>
        /// 登陆处理
        /// </summary>
        /// <param name="loginId">登陆账号</param>
        /// <param name="password">登录密码</param>
        /// <returns></returns>
        
        public ActionResult Login(string loginId, string password)
        {
            
            //1、获取数据
            
            string charge = Request.Form["identity"];
           
            //2、非空验证

            if (string.IsNullOrEmpty(loginId))
            {
                return View("Login");//返回login视图
            }
            if (string.IsNullOrEmpty("password"))
            {
                return View("Login");//返回login视图
            }
            //3、数据库验证，判定登陆是否成功
            if (charge == "教师") { 
            TeacherManager tm=new TeacherManager();
            Teacher teacher = new Teacher();
            if (tm.TeacherLogIn(loginId, password,out teacher))
            {
                //4、记住用户名和密码 cookie
                string recordMe = Request.Form["RecordMe"];
                if (!string.IsNullOrEmpty(recordMe))//记录用户名和密码
                {
                    HttpCookie nameCookie = new HttpCookie("loginId", loginId);
                    nameCookie.Expires = DateTime.MaxValue;
                    Response.Cookies.Add(nameCookie);
                    HttpCookie passwordCookie = new HttpCookie("password", password);
                    nameCookie.Expires = DateTime.MaxValue;
                    Response.Cookies.Add(passwordCookie);
                }
                else
                {
                    //让Cookie失效
                    Response.Cookies["loginId"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                }
                //5、保存用户的状态 sesion
                teacher = new TeacherManager().GetTeacherById(loginId);
                Session["CurrentUser"] = loginId;
                Session["UserName"] = teacher.TeacherName;
                    //登陆成功页面
                    return Redirect("~/Teacher/Index");
            } 
            else
            {
                //返回登陆页面
                
                return View("Login");
            }
             
        }
            if (charge == "学生")
            {
                StuManager tm = new StuManager();
                Stu stu = new Stu();
                if (tm.StuLogIn(loginId, password, out stu))
                {
                    //4、记住用户名和密码 cookie
                    string recordMe = Request.Form["RecordMe"];
                    if (!string.IsNullOrEmpty(recordMe))//记录用户名和密码
                    {
                        HttpCookie nameCookie = new HttpCookie("loginId", loginId);
                        nameCookie.Expires = DateTime.MaxValue;
                        Response.Cookies.Add(nameCookie);
                        HttpCookie passwordCookie = new HttpCookie("password", password);
                        nameCookie.Expires = DateTime.MaxValue;
                        Response.Cookies.Add(passwordCookie);
                    }
                    else
                    {
                        //让Cookie失效
                        Response.Cookies["loginId"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                    }
                    //5、保存用户的状态 sesion
                   
                    stu = new StuManager().GetStuById(loginId);
                    Session["CurrentUser"] = loginId;
                    Session["UserName"] = stu.StuName;
                   
                        //登陆成功页面
                    return Redirect("~/Stu/Index");
                   

                }
                else
                {
                    //返回登陆页面
                    return View("Login");
                }

            }
            if (charge == "管理员")
            {
                AdminManager tm = new AdminManager();
                Admin admin = new Admin();
                if (tm.AdminLogIn(loginId, password, out admin))
                {
                    //4、记住用户名和密码 cookie
                    string recordMe = Request.Form["RecordMe"];
                    if (!string.IsNullOrEmpty(recordMe))//记录用户名和密码
                    {
                        HttpCookie nameCookie = new HttpCookie("loginId", loginId);
                        nameCookie.Expires = DateTime.MaxValue;
                        Response.Cookies.Add(nameCookie);
                        HttpCookie passwordCookie = new HttpCookie("password", password);
                        nameCookie.Expires = DateTime.MaxValue;
                        Response.Cookies.Add(passwordCookie);
                    }
                    else
                    {
                        //让Cookie失效
                        Response.Cookies["loginId"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                    }
                    //5、保存用户的状态 sesion

                    
                    Session["CurrentUser"] = loginId;
                    Session["UserName"] = loginId;
                  
                        //登陆成功页面
                    return Redirect("~/Admin/Index");
                   

                }
                else
                {
                    //返回登陆页面
                    return View("Login");
                }

            }
             else
            {
                //返回登陆页面
                return View("Login");
            }
           
        }
        #endregion
        
    }
}
