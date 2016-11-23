<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Teachersite.Master" Inherits="System.Web.Mvc.ViewPage<Model.Teacher>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <link href="<%= Url.Content("~/CSS/member.css") %>" rel="stylesheet" type="text/css" />
     <script src="<%= Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%= Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm("Update", "Teacher", FormMethod.Post))
       { %>
    <%: Html.ValidationSummary(true)%>

    <fieldset>
        <legend>修改个人信息</legend>
        教师编号：
        <%: Html.DisplayFor(model => model.TeacherID)%>
        <%:Html.HiddenFor(model => model.TeacherID) %>
        <%: Html.HiddenFor(model => model.TeacherPwd)%>


        <div class="editor-label">
            <%: Html.LabelFor(model => model.TeacherName)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.TeacherName)%>
            <%: Html.ValidationMessageFor(model => model.TeacherName)%>
        </div>
        <div class="editor-label">
                <%: Html.LabelFor(model => model.TeacherSubject)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.TeacherSubject)%>
                <%: Html.ValidationMessageFor(model => model.TeacherSubject)%>
            </div>
    
            <div class="editor-label">
                <%: Html.LabelFor(model => model.TeacherRank)%>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.TeacherRank)%>
                <%: Html.ValidationMessageFor(model => model.TeacherRank)%>
            </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.TeacherTel)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.TeacherTel)%>
            <%: Html.ValidationMessageFor(model => model.TeacherTel)%>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
    <% } %>

  
    </asp:Content>