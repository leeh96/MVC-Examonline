<%@ Page Language="C#"  MasterPageFile="~/Views/Shared/Adminsite.Master" Inherits="System.Web.Mvc.ViewPage<Helper.PagedList<Model.Teacher>>" %>
<%@ Import Namespace="Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link href="<%= Url.Content("~/CSS/member.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%
        using (Html.BeginForm("TeacherList","Admin"))
        {%>
    <div style="width: 800px">
      <table id="jiansuo">
        <tr>
            <td>&nbsp;&nbsp; 检索类别：
          <%=Html.DropDownList("category", (IEnumerable<SelectListItem>)ViewData["category"], " ")%>
                <%--<%=Html.DropDownList("categoryList","请选择") %>--%>
                关键字：<input name="keyword" type="text" id="keyword" value="<%= ViewData["keyWord"]??"" %>"/>

                <input type="submit" name="query" value="查询" id="query" />
            </td>
        </tr>
    </table>
            
      <%  }
         %>
         <div id="tianjia" ><a href="/Admin/AddTeacher" >添加教师</a></div>
        </div>
 <table class="data_table">
                <tr>
                    <th class="auto-style1">教师编号</th>
                    <th class="auto-style1">教师姓名</th>
                    <th class="auto-style1">教授学科</th>
                    <th class="auto-style1">教师职称</th>
                    <th class="auto-style1">教师联系方式</th>
                    <th class="auto-style1">删除</th>
                        <th class="auto-style1">编辑</th>
                </tr>
                <tr>
                    <%
            if (Model!=null&&Model.Count>0)
            {
                for (int i = 0; i < Model.Count; i++)
                {
                    Model.Teacher teacher = Model[i];
                    %>
                    
                    <td class="auto-style1"><%=teacher.TeacherID %></td>
                    <td class="auto-style1"><%=teacher.TeacherName %></td>
                    <td class="auto-style1"><%=teacher.TeacherSubject %></td>
                    <td class="auto-style1"><%=teacher.TeacherRank %></td>
                    <td class="auto-style1"><%=teacher.TeacherTel %></td>
                    <td class="auto-style1">
                        <a href="/Admin/DeleteTeacher?id=<%=teacher.TeacherID %>">删除</a>
                        <%--<%: Html.ActionLink("删除","Delete","Admin",new {id=teacher.TeacherID},null) %>--%>
                    </td>
                    <td class="auto-style1"><a href="/Admin/EditTeacher?id=<%=teacher.TeacherID %>" >编辑</a>
                       
                    </td>
                </tr>
                <%    }
                
            }
             %>
                  </table>
     <div id="fenye" ><%=Html.Pager(Model) %></div>
    </asp:Content>