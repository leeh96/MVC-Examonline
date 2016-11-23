<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Adminsite.Master" Inherits="System.Web.Mvc.ViewPage<Helper.PagedList<Model.Stu>>" %>

<%@ Import Namespace="Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link href="<%= Url.Content("~/CSS/member.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        using (Html.BeginForm("StuList", "Admin", FormMethod.Post))
        {%>
    <div style="width: 800px">
        <table id="jiansuo">
            <tr>
                <td>&nbsp;&nbsp; 检索类别：
                 <%=Html.DropDownList("category", (IEnumerable<SelectListItem>)ViewData["category"], "请选择")%>                
                关键字：<input name="keyword" type="text" id="keyword" value="<%= ViewData["keyWord"]??"" %>" />
                    <input type="submit" name="query" value="查询" id="query"  />
                </td>
            </tr>
        </table>
        <%  }
        %>
        <div id="tianjia" ><a href="/Admin/AddStu">添加学生</a></div>
    </div>
    <table class="data_table" >
        <tr>
            <th class="auto-style1">学生编号</th>
            <th class="auto-style1">学生名字</th>
            <th class="auto-style1">学生年级</th>
            <th class="auto-style1">学生班级</th>
            <th class="auto-style1">学生联系方式</th>
            <th class="auto-style1">删除</th>
            <th class="auto-style1">编辑</th>
        </tr>
        <tr>
            <%
                if (Model != null && Model.Count > 0)
                {
                    for (int i = 0; i < Model.Count; i++)
                    {
                        Model.Stu stu = Model[i];
            %>

            <td class="auto-style1"><%=stu.StuID %></td>
            <td class="auto-style1"><%=stu.StuName %></td>
            <td class="auto-style1"><%=stu.StuGrade %></td>
            <td class="auto-style1"><%=stu.StuClass %></td>
            <td class="auto-style1"><%=stu.StuTel %></td>
            <td class="auto-style1">
                <a href="/Admin/DeleteStu?id=<%=stu.StuID %>">删除</a>

            </td>
            <td class="auto-style1"><a href="/Admin/EditStu?id=<%=stu.StuID %>">编辑</a>

            </td>
        </tr>
        <%    }

            }
        %>
    </table>
    <div id="fenye" ><%=Html.Pager(Model) %></div>


</asp:Content>
