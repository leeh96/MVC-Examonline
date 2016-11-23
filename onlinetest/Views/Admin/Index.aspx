<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>管理</title>
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
            background: url(../Images/考试管理2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            float: left;
        }

            a.home1:hover {
                background: url(../Images/考试管理1.png) no-repeat;
            }

        a.home2 {
            background: url(../Images/成绩管理2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            _float: left;
        }

            a.home2:hover {
                background: url(../Images/成绩管理1.png) no-repeat;
            }

        a.home3 {
            background: url(../Images/用户管理2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            _float: left;
        }

            a.home3:hover {
                background: url(../Images/用户管理1.png) no-repeat;
            }

        a.home4 {
            background: url(../Images/题目管理2.png) no-repeat;
            width: 180px;
            height: 246px;
            display: inline-block;
            _float: left;
        }

            a.home4:hover {
                background: url(../Images/题目管理1.png) no-repeat;
            }

      
    </style>
</head>

<body>
     <div id="top">
        <%= Html.Partial("LogInPartial") %>
    </div>
    


    <div id="btn">
        <a class="home1" href="TestManag"></a>
        &nbsp;&nbsp;
           <a class="home2" href="GradesManag"></a>
        &nbsp;&nbsp;
           <a class="home3" href="StuList"></a>
        &nbsp;&nbsp;
          <a class="home4" href="TopicManag"></a>
       
    </div>

</body>
</html>

