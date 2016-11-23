<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
 <style type="text/css">
      body {
            background-image: url('../Images/zhu.jpg');
            background-position-x: center;
            background-repeat: no-repeat;
            width: 1280px;
            height: 680px;
            overflow: scroll;
            overflow-y: hidden;
            overflow-x: hidden;
        }
        #top {
            margin-left:800px;
            margin-top:60px;
            color:#fff;
        }
        .auto-style1 {
            width: 180px;
            height: 246px;
        }

        #btn {
            margin-left: 300px;
            margin-top: 100px;
            width: 800px;
           
        }

        a.home1 {
            background: url(../Images/在线考试2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            _float: left;
        }

            a.home1:hover {
                background: url(../Images/在线考试1.png) no-repeat;
            }

        a.home2 {
            background: url(../Images/成绩查询2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            _float: left;
        }

            a.home2:hover {
                background: url(../Images/成绩查询1.png) no-repeat;
            }

        a.home3 {
            background: url(../Images/考试编排2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            _float: left;
        }

            a.home3:hover {
                background: url(../Images/考试编排1.png) no-repeat;
            }

        a.home4 {
            background: url(../Images/班级排名2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            _float: left;
        }

            a.home4:hover {
                background: url(../Images/班级排名1.png) no-repeat;
            }
    </style>
</head>
<html>
<body>
    <div id="top">
         <%if (Session["CurrentUser"] != null)
  {  
      %>
      您好， <a href="<% =Url.Content("~/Stu/Update")%>"><%=Session["UserName"].ToString()%> </a>    <a href="<% =Url.Content("~/Home/Index")%>">【注销】</a><a href="<% =Url.Content("~/Stu/ModifyStuPaw")%>">【修改密码】</a>
<%
  }%>
  <%=DateTime.Now.ToString("yyyy-MM-dd")%>
    </div>
    
    <div id="btn">
        <a class="home1" href="TestOnline"></a>
        &nbsp;&nbsp;
           <a class="home2" href="QueryGrades"></a>
        &nbsp;&nbsp;
           <a class="home3" href="TestData"></a>
        &nbsp;&nbsp;
          <a class="home4" href="Banjilist"></a>
         &nbsp;&nbsp;
          
       
    </div>
</body>
</html>
