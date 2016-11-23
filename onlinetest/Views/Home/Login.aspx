<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link href="../../CSS/Login.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width" />
    <title>登录</title>
</head>
<%
    string loginId = Request.Cookies["loginId"] != null ? Request.Cookies["loginId"].Value : "";
    string password = Request.Cookies["password"] != null ? Request.Cookies["password"].Value : "";
%>

<body>

  
    <div id="RightDL">
        <form action="<%=Url.Content("~/Home/Login") %>" method="post" id="DLform">
            <table id="DL_xz">
                
                <tr id="DL_xz_h1">
                    <td id="DL_bt1">
                        <input type="radio" value="学生" name="identity" checked="checked" />学生
                    </td>
                    <td id="DL_bt2">
                        <input type="radio" value="教师" name="identity" />教师</td>
                    <td id="DL_bt3">
                        <input type="radio" value="管理员" name="identity" />管理员</td>
                </tr>
                
            </table>
            <table id="DL_sr">
                <tr>
                    <td>
                        <img src="../../Images/账号.png" /></td>
                    <td>
                        <input id="name" type="text" name="loginId" class="opt_input" value="<%=loginId%>" />
                        
                    </td>

                </tr>
                <tr>
                    <td>
                        <img src="../../Images/密码.png" /></td>
                    <td>
                        
                        <input name="password" type="password" value="<%=password%>" class="opt_input" />
                    </td>
                </tr>
            </table>
            <p class="form_sub">

                <input name="RecordMe" type="checkbox" checked="checked" />
                <label>记住我</label>
            </p>

                <input value="" type="submit" class="form_login" /><br />
           
        </form>
    </div>
</body>
</html>
