<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%if (Session["CurrentUser"] != null)
  {  
      %>
      您好，<%=Session["UserName"].ToString()%>     <a href="<% =Url.Content("~/Home/Index")%>">【注销】</a><a href="<% =Url.Content("~/Admin/Index")%>">【返回】</a><a href="<% =Url.Content("~/Admin/ModifyAdminPaw")%>">【修改密码】</a>
<%
  }%>
   当前日期：<%=DateTime.Now.ToString("yyyy-MM-dd")%>
